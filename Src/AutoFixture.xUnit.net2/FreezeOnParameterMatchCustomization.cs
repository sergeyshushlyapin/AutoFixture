using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.Xunit2
{
    internal class FreezeOnParameterMatchCustomization : FreezeOnMatchCustomization
    {
        public FreezeOnParameterMatchCustomization(
            ParameterInfo parameter,
            IRequestSpecification matcher)
            : base(parameter.ParameterType, matcher)
        {
            this.Request = parameter;
        }
    }
}