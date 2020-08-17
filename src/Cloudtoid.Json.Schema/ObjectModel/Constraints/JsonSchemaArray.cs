using System.Collections.Generic;

namespace Cloudtoid.Json.Schema
{
    // the following restrictions can only be applied to JSON values of type array
    public class JsonSchemaArray : JsonSchemaConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaArray"/> class.
        /// </summary>
        /// <param name="item">All array items are validated against this schema.</param>
        /// <param name="minsItems">The minimum number of items in the array instance.</param>
        /// <param name="maxItems">The maximum number of items in the array instance.</param>
        /// <param name="uniqueItems">If this keyword has boolean value <see langword="false"/>, the instance validates successfully.
        ///     If it has boolean value <see langword="true"/>, the instance validates successfully if all of its items are unique.
        /// </param>
        /// <param name="contains">The schema that should be found in the array instance.</param>
        /// <param name="minContains">The minimum number of contains matches in the array instance.</param>
        /// <param name="maxContains">The maximum number of contains matches in the array instance.</param>
        public JsonSchemaArray(
            JsonSchemaSubSchema item,
            uint? minsItems = null,
            uint? maxItems = null,
            bool? uniqueItems = null,
            JsonSchemaSubSchema? contains = null,
            uint? minContains = null,
            uint? maxContains = null)
        {
            SetItem(item);
            MinItems = minsItems;
            MaxItems = maxItems;
            UniqueItems = uniqueItems;
            Contains = contains;
            MinContains = minContains;
            MaxContains = maxContains;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaArray"/> class.
        /// </summary>
        /// <param name="items">Each array item validates against the schema at the same position, if any.</param>
        /// <param name="additionalItems">Each array item past the length of <paramref name="items"/> is validated against this schema.</param>
        /// <param name="minsItems">The minimum number of items in the array instance.</param>
        /// <param name="maxItems">The maximum number of items in the array instance.</param>
        /// <param name="uniqueItems">If this keyword has boolean value <see langword="false"/>, the instance validates successfully.
        ///     If it has boolean value <see langword="true"/>, the instance validates successfully if all of its items are unique.
        /// </param>
        /// <param name="contains">The schema resource that should be found in the array instance.</param>
        /// <param name="minContains">The minimum number of contains matches in the array instance.</param>
        /// <param name="maxContains">The maximum number of contains matches in the array instance.</param>
        public JsonSchemaArray(
            IEnumerable<JsonSchemaSubSchema> items,
            JsonSchemaSubSchema? additionalItems = null,
            uint? minsItems = null,
            uint? maxItems = null,
            bool? uniqueItems = null,
            JsonSchemaSubSchema? contains = null,
            uint? minContains = null,
            uint? maxContains = null)
        {
            SetItems(items, additionalItems);
            MinItems = minsItems;
            MaxItems = maxItems;
            UniqueItems = uniqueItems;
            Contains = contains;
            MinContains = minContains;
            MaxContains = maxContains;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaArray"/> class.
        /// </summary>
        public JsonSchemaArray()
        {
        }

        /// <summary>
        /// Gets or sets the minimum number of items in the array instance.
        /// An array is valid against this value, if the number of items it contains is greater than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MinItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in the array instance.
        /// An array is valid against this value, if the number of items it contains is less than, or equal to, this value.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the value that indicates if all items in this array must be unique.
        /// </summary>
        public virtual bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets a JSON schema resource that should be found in the array instance.
        /// An array is valid against this schema if at least one item is valid against it.
        /// The value of this keyword must be a valid JSON schema (object or boolean).
        /// </summary>
        public virtual JsonSchemaSubSchema? Contains { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of contains matches in the array instance.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MinContains { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of contains matches in the array instance.
        /// This value must be a non-negative integer.
        /// </summary>
        public virtual uint? MaxContains { get; set; }

        /// <summary>
        /// Gets the constraints on array items. Use <see cref="SetItem(JsonSchemaSubSchema?)"/> or
        /// <see cref="SetItems(IEnumerable{JsonSchemaSubSchema}?, JsonSchemaSubSchema?)"/> to change these values.
        /// An array is valid against this value if items are valid against the corresponding schemas provided here. This value can be:
        /// <list type="bullet">
        /// <item>a valid JSON schema (object or boolean), then every item must be valid against this schema. In this case,
        /// this property will be set to an instance of <see cref="JsonSchemaArraySingleItem"/></item>
        /// <item>an array of valid JSON schemas, then each item must be valid against the schema defined at the same position (index).
        /// Items that don’t have a corresponding position (e.g., array contains 5 items and this value only has 3) will be considered
        /// valid, unless the <see cref="JsonSchemaArrayArrayItems.AdditionalItems"/> is not <see langword="null"/> or empty - which will
        /// decide the validity. Also, this property will be set to an instance of <see cref="JsonSchemaArrayArrayItems"/></item>
        /// </list>
        /// </summary>
        public JsonSchemaArrayItems? Items { get; private set; }

        /// <summary>
        /// Sets the constraints on each array item.
        /// <paramref name="items"/> specifies an array of valid JSON schemas that each array item must be valid against the schema defined
        ///     at the same position (index). Items that don’t have a corresponding position (e.g., array contains 5 items and this value only
        ///     has 3) will be considered valid, unless the <paramref name="additionalItems"/> is not <see langword="null"/> or empty - which
        ///     will decide the validity. In this case, <see cref="Items"/> will be set to an instance of <see cref="JsonSchemaArrayArrayItems"/>
        /// </summary>
        public void SetItems(
            IEnumerable<JsonSchemaSubSchema>? items,
            JsonSchemaSubSchema? additionalItems = null)
        {
            if (items is null)
            {
                Items = null;
            }
            else
            {
                var readOnlyItems = items.AsReadOnlyList();
                Items = readOnlyItems.Count == 0 ? null : new JsonSchemaArrayArrayItems(readOnlyItems, additionalItems);
            }
        }

        /// <summary>
        /// Sets the set of constraints that apply to all array items.
        /// </summary>
        /// <param name="item">All array items are validated against this schema, and sets <see cref="Items"/> to an instance of
        ///     <see cref="JsonSchemaArraySingleItem"/>.</param>
        public void SetItem(JsonSchemaSubSchema? item)
        {
            Items = item is null ? null : new JsonSchemaArraySingleItem(item);
        }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArray(this);
    }

    public abstract class JsonSchemaArrayItems
    {
        protected internal abstract void Accept(JsonSchemaVisitor visitor);
    }

    public sealed class JsonSchemaArraySingleItem : JsonSchemaArrayItems
    {
        internal JsonSchemaArraySingleItem(JsonSchemaSubSchema item)
        {
            Item = item;
        }

        public JsonSchemaSubSchema Item { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArraySingleItem(this);
    }

    public sealed class JsonSchemaArrayArrayItems : JsonSchemaArrayItems
    {
        internal JsonSchemaArrayArrayItems(
            IReadOnlyList<JsonSchemaSubSchema> items,
            JsonSchemaSubSchema? additionalItems = null)
        {
            Items = items;
            AdditionalItems = additionalItems;
        }

        public IReadOnlyList<JsonSchemaSubSchema> Items { get; }

        public JsonSchemaSubSchema? AdditionalItems { get; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitArrayArrayItems(this);
    }
}
