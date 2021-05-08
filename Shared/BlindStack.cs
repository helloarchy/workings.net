namespace workings.Shared
{
    public class BlindStack
    {
        public int BlindStackId { get; set; }
        public string Name { get; set; }
        public BlindStackType Type { get; set; }
        public decimal Offset { get; set; }
    }
    
    public enum BlindStackType
    {
        Normal,
        Waterfall,
        Reveal
    }
}