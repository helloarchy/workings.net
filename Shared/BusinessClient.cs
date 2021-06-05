using System.ComponentModel.DataAnnotations;

namespace Workings.Shared
{
    public class BusinessClient
    {
        public int Id { get; init; }
        
        [Required]
        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; } = "Default Client";
    }
}