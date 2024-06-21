#nullable disable

using System.Text.Json.Serialization;

namespace CloudTnT.SDK
{
    public class DIDEntity
    {
        [JsonPropertyOrder(0)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }

        [JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string userName { get; set; }

        [JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string uuid { get; set; }

        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string privateKey { get; set; }

        [JsonPropertyOrder(4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string publicKey { get; set; }

        [JsonPropertyOrder(5)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string did { get; set; }

        [JsonPropertyOrder(6)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string idToken { get; set; }

        [JsonPropertyOrder(7)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string didDocument { get; set; }
    }
}
