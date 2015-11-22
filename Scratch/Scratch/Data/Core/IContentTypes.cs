using Scratch.Data.Core.DataModel;

namespace Scratch.Data.Core
{
    public interface IContentTypes
    {
        void Load(IContentTypeHierarchy contentTypesHierarchy);

        void Load(IContentType contentType);

        void Save(IContentType contentType);

        void Delete(IContentType contentType);
    }
}
