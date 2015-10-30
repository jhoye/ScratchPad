using System;
using Scratch.Data;
using Scratch.ServiceDelegates;

namespace Scratch
{
    public class Components
    {
        public ICache Cache { get; set; }

        public IConfiguration Configuration { get; set; }

        public IUsers Users { get; set; }

        public static Func<Components> Access { get; set; }
    }
}
