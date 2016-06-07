using System;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.NUnit2.UnitTest
{
    internal class DelegatingSpecimenContext : ISpecimenContext
    {
        public DelegatingSpecimenContext()
        {
            this.OnResolve = r => null;
        }

        public object Resolve(object request)
        {
            return this.OnResolve(request);
        }

        internal Func<object, object> OnResolve { get; set; }
    }
}
