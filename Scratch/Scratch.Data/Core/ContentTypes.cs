using System;
using System.Collections.Generic;
using System.Linq;
using Scratch.Data.Core.DataModel;

namespace Scratch.Data.Core
{
    public class ContentTypes : DataBase, IContentTypes
    {
        public void Load(IContentTypeHierarchy contentTypesHierarchy)
        {
            contentTypesHierarchy.ContentTypes = GetChildren(CoreData.ContentTypes.ToList());
        }

        public void Load(IContentType contentType)
        {
            var contentTypeRecord = GetContentTypeRecord(contentType);

            contentTypeRecord.MapTo(contentType);
        }

        public void Load(IField field)
        {
            var fieldRecord = GetFieldRecord(field);

            fieldRecord.MapTo(field);
        }

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

                CoreData.ContentTypes.Add(contentTypeRecord);
            }

            CoreData.SaveChanges();
        }

        public void Save(IField field)
        {
            if (field.Id.HasValue)
            {
                // update
                var fieldRecord = GetFieldRecord(field);

                fieldRecord.BuildFrom(field);
            }
            else
            {
                // create
                var fieldRecord = new Field(field);

                CoreData.Fields.Add(fieldRecord);
            }

            CoreData.SaveChanges();
        }

        public void Delete(IContentType contentType)
        {
            var contentTypeRecord = GetContentTypeRecord(contentType);

            CoreData.ContentTypes.Remove(contentTypeRecord);

            CoreData.SaveChanges();
        }

        public void Delete(IField field)
        {
            var fieldRecord = GetFieldRecord(field);

            fieldRecord.MapTo(field);

            CoreData.Fields.Remove(fieldRecord);

            CoreData.SaveChanges();
        }

        private ContentType GetContentTypeRecord(Guid id)
        {
            return CoreData.ContentTypes
                .Include("Fields")
                .SingleOrDefault(a => a.Id == id);
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

        private List<ContentsTypeHierarchyListItem> GetChildren(List<ContentType> contentTypes, Guid? parentId = null)
        {
            return contentTypes
                .Where(a => a.ParentId == parentId)
                .Select(a => new ContentsTypeHierarchyListItem
                {
                    Id = a.Id,
                    Name = a.Name,
                    Children = GetChildren(contentTypes, a.Id)
                })
                .ToList();
        }

        private Field GetFieldRecord(IField field)
        {
            if (!field.Id.HasValue)
            {
                throw new DataException("No Id was specified for the field.");
            }

            var record = CoreData.Fields.SingleOrDefault(a => a.Id == field.Id.Value);

            if (record == null)
            {
                throw new DataException("An invalid Id was specified for the field.");
            }

            return record;
        }
    }
}
