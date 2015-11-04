using Scratch.Data.Content.DataModel;
using Scratch.Data.Core.ContentMetadata.DataModel;
using Scratch.Data.Core.SystemDataModel.DataModel;

namespace Scratch.Data
{
    public class DataModel
    {
        private ContentMetadata _contentMetadataInstance;
        private SystemData _systemDataInstance;
        private ContentData _contentDataInstance;

        public ContentMetadata ContentMetadata
        {
            get { return _contentMetadataInstance ?? (_contentMetadataInstance = new ContentMetadata()); }
        }

        public SystemData SystemData
        {
            get { return _systemDataInstance ?? (_systemDataInstance = new SystemData()); }
        }

        public ContentData ContentData
        {
            get { return _contentDataInstance ?? (_contentDataInstance = new ContentData()); }
        }
    }
}
