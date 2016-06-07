using NUnit.Framework;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.NUnit2.UnitTest
{
    public class ValuesParameterSpecificationTest
    {
        [Test]
        public void SutIsRequestSpecification()
        {
            var sut = new ValuesParameterSpecification();
            Assert.IsInstanceOf<IRequestSpecification>(sut);
        }

        [Test]
        public void IsSatisfiedByNullReturnsFalse()
        {
            var sut = new ValuesParameterSpecification();
            var result = sut.IsSatisfiedBy(null);
            Assert.False(result);
        }

        [Test]
        public void IsSatisfiedByNonCustomAttributeProviderReturnsFalse()
        {
            var dummyRequest = new object();
            var sut = new ValuesParameterSpecification();

            var result = sut.IsSatisfiedBy(dummyRequest);

            Assert.False(result);
        }

        [Test]
        public void IsSatisfiedByNonValuesAttributeRequestReturnsFalse()
        {
            var request = new FakeCustomAttributeProvider();
            var sut = new ValuesParameterSpecification();

            var result = sut.IsSatisfiedBy(request);

            Assert.False(result);
        }

        [Test]
        public void IsSatisfiedByValuesAttributeRequestReturnsTrue()
        {
            var providedAttributes = new[] { new ProvidedAttribute(new ValuesAttribute(), false) };
            var request = new FakeCustomAttributeProvider(providedAttributes);
            var sut = new ValuesParameterSpecification();

            var result = sut.IsSatisfiedBy(request);

            Assert.True(result);
        }
    }
}