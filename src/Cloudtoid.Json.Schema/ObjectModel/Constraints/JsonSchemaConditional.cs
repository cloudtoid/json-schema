﻿using static Cloudtoid.Contract;

namespace Cloudtoid.Json.Schema
{
    public class JsonSchemaConditional : JsonSchemaConstraint
    {
        public JsonSchemaConditional(
            JsonSchemaConstraint @if,
            JsonSchemaConstraint? then = null,
            JsonSchemaConstraint? @else = null)
        {
            If = CheckValue(@if, nameof(@if));
            Check(then != null || @else != null, "Either 'then' or 'else' clause should be set.");
            Then = then;
            Else = @else;
        }

        public JsonSchemaConditional()
        {
        }

        public JsonSchemaConstraint? If { get; set; }

        public JsonSchemaConstraint? Then { get; set; }

        public JsonSchemaConstraint? Else { get; set; }

        protected internal override void Accept(JsonSchemaVisitor visitor)
            => visitor.VisitConditional(this);
    }
}
