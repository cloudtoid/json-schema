namespace Cloudtoid.Json.Schema
{
    using System.Collections.Generic;

    /// <summary>
    /// This represents all Json Schema elements except for the root element which is <see cref="JsonSchema"/>.
    /// </summary>
    public class JsonSchemaChildElement : JsonSchemaElement
    {
        public JsonSchemaChildElement(
            IReadOnlyList<JsonSchemaConstraint> constraints,
            JsonSchemaMetadata? metadata = null)
            : base(constraints, metadata)
        {
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitChildElement(this);
    }
}
