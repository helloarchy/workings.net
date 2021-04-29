using System.ComponentModel.DataAnnotations;

namespace workings.Shared
{
    public class BlindModel
    {
        [Required]
        public int BusinessClientId { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Customer { get; set; }

        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; }

        public int BlindCount { get; set; }

        public string RailingType { get; set; }
    }
}