using System.Data.Entity;

namespace Scratch.Data.Core.SystemDataModel.DataModel
{
    /// <summary>
    /// DbContext for system data
    /// </summary>
    public class SystemData : DbContext
    {
        public SystemData() : base("name=SystemData")
        {
        }
    }
}
