using Scratch.Data.Content.DataModel;
using Scratch.Data.Core.DataModel;

namespace Scratch.Data
{
    public abstract class DataBase : DependentBase
    {
        private CoreData _coreDataInstance;

        private ContentData _contentDataInstance;

        internal CoreData CoreData
        {
            get
            {
                return _coreDataInstance 
                    ?? (_coreDataInstance = new CoreData(
                        Components.Configuration.ConnectionString));
            }
        }

        internal ContentData ContentData
        {
            get { return _contentDataInstance 
                ?? (_contentDataInstance = new ContentData(
                    Components.Configuration.ConnectionString));
            }
        }
    }
}
