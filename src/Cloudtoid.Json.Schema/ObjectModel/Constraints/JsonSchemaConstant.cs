namespace Cloudtoid.Json.Schema
{
    using System;

    public abstract class JsonSchemaConstant : JsonSchemaConstraint
    {
        public static readonly JsonSchemaConstant Null = new JsonSchemaConstant<object?>(null);

        protected JsonSchemaConstant(Type valueType)
        {
            ValueType = valueType;
        }

        public Type ValueType { get; }

        protected internal abstract bool IsNull { get; }

        public static implicit operator JsonSchemaConstant(bool value)
            => new JsonSchemaConstant<bool>(value);

        public static implicit operator JsonSchemaConstant(bool? value)
            => new JsonSchemaConstant<bool?>(value);

        public static implicit operator JsonSchemaConstant(int value)
            => new JsonSchemaConstant<int>(value);

        public static implicit operator JsonSchemaConstant(int? value)
            => new JsonSchemaConstant<int?>(value);

        public static implicit operator JsonSchemaConstant(uint value)
            => new JsonSchemaConstant<uint>(value);

        public static implicit operator JsonSchemaConstant(uint? value)
            => new JsonSchemaConstant<uint?>(value);

        public static implicit operator JsonSchemaConstant(long value)
            => new JsonSchemaConstant<long>(value);

        public static implicit operator JsonSchemaConstant(long? value)
            => new JsonSchemaConstant<long?>(value);

        public static implicit operator JsonSchemaConstant(ulong value)
            => new JsonSchemaConstant<ulong>(value);

        public static implicit operator JsonSchemaConstant(ulong? value)
            => new JsonSchemaConstant<ulong?>(value);

        public static implicit operator JsonSchemaConstant(short value)
            => new JsonSchemaConstant<short>(value);

        public static implicit operator JsonSchemaConstant(short? value)
            => new JsonSchemaConstant<short?>(value);

        public static implicit operator JsonSchemaConstant(ushort value)
            => new JsonSchemaConstant<ushort>(value);

        public static implicit operator JsonSchemaConstant(ushort? value)
            => new JsonSchemaConstant<ushort?>(value);

        public static implicit operator JsonSchemaConstant(decimal value)
            => new JsonSchemaConstant<decimal>(value);

        public static implicit operator JsonSchemaConstant(decimal? value)
            => new JsonSchemaConstant<decimal?>(value);

        public static implicit operator JsonSchemaConstant(double value)
            => new JsonSchemaConstant<double>(value);

        public static implicit operator JsonSchemaConstant(double? value)
            => new JsonSchemaConstant<double?>(value);

        public static implicit operator JsonSchemaConstant(float value)
            => new JsonSchemaConstant<float>(value);

        public static implicit operator JsonSchemaConstant(float? value)
            => new JsonSchemaConstant<float?>(value);

        public static implicit operator JsonSchemaConstant(string value)
            => new JsonSchemaConstant<string>(value);

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitConstant(this);

        protected internal abstract object? GetValue();
    }

    public class JsonSchemaConstant<TValue> : JsonSchemaConstant
    {
        public JsonSchemaConstant(TValue value)
            : base(typeof(TValue))
        {
            Value = value;
        }

        public virtual TValue Value { get; }

        protected internal override bool IsNull
            => !typeof(TValue).IsValueType && Value is null;

        public static implicit operator JsonSchemaConstant<TValue>(TValue value)
            => new JsonSchemaConstant<TValue>(value);

        protected internal override object? GetValue() => Value;
    }
}
