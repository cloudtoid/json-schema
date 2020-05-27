namespace Cloudtoid.Json.Schema
{
    using static Contract;

    // the following restrictions can only be applied to Json values of type number
    public class JsonSchemaNumber : JsonSchemaAbstractNumber<double>
    {
        public JsonSchemaNumber(
            double? multipleOf = null,
            double? minimum = null,
            bool isMinimumExlusive = false,
            double? maximum = null,
            bool isMaximumExclusive = false)
            : base(multipleOf, minimum, isMinimumExlusive, maximum, isMaximumExclusive)
        {
            if (multipleOf != null)
                CheckGreaterThan(multipleOf.Value, 0.0, nameof(multipleOf));
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitNumber(this);
    }

    // the following restrictions can only be applied to Json values of type integer
    public class JsonSchemaInteger : JsonSchemaAbstractNumber<long>
    {
        public JsonSchemaInteger(
            long? multipleOf = null,
            long? minimum = null,
            bool isMinimumExlusive = false,
            long? maximum = null,
            bool isMaximumExclusive = false)
            : base(multipleOf, minimum, isMinimumExlusive, maximum, isMaximumExclusive)
        {
            if (multipleOf != null)
                CheckGreaterThan(multipleOf.Value, 0L, nameof(multipleOf));
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitInteger(this);
    }

    public abstract class JsonSchemaAbstractNumber<TValue> : JsonSchemaConstraint
        where TValue : struct
    {
        protected JsonSchemaAbstractNumber(
            TValue? multipleOf = null,
            TValue? minimum = null,
            bool isMinimumExlusive = false,
            TValue? maximum = null,
            bool isMaximumExclusive = false)
        {
            MultipleOf = multipleOf;
            Minimum = minimum;
            IsMinimumExclusive = isMinimumExlusive;
            Maximum = maximum;
            IsMaximumExclusive = isMaximumExclusive;
        }

        /// <summary>
        /// Gets a multiple of a given number to restrict the valid values.
        /// This uses the <c>multipleOf</c> keyword and may only be a positive number.
        /// </summary>
        public virtual TValue? MultipleOf { get; }

        /// <summary>
        /// Gets the minimum possible value of this number.
        /// Depending on the value of <see cref="IsMinimumExclusive"/>, it is either a 'greater than', or a 'greater than or equal to condition'.
        /// </summary>
        public virtual TValue? Minimum { get; }

        public virtual bool IsMinimumExclusive { get; }

        /// <summary>
        /// Gets the maximum possible value of this number.
        /// Depending on the value of <see cref="IsMaximumExclusive"/>, it is either a 'less than', or a 'less than or equal to condition'.
        /// </summary>
        public virtual TValue? Maximum { get; }

        public virtual bool IsMaximumExclusive { get; }
    }
}
