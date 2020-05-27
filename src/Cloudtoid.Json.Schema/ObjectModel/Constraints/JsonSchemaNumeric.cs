namespace Cloudtoid.Json.Schema
{
    using static Contract;

    /// <summary>
    /// Provides the base class for validation rules for numeric instances (Integer and Number)
    /// </summary>
    public abstract class JsonSchemaNumeric<TValue> : JsonSchemaConstraint
        where TValue : struct
    {
        protected JsonSchemaNumeric(
            TValue? multipleOf,
            TValue? minimum,
            bool isMinimumExlusive,
            TValue? maximum,
            bool isMaximumExclusive)
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

        /// <summary>
        /// Gets if the <see cref="Minimum"/> is exclusive.
        /// </summary>
        public virtual bool IsMinimumExclusive { get; }

        /// <summary>
        /// Gets the maximum possible value of this number.
        /// Depending on the value of <see cref="IsMaximumExclusive"/>, it is either a 'less than', or a 'less than or equal to condition'.
        /// </summary>
        public virtual TValue? Maximum { get; }

        /// <summary>
        /// Gets if the <see cref="Maximum"/> is exclusive.
        /// </summary>
        public virtual bool IsMaximumExclusive { get; }
    }

    /// <summary>
    /// A set of validation rules for number instances.
    /// </summary>
    public class JsonSchemaNumeric : JsonSchemaNumeric<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaNumeric"/> class.
        /// </summary>
        /// <param name="multipleOf">A numeric instance is valid only if division by this keyword's value results in an integer.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="isMinimumExlusive">Indicates if the <paramref name="minimum"/> is exclusive.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="isMaximumExclusive">Indicates if the <paramref name="maximum"/> is exclusive.</param>
        public JsonSchemaNumeric(
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

    /// <summary>
    /// A set of validation rules for integer instances.
    /// </summary>
    public class JsonSchemaInteger : JsonSchemaNumeric<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaInteger"/> class.
        /// </summary>
        /// <param name="multipleOf">A numeric instance is valid only if division by this keyword's value results in an integer.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="isMinimumExlusive">Indicates if the <paramref name="minimum"/> is exclusive.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="isMaximumExclusive">Indicates if the <paramref name="maximum"/> is exclusive.</param>
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
}
