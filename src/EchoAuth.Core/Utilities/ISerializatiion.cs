using Newtonsoft.Json;

namespace EchoAuth.Core.Utilities
{
    public interface ISerializatiion
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string json);
    }

    public class Serialization
    {
        public static readonly Serialization Singleton = new Serialization();

        public string Serialize<T>(T item, string secret)
        {

            return "";
        }
    }
}