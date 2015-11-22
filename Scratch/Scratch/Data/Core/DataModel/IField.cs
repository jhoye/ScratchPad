﻿using System;

namespace Scratch.Data.Core.DataModel
{
    public interface IField
    {
        Guid? Id { get; set; }

        string Name { get; set; }

        bool IsNullable { get; set; }

        Enums.FieldTypes FieldType { get; set; }

        int OrderOfAppearance { get; set; }
    }
}
