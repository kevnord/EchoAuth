namespace EchoAuth.Core.Utilities
{
    public interface ISerializatiion
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string json);
    }
}