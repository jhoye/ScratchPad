using System;
using System.Collections.Generic;
using System.Linq;

namespace Scratch.Data.Core.DataModel
{
    internal class ContentType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public ContentType Parent { get; set; }

        public virtual ICollection<ContentType> Children { get; set; }

        public virtual ICollection<Field> Fields { get; set; }

        public ContentType()
        {
            Id = Guid.NewGuid();

            Name = string.Empty;
        }

        public ContentType(IContentType contentType)
        {
            BuildFrom(contentType);
        }

        public void BuildFrom(IContentType contentType)
        {
            Id = contentType.Id ?? (Guid)(contentType.Id = Guid.NewGuid());

            Name = contentType.Name;

            ParentId = contentType.ParentId;

            Fields = contentType.Fields.Select(a => new Field(a)).ToList();
        }

        public void MapTo(IContentType contentType)
        {
            contentType.Id = Id;

            contentType.Name = Name;

            contentType.ParentId = ParentId;

            contentType.Fields = Fields == null 
                ? new List<IField>() 
                : Fields.Select(a => a.ToListItem()).ToList();
        }
    }
}
