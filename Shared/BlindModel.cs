using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Net.Http.Json;

namespace workings.Shared
{
    public class BlindModel
    {
        public int Id { get; set; }
        
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Customer { get; set; }

        [StringLength(25, MinimumLength = 4, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; }
        public int CountBlinds { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int CountWidths { get; set; }

        [Range(1, 12, ErrorMessage = "The {0} are out of range (min {1}, max {2})")]
        public int Folds { get; set; } = 1;

        public int BlindRailingId { get; set; }
        public int BusinessClientId { get; set; }
        public int BlindStackId { get; set; }

        public BlindStack BlindStack { get; set; } = new();
        public BlindRailing BlindRailing { get; set; } = new();
        public BusinessClient BusinessClient { get; set; } = new();

    }
}