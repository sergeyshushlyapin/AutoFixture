using System;

namespace Ploeh.TestTypeFoundation
{
    public class TypeWithObsoleteModestConstructor
    {
        [Obsolete]
        public TypeWithObsoleteModestConstructor()
        {
        }

        public TypeWithObsoleteModestConstructor(object obj)
        {
        }
    }
}