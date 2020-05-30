namespace Cloudtoid.Json.Schema.UnitTests
{
    using System;
    using System.Text.Json;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class JsonSchemaWriterTests
    {
        [TestMethod]
        public void MetadataTests()
        {
            var schema = new JsonSchema(
                id: new Uri("http://example.com/number.json#"),
                constraints: new JsonSchemaConstraint[]
                {
                    new JsonSchemaTypes(new[] { JsonSchemaDataType.Number, JsonSchemaDataType.Integer }),
                    new JsonSchemaNumeric(
                        12.5,
                        minimum: 10.5,
                        isMinimumExlusive: true,
                        maximum: 12.5)
                },
                title: "Test if it is a number",
                description: "A value is considered number if it is an integer or a float.",
                comment: "This is used for testing",
                @default: new JsonSchemaConstant<int?>(10),
                examples: new JsonSchemaConstant[]
                {
                    10,
                    20.5,
                    "test",
                    JsonSchemaConstant.Null,
                    new JsonSchemaConstant<dynamic>(new
                    {
                        Prop1 = "prop1",
                        Prop2 = "prop2"
                    }),
                    new JsonSchemaConstant<int?>(10)
                });

            var result = JsonSchemaSerializer.Serialize(schema, new JsonSerializerOptions { WriteIndented = true });

            result.Should().Be("a");
        }
    }
}
