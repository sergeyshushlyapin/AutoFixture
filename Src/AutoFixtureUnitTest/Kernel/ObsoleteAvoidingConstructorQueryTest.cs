using System;
using System.Linq;
using Ploeh.AutoFixture.Kernel;
using Ploeh.TestTypeFoundation;
using Xunit;

namespace Ploeh.AutoFixtureUnitTest.Kernel
{
    public class ObsoleteAvoidingConstructorQueryTest
    {
        [Fact]
        public void SutIsMethodQuery()
        {
            var sut = new ObsoleteAvoidingConstructorQuery();
            Assert.IsAssignableFrom<IMethodQuery>(sut);
        }

        [Fact]
        public void SelectMethodsFromNullTypeThrows()
        {
            var sut = new ObsoleteAvoidingConstructorQuery();
            Assert.Throws<ArgumentNullException>(() => sut.SelectMethods(null));
        }

        [Fact]
        public void SelectMethodsReturnsSourceQueryMethodsOrderedByObsoleteAttribute()
        {
            var typeWithObsoleteConstructor = typeof(TypeWithObsoleteModestConstructor);
            var expectedConstructors = from ci in typeWithObsoleteConstructor.GetConstructors()
                                       let attributes = ci.GetCustomAttributes(typeof(ObsoleteAttribute), false)
                                       orderby attributes.Length ascending
                                       select new ConstructorMethod(ci) as IMethod;
            var sut = new ObsoleteAvoidingConstructorQuery();

            var result = sut.SelectMethods(typeWithObsoleteConstructor);

            Assert.True(expectedConstructors.SequenceEqual(result));
        }
    }
}