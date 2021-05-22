using System.ComponentModel.DataAnnotations.Schema;

namespace workings.Shared
{
    public class BlindProfile
    {
        public int Id { get; init; }
        public string Name { get; set; }
        
        public int BlindBottomBarId { get; set; }
        public int BlindRailingId { get; set; }
        public int BlindStackId { get; set; }
        public int BusinessClientId { get; set; }

        public BlindBottomBar BlindBottomBar { get; set; } = new();
        public BlindRailing BlindRailing { get; set; } = new();
        public BlindStack BlindStack { get; set; } = new();
        public BusinessClient BusinessClient { get; set; } = new();
    }
}