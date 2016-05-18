using System;

namespace Ploeh.TestTypeFoundation
{
    public class TypeWithThrowingObsoleteConstructor
    {
        [Obsolete]
        public TypeWithThrowingObsoleteConstructor()
        {
            throw new NotSupportedException("This constructor is marked as [Obsolete] and should not be called by AutoFixture.");
        }

        public TypeWithThrowingObsoleteConstructor(object obj)
        {
        }
    }
}