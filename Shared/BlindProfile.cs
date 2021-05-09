using System.ComponentModel.DataAnnotations.Schema;

namespace workings.Shared
{
    public class BlindProfile
    {
        public int Id { get; init; }
        public string Name { get; set; }
        
        public int BusinessClientId { get; set; }
        public int BlindRailingId { get; set; }
        public int BlindStackId { get; set; }
        
        public BlindRailing BlindRailing { get; set; }
        public BlindStack BlindStack { get; set; }
        public BusinessClient BusinessClient { get; set; }
    }
}