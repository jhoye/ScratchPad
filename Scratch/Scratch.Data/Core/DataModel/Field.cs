using System;

namespace Scratch.Data.Core.DataModel
{
    internal class Field
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsNullable { get; set; }

        public int FieldTypeValue { get; set; }

        public Enums.FieldTypes FieldType
        {
            get
            {
                return Enums.CastEnum<Enums.FieldTypes>(FieldTypeValue);
            }

            set
            {
                FieldTypeValue = (int) value;
            }
        }

        public Guid ContentTypeId { get; set; }

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

            FieldType = field.FieldType;
        }

        public void MapTo(IField field)
        {
            field.Id = Id;

            field.Name = Name;

            field.IsNullable = IsNullable;

            field.FieldType = FieldType;
        }

        public IField ToListItem()
        {
            var fieldListItem = new FieldListItem();

            MapTo(fieldListItem);

            return fieldListItem;
        }
    }
}
