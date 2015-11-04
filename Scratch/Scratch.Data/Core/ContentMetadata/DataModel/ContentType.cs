using System;
using System.Linq;
using System.Collections.Generic;

namespace Scratch.Data.Core.ContentMetadata.DataModel
{
    public class ContentType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Field> Fields { get; set; }

        public ContentType()
        {
            Id = Guid.NewGuid();

            Name = string.Empty;

            Fields = new List<Field>();
        }

        public ContentType(IContentType contentType)
        {
            BuildFrom(contentType);
        }

        public void BuildFrom(IContentType contentType)
        {
            Id = contentType.Id ?? (Guid)(contentType.Id = Guid.NewGuid());

            Name = contentType.Name;

            Fields = contentType.Fields.Select(a => new Field(a)).ToList();
        }

        public void MapTo(IContentType contentType)
        {
            contentType.Id = Id;

            contentType.Name = Name;

            contentType.Fields = Fields.Select(a => a.ToListItem()).ToList();
        }
    }
}
