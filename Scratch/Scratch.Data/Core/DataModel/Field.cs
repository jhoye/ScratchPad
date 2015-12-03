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

        public int? StorageBytes { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        public int OrderOfAppearance { get; set; }

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

            Description = field.Description;

            IsNullable = field.IsNullable;

            FieldType = field.FieldType;

            StorageBytes = field.StorageBytes;

            Precision = field.Precision;

            Scale = field.Scale;

            OrderOfAppearance = field.OrderOfAppearance;

            ContentTypeId = field.ContentTypeId;
        }

        public void MapTo(IField field)
        {
            field.Id = Id;

            field.Name = Name;

            field.Description = Description;

            field.IsNullable = IsNullable;

            field.FieldType = FieldType;

            field.StorageBytes = StorageBytes;

            field.Precision = Precision;

            field.Scale = Scale;

            field.OrderOfAppearance = OrderOfAppearance;

            field.ContentTypeId = ContentTypeId;
        }

        public IField ToListItem()
        {
            var fieldListItem = new FieldListItem();

            MapTo(fieldListItem);

            return fieldListItem;
        }
    }
}
