namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitObject(JsonSchemaObject constraint) => base.VisitObject(constraint);

        protected override void VisitObjectProperty(string name, JsonSchemaChildElement property) => base.VisitObjectProperty(name, property);

        protected override void VisitObjectPatternProperty(string name, JsonSchemaChildElement property) => base.VisitObjectPatternProperty(name, property);

        protected override void VisitObjectAdditionalProperties(JsonSchemaChildElement element) => base.VisitObjectAdditionalProperties(element);

        protected override void VisitObjectPropertyNames(JsonSchemaString constraint) => base.VisitObjectPropertyNames(constraint);
    }
}
