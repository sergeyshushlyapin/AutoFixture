using System;

namespace Ploeh.AutoFixture.NUnit2.UnitTest
{
    internal class ProvidedAttribute
    {
        public ProvidedAttribute(Attribute attribute, bool inherited)
        {
            this.Attribute = attribute;
            this.Inherited = inherited;
        }

        public Attribute Attribute { get; }

        public bool Inherited { get; }
    }
}
