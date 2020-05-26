namespace Cloudtoid.Json.Schema
{
    public sealed partial class JsonSchemaWriter
    {
        protected internal override void VisitArray(JsonSchemaArray constraint)
        {
            base.VisitArray(constraint);

            if (constraint.MinItems != null)
                writer.WriteNumber(Keys.MinItems, constraint.MinItems.Value);

            if (constraint.MaxItems != null)
                writer.WriteNumber(Keys.MaxItems, constraint.MaxItems.Value);

            if (constraint.UniqueItems != null)
                writer.WriteBoolean(Keys.UnniqueItems, constraint.UniqueItems.Value);
        }

        protected override void VisitArrayContains(JsonSchemaChildElement constraint)
        {
            writer.WriteStartObject(Keys.Contains);
            base.VisitArrayContains(constraint);
            writer.WriteEndObject();
        }

        protected internal override void VisitArraySingleItem(JsonSchemaArraySingleItem item)
        {
            writer.WriteStartObject(Keys.Items);
            base.VisitArraySingleItem(item);
            writer.WriteEndObject();
        }

        protected internal override void VisitArrayArrayItems(JsonSchemaArrayArrayItems items)
        {
            writer.WriteStartArray(Keys.Items);
            base.VisitArrayArrayItems(items);
            writer.WriteEndArray();
        }

        protected internal override void VisitArrayArrayItem(JsonSchemaChildElement item)
        {
            writer.WriteStartObject(Keys.Items);
            base.VisitArrayArrayItem(item);
            writer.WriteEndObject();
        }

        protected override void VisitArrayAdditionalItems(JsonSchemaChildElement additionalItems)
        {
            writer.WriteStartObject(Keys.AdditionalItems);
            base.VisitArrayAdditionalItems(additionalItems);
            writer.WriteEndObject();
        }
    }
}
