namespace Scratch.Data
{
    public interface ICache
    {
        string Get(string slug);

        void Save(string slug, string content);

        void Delete(string slug);
    }
}
