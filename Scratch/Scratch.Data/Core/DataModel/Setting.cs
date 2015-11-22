using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scratch.Data.Core.DataModel
{
    public class Setting
    {
        [Key]
        [Column(Order = 1)] 
        public string Section { get; set; }

        [Key]
        [Column(Order = 2)] 
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
