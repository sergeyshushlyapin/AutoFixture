using System;
using System.Globalization;

namespace Ploeh.AutoFixture
{
    /// <summary>
    /// An <see cref="IReflectionElement"/> representing a <see cref="System.Type"/>.
    /// </summary>
    public class TypeElement : IReflectionElement
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> instance this element represents.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "The name follows a consistent pattern with the other reflection elements, and most users will understand the distiction between 'GetType()' and 'Type'.")]
        public Type Type { get; private set; }

        /// <summary>
        /// Constructs a new instance of the <see cref="TypeElement"/> which represents
        /// the specified <see cref="System.Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="System.Type"/> this element represents.</param>
        public TypeElement(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            this.Type = type;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object" />, is equal to
        /// this instance.
        /// </summary>
        /// <param name="obj">The <see cref="Object" /> to compare with this
        /// instance.</param>
        /// <returns>
        /// <see langword="true" /> if the specified <see cref="Object" /> is
        /// equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Two instances of <see cref="TypeElement" /> are considered to
        /// be equal if their <see cref="Type" /> values are equal.
        /// </para>
        /// </remarks>
        public override bool Equals(object obj)
        {
            var other = obj as TypeElement;
            if (other == null)
                return false;

            return object.Equals(this.Type, other.Type);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing
        /// algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Type.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the <see cref="Type"/>
        /// suitable for development / debugging display purposes.
        /// </summary>
        /// <returns>The string representation of the contained
        /// <see cref="Type"/></returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.CurrentCulture, "[[{0}]] ({1})", this.Type, "type");
        }
    }
}
