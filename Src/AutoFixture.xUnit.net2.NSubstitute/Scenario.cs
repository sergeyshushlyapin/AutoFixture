using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Ploeh.TestTypeFoundation;
using Xunit;

namespace AutoFixture.xUnit.net2.NSubstitute
{
    public class Scenario
    {
        [Theory, AutoNSubstituteData]
        public void CreateWithConcreteTypeAndSubstituteAttributeCreatesMock(
            [Substitute] ConcreteType sut)
        {
            Assert.IsAssignableFrom<ConcreteType>(sut);
            Assert.True(sut.GetType().BaseType == typeof(ConcreteType));
        }

        [Theory(Skip = "TBI"), AutoNSubstituteData]
        public void CreateWithFrozenConcreteTypeAndSubstituteAttributeCreatesMock(
            [Frozen, Substitute] ConcreteType sut)
        {
            Assert.IsAssignableFrom<ConcreteType>(sut);
            Assert.True(sut.GetType().BaseType == typeof(ConcreteType));
        }

        [Theory(Skip = "Issue 715"), AutoNSubstituteData]
        public void GuardClauseAssertionWithMockedTypeWithAbstractMethodDoesNotThrow(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(
                typeof(AbstractTypeWithAbstractMethod));
        }

        public abstract class AbstractTypeWithAbstractMethod
        {
            public abstract void Method(object arg);
        }

        [Theory, AutoNSubstituteData]
        public void GuardClauseAssertionWithMockedTypeWithVirtualMethodDoesNotThrow(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(
                typeof(AbstractTypeWithGuardedVirtualMethod));
        }

        public abstract class AbstractTypeWithGuardedVirtualMethod
        {
            public virtual void Method(object arg)
            {
                if (arg == null)
                    throw new ArgumentNullException();
            }
        }

        private class AutoNSubstituteDataAttribute : AutoDataAttribute
        {
            public AutoNSubstituteDataAttribute()
                : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
            {
            }
        }
    }
}