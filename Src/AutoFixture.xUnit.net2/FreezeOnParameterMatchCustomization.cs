using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.Xunit2
{
    /// <summary>
    /// A customization that freezes specimens using the <see cref="ParameterInfo"/>
    /// and uses them to satisfy requests that match a set of criteria.
    /// </summary>
    /// <remarks>
    /// That allows to use the <see cref="ParameterInfo"/> custom attributes
    /// (such as <see cref="StringLengthAttribute"/>) in the specimen creation pipeline.
    /// </remarks>
    internal class FreezeOnParameterMatchCustomization : ICustomization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FreezeOnParameterMatchCustomization"/> class.
        /// </summary>
        /// <param name="parameter">
        /// The <see cref="ParameterInfo"/> used to describe a specimen to freeze.
        /// </param>
        /// <param name="matcher">
        /// The <see cref="IRequestSpecification"/> used to match the requests
        /// that will be satisfied by the frozen specimen.
        /// </param>
        public FreezeOnParameterMatchCustomization(
            ParameterInfo parameter,
            IRequestSpecification matcher)
        {
            this.Parameter = parameter;
            this.Matcher = matcher;
        }

        /// <summary>
        /// The <see cref="ParameterInfo"/> described a specimen to freeze.
        /// </summary>
        public ParameterInfo Parameter { get; }

        /// <summary>
        /// The <see cref="IRequestSpecification"/> used to match the requests
        /// that will be satisfied by the frozen specimen.
        /// </summary>
        public IRequestSpecification Matcher { get; }

        /// <summary>
        /// Customizes the specified fixture.
        /// </summary>
        /// <param name="fixture">The fixture to customize.</param>
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Insert(
                0,
                new FilteringSpecimenBuilder(
                    FreezeTargetType(fixture),
                    this.Matcher));
        }

        private ISpecimenBuilder FreezeTargetType(IFixture fixture)
        {
            var context = new SpecimenContext(fixture);
            var specimen = context.Resolve(this.Parameter);
            return new FixedBuilder(specimen);
        }
    }
}