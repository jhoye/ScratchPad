using System.Collections.Generic;

namespace Scratch.Web.Models.Treeview
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel() : base(MenuItems.Treeview)
        {
            Branches = new List<Branch>
            {
                new Branch(Branch.BranchTypes.Inbox)
                {
                    Branches = new List<Branch>
                    {
                        new Branch(Branch.BranchTypes.Inbox_TodaysSchedule),
                        new Branch(Branch.BranchTypes.Inbox_TodaysTickler),
                        new Branch(Branch.BranchTypes.Inbox_PurchaseOrders),
                        new Branch(Branch.BranchTypes.Inbox_FormSubmissions),
                        new Branch(Branch.BranchTypes.Inbox_BlogComments),
                        new Branch(Branch.BranchTypes.Inbox_Ideas)
                    }
                },
                new Branch(Branch.BranchTypes.Lists)
                {
                    Branches = new List<Branch>
                    {
                        new Branch(Branch.BranchTypes.Lists_Projects),
                        new Branch(Branch.BranchTypes.Lists_NextActions),
                        new Branch(Branch.BranchTypes.Lists_WaitingFor),
                        new Branch(Branch.BranchTypes.Lists_SomedayMaybe),
                        new Branch(Branch.BranchTypes.Lists_AtComputer),
                        new Branch(Branch.BranchTypes.Lists_AwayFromComputer),
                        new Branch(Branch.BranchTypes.Lists_Errands),
                        new Branch(Branch.BranchTypes.Lists_Calls),
                        new Branch(Branch.BranchTypes.Lists_Agendas)
                    }
                },
                new Branch(Branch.BranchTypes.Calendar),
                new Branch(Branch.BranchTypes.ReferenceMaterials),
                new Branch(Branch.BranchTypes.TicklerFiles)
            };
        }

        public List<Branch> Branches { get; set; }
    }
}