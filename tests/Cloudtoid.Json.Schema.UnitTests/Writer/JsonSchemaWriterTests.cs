namespace Cloudtoid.Json.Schema.UnitTests
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class JsonSchemaWriterTests
    {
        [TestMethod]
        public void MetadataTests()
        {
            var schema = new JsonSchema(
                JsonSchemaConstraints.Empty,
                new JsonSchemaMetadata(
                    id: new Uri("http://example.com/number.json#"),
                    title: "Test if it is a number",
                    description: "A value is considered number if it is an integer or a float.",
                    comment: "used for testing",
                    @default: 10));

            var result = JsonSchemaSerializer.Serialize(schema);

            result.Should().Be("a");
        }
    }
}
