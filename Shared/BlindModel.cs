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

        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; }

        public int NumBlinds { get; set; }

        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int NumWidths { get; set; }
        public int RailingId { get; set; }
        public decimal RailingDepth { get; set; }


    }
}