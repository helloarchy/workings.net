using System.ComponentModel.DataAnnotations.Schema;

namespace workings.Shared
{
    public class BlindProfile
    {
        public int BlindProfileId { get; init; }
        public string Name { get; set; }
        public BusinessClient BusinessClient { get; set; }
        public BlindRailing BlindRailing { get; set; }
        public BlindStack BlindStack { get; set; }
    }
}