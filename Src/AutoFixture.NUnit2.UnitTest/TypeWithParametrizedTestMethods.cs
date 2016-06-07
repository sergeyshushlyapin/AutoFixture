using NUnit.Framework;

namespace Ploeh.AutoFixture.NUnit2.UnitTest
{
    internal class TypeWithParametrizedTestMethods
    {
        public void MethodWithValuesAttribute([Values(1, -1)] int num)
        {
        }
    }
}