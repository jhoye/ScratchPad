using System.ComponentModel.DataAnnotations;

namespace Scratch.Web.Models.Page
{
    public class AddViewModel
    {
        [Required]
        [Display(Name = "Page Title")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Slug")]
        [MaxLength(255)]
        public string Slug { get; set; }
    }
}