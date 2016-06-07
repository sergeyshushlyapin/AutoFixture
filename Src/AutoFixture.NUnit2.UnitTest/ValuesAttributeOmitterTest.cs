using System;
using NUnit.Framework;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.NUnit2.UnitTest
{
    public class ValuesAttributeOmitterTest
    {
        [Test]
        public void SutIsSpecimenBuilder()
        {
            var sut = new ValuesAttributeOmitter();
            Assert.IsInstanceOf<ISpecimenBuilder>(sut);
        }

        [Test]
        public void CreateWithNullRequestThrows()
        {
            var dummyContext = new DelegatingSpecimenContext();
            var sut = new ValuesAttributeOmitter();
            var ex = Assert.Throws<ArgumentNullException>(() =>
                sut.Create(null, dummyContext));
            Assert.AreEqual("request", ex.ParamName);
        }

        [Test]
        public void CreateWithNonCustomAttributeProviderRequestReturnsNoSpecimen()
        {
            var dummyRequest = new object();
            var dummyContext = new DelegatingSpecimenContext();
            var sut = new ValuesAttributeOmitter();

            var result = sut.Create(dummyRequest, dummyContext);

            Assert.IsInstanceOf<NoSpecimen>(result);
        }

        [Test]
        public void CreateWithNonValuesAttributeRequestReturnsNoSpecimen()
        {
            var request = new FakeCustomAttributeProvider();
            var dummyContext = new DelegatingSpecimenContext();
            var sut = new ValuesAttributeOmitter();

            var result = sut.Create(request, dummyContext);

            Assert.IsInstanceOf<NoSpecimen>(result);
        }

        [Test]
        public void CreateWithValuesAttributeRequestReturnsOmitSpecimen()
        {
            var providedAttributes = new[] { new ProvidedAttribute(new ValuesAttribute(), false) };
            var request = new FakeCustomAttributeProvider(providedAttributes);
            var dummyContext = new DelegatingSpecimenContext();
            var sut = new ValuesAttributeOmitter();

            var result = sut.Create(request, dummyContext);

            Assert.IsInstanceOf<OmitSpecimen>(result);
        }
    }
}