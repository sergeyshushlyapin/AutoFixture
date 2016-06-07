using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.NUnit2
{
    /// <summary>
    /// Determines whether a request is a request for an test method parameter
    /// decorated with the <see cref="ValuesAttribute"/>.
    /// </summary>
    public class ValuesParameterSpecification : IRequestSpecification
    {
        /// <summary>
        /// Evaluates a request for a specimen to determine whether it's a request for a
        /// test method parameter decorated with the <see cref="ValuesAttribute"/>.
        /// </summary>
        /// <param name="request">The specimen request.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="request"/> is a request for a
        /// test method parameter decorated with the <see cref="ValuesAttribute"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsSatisfiedBy(object request)
        {
            var attributeProvider = request as ICustomAttributeProvider;
            if (attributeProvider == null)
            {
                return false;
            }

            var attributes = attributeProvider.GetCustomAttributes(typeof(ValuesAttribute), false);
            return attributes.Any();
        }
    }
}