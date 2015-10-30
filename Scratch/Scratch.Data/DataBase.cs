namespace Scratch.Data
{
    public abstract class DataBase
    {
        protected readonly DataModel DataModel;

        protected DataBase()
        {
            DataModel = new DataModel();
        }
    }
}
