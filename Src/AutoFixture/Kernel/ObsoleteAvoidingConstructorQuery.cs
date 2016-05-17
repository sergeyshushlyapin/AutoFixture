using System;
using System.Collections.Generic;
using System.Linq;

namespace Ploeh.AutoFixture.Kernel
{
    public class ObsoleteAvoidingConstructorQuery : IMethodQuery
    {
        public IEnumerable<IMethod> SelectMethods(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return from ci in type.GetConstructors()
                   let attributes = ci.GetCustomAttributes(typeof(ObsoleteAttribute), false)
                   let parameters = ci.GetParameters()
                   orderby attributes.Length ascending, parameters.Length ascending
                   select new ConstructorMethod(ci) as IMethod;
        }
    }
}