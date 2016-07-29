using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.AutoNSubstitute.UnitTest.TestTypes;
using Ploeh.AutoFixture.Xunit2;
using Ploeh.TestTypeFoundation;
using Xunit;

namespace AutoFixture.xUnit.net2.NSubstitute
{
    public class Scenario
    {
        [Theory, AutoNSubstituteData]
        public void CreateWithConcreteTypeAndSubstituteAttributeCreatesMock([Substitute] ConcreteType sut)
        {
            Assert.IsAssignableFrom<ConcreteType>(sut);
            Assert.True(sut.GetType().BaseType == typeof(ConcreteType));
        }

        [Theory, AutoNSubstituteData]
        public void CreateWithFrozenConcreteTypeAndSubstituteAttributeCreatesMock([Frozen, Substitute] ConcreteType sut)
        {
            Assert.IsAssignableFrom<ConcreteType>(sut);
            Assert.True(sut.GetType().BaseType == typeof(ConcreteType));
        }

        [Theory, AutoNSubstituteData]
        public void CreateWithInterfaceAndFrozenByPropertyNameAttributeFreezesProperty(
            [Frozen(Matching.PropertyName)] string property,
            IInterfaceWithProperty sut)
        {
            Assert.Same(property, sut.Property);
        }

        private class AutoNSubstituteDataAttribute : AutoDataAttribute
        {
            public AutoNSubstituteDataAttribute()
              : base(new Fixture().Customize(new AutoConfiguredNSubstituteCustomization()))
            {
            }
        }
    }
}