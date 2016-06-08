namespace Ploeh.AutoFixture.Kernel
{
    public class DefaultTypeValueGenerator:ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var omitRequest = request as OmitSpecimen;
            if (omitRequest != null)
            {
            }

            return new NoSpecimen();
        }
    }
}