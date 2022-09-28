
namespace SmyzeFuncAPI.Helpers
{
    public static class ParserHelper
    {
        public static string SerializeYaml<T>(object input)
        {
            return new YamlDotNet.Serialization.SerializerBuilder().Build().Serialize(input);
        }
        
        public static T DesriazlizeYaml<T>(string input)
        {
            return new YamlDotNet.Serialization.DeserializerBuilder().Build().Deserialize<T>(input);
        }
    }
}
