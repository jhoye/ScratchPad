using System;
using System.Linq;
using Scratch.Data.Core.ContentMetadata.DataModel;

namespace Scratch.Data.Core.ContentMetadata
{
    public class ContentTypes : DataBase, IContentTypes
    {
        public void Save(IContentType contentType)
        {
            if (contentType.Id.HasValue)
            {
                // update
                var contentTypeRecord = GetContentTypeRecord(contentType);

                contentTypeRecord.BuildFrom(contentType);
            }
            else
            {
                // create
                var contentTypeRecord = new ContentType(contentType);

                DataModel.ContentMetadata.ContentTypes.Add(contentTypeRecord);
            }

            DataModel.ContentMetadata.SaveChanges();
        }

        public void Load(IContentType contentType)
        {
            var contentTypeRecord = GetContentTypeRecord(contentType);

            contentTypeRecord.MapTo(contentType);
        }

        public void Delete(IContentType contentType)
        {
            var contentTypeRecord = GetContentTypeRecord(contentType);

            DataModel.ContentMetadata.ContentTypes.Remove(contentTypeRecord);

            DataModel.ContentMetadata.SaveChanges();
        }

        private ContentType GetContentTypeRecord(Guid id)
        {
            return DataModel.ContentMetadata.ContentTypes.SingleOrDefault(a => a.Id == id);
        }

        private ContentType GetContentTypeRecord(IContentType contentType)
        {
            if (!contentType.Id.HasValue)
            {
                throw new DataException("No Id was specified for the content type.");
            }

            var record = GetContentTypeRecord(contentType.Id.Value);

            if (record == null)
            {
                throw new DataException("An invalid Id was specified for the content type.");
            }

            return record;
        }
    }
}
