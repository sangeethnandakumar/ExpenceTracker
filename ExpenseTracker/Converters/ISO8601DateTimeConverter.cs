using Application.Constants;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Converters
{
    public class ISO8601DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString()!).ToUniversalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture));
        }
    }
}
