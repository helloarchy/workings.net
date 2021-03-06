using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Net.Http.Json;

namespace Workings.Shared
{
    public class BlindModel
    {
        public int Id { get; set; }

        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string Customer { get; set; } = "Hardy Family";

        [StringLength(25, MinimumLength = 4, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; } = "Kids room";

        public int CountBlinds { get; set; } = 1;
        public double Width { get; set; } = 123.45;
        public double Height { get; set; } = 123.45;
        public int CountWidths { get; set; } = 1;

        [Range(1, 12, ErrorMessage = "The {0} are out of range (min {1}, max {2})")]
        public int Folds { get; set; } = 1;

        

        public int BlindBottomBarId { get; set; }
        public int BlindRailingId { get; set; }
        public int BlindRodId { get; set; }
        public int BusinessClientId { get; set; }
        public int BlindStackId { get; set; }
        
        [ForeignKey("BlindLiningId")]
        public int BlindInnerLiningId { get; set; }
        
        [ForeignKey("BlindLiningId")]
        public int BlindOuterLiningId { get; set; }
        
        public BlindBottomBar BlindBottomBar { get; set; } = new();
        public BlindRailing BlindRailing { get; set; } = new();
        public BlindRod BlindRod { get; set; } = new();
        public BlindStack BlindStack { get; set; } = new();
        public BusinessClient BusinessClient { get; set; } = new();
        
        public BlindLining BlindInnerLining { get; set; } = new();
        public BlindLining BlindOuterLining { get; set; } = new();
    }
}