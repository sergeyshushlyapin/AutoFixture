using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.NUnit2
{
    /// <summary>
    /// Omits the test method parameters decorated with the NUnit's <see cref="ValuesAttribute"/>.
    /// </summary>
    public class ValuesAttributeOmitter : ISpecimenBuilder
    {
        /// <summary>
        /// Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// An <see cref="OmitSpecimen"/> instance if <paramref name="request" /> is decorated 
        /// with <see cref="ValuesAttribute" />; otherwise a <see cref="NoSpecimen" /> instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">request</exception>
        public object Create(object request, ISpecimenContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var attributeProvider = request as ICustomAttributeProvider;
            if (attributeProvider == null)
            {
                return new NoSpecimen();
            }

            var attributes = attributeProvider.GetCustomAttributes(typeof(ValuesAttribute), false);
            if (!attributes.Any())
            {
                return new NoSpecimen();
            }

            return new OmitSpecimen();
        }
    }
}