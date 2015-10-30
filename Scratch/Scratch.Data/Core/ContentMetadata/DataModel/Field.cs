using System;

namespace Scratch.Data.Core.ContentMetadata.DataModel
{
    public class Field
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsNullable { get; set; }

        public int FieldType { get; set; }

        public ContentType ContentType { get; set; }

        public Field()
        {
        }

        public Field(IField field)
        {
            BuildFrom(field);
        }

        public void BuildFrom(IField field)
        {
            Id = field.Id ?? (Guid)(field.Id = Guid.NewGuid());

            Name = field.Name;

            IsNullable = field.IsNullable;

            FieldType = (int) field.FieldType;
        }

        public void MapTo(IField field)
        {
            field.Id = Id;

            field.Name = Name;

            field.IsNullable = IsNullable;

            field.FieldType = Enums.CastEnum<Enums.FieldTypes>(FieldType);
        }

        public IField ToListItem()
        {
            var fieldListItem = new FieldListItem();

            MapTo(fieldListItem);

            return fieldListItem;
        }
    }
}
