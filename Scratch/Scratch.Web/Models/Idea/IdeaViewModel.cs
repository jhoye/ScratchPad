using System.ComponentModel.DataAnnotations;

namespace Scratch.Web.Models.Idea
{
    public class IdeaViewModel
    {
        [Required]
        [Display(Name = "Idea")]
        public string Idea { get; set; }
    }
}