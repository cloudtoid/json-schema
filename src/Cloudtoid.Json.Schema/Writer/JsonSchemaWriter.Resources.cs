using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected override void VisitResource(JsonSchemaResource resource)
        {
            if (resource.Id != null)
                writer.WriteString(Keys.Id, resource.Id.ToString());

            if (resource.Anchor != null)
                writer.WriteString(Keys.Anchor, resource.Anchor);

            if (resource.RecursiveAnchor != null)
                writer.WriteBoolean(Keys.RecursiveAnchor, resource.RecursiveAnchor.Value);

            if (resource.Title != null)
                writer.WriteString(Keys.Title, resource.Title);

            if (resource.Description != null)
                writer.WriteString(Keys.Description, resource.Description);

            if (resource.Default != null)
                WriteDefault(resource.Default);

            if (resource.Deprecated != null)
                writer.WriteBoolean(Keys.Deprecated, resource.Deprecated.Value);

            if (resource.ReadOnly != null)
                writer.WriteBoolean(Keys.ReadOnly, resource.ReadOnly.Value);

            if (resource.WriteOnly != null)
                writer.WriteBoolean(Keys.WriteOnly, resource.WriteOnly.Value);

            if (resource.Examples != null)
                WriteExamples(resource.Examples);

            if (resource.Comment != null)
                writer.WriteString(Keys.Comment, resource.Comment);

            base.VisitResource(resource);
        }

        protected internal override void VisitSchema(JsonSchema resource)
        {
            writer.WriteStartObject();
            WriteSchemaVersion(resource.Version);
            base.VisitSchema(resource);
            writer.WriteEndObject();
        }

        protected internal override void VisitSubschema(JsonSchemaSubSchema resource)
        {
            writer.WriteStartObject();
            base.VisitSubschema(resource);
            writer.WriteEndObject();
        }

        private void WriteDefault(JsonSchemaConstant @default)
        {
            writer.WritePropertyName(Keys.Default);
            WriteConstant(@default);
        }

        private void WriteExamples(IList<JsonSchemaConstant> examples)
        {
            if (examples.Count == 0)
                return;

            writer.WriteStartArray(Keys.Examples);

            foreach (var example in examples)
                WriteConstant(example);

            writer.WriteEndArray();
        }

        private void WriteSchemaVersion(JsonSchemaVersion version)
        {
            var uri = version.GetSchemaUri();
            writer.WriteString(Keys.Schema, uri);
        }

        protected override void VisitDefinitions(IDictionary<string, JsonSchemaSubSchema> resources)
        {
            writer.WriteStartObject(Keys.Defs);
            base.VisitDefinitions(resources);
            writer.WriteEndObject();
        }

        protected override void VisitDefinition(string name, JsonSchemaSubSchema resource)
        {
            writer.WriteStartObject(name);
            base.VisitDefinition(name, resource);
            writer.WriteEndObject();
        }

        protected override void VisitConstraints(JsonSchemaConstraints constraints)
        {
            var newConstraints = constraints.NewConstraints;
            if (newConstraints != null)
            {
                foreach (var constraint in newConstraints)
                    Visit(constraint);
            }
        }
    }
}
