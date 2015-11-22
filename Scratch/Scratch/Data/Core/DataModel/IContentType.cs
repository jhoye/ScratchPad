using System;
using System.Collections.Generic;

namespace Scratch.Data.Core.DataModel
{
    public interface IContentType
    {
        Guid? Id { get; set; }

        string Name { get; set; }

        List<IField> Fields { get; set; }
    }
}
