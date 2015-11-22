using System;
using Scratch.Data;
using Scratch.Data.Core;
using Scratch.ServiceDelegates;

namespace Scratch
{
    public class Components
    {
        public ICache Cache { get; set; }

        public IConfiguration Configuration { get; set; }

        public IContentTypes ContentTypes { get; set; }

        public IMail Mail { get; set; }

        public IUsers Users { get; set; }

        public ISettings Settings { get; set; }

        public static Func<Components> Access { get; set; }
    }
}
