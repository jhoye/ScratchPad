namespace Scratch.Data.Core
{
    public interface ISettings
    {
        void Load(IDatabaseSettings databaseSettings);

        void Load(GenericSettings genericSettings);

        void Save(GenericSettings genericSettings);
    }
}
