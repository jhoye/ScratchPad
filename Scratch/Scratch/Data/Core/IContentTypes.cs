using Scratch.Data.Core.DataModel;

namespace Scratch.Data.Core
{
    public interface IContentTypes
    {
        void Load(IContentTypeHierarchy contentTypesHierarchy);

        void Load(IContentType contentType);

        void Load(IField field);

        void Save(IContentType contentType);

        void Save(IField field);

        void Delete(IContentType contentType);

        void Delete(IField field);
    }
}
