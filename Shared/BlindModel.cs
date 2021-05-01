using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workings.Shared
{
    public class BlindModel
    {
        [Required]
        public int BusinessClientId { get; set; } /* TODO: Look at foreign key set up */
        
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Customer { get; set; }

        [StringLength(25, MinimumLength = 4, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; }
        public int CountBlinds { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int CountWidths { get; set; }
        public int RailingId { get; set; }
        public decimal RailingDepth { get; set; }
        public StackType StackType { get; set; }
        public decimal WaterfallIncrements { get; set; }
        public decimal Reveal { get; set; }
        
        [Range(1,12, ErrorMessage = "The {0} are out of range (min {1}, max {2})")]
        public int Folds { get; set; }
    }

    public enum StackType
    {
        Normal,
        Waterfall,
        Reveal
    }
}