namespace Cloudtoid.Json.Schema
{
    public abstract class JsonSchemaConstraint
    {
        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }
}
