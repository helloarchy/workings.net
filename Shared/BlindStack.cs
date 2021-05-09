namespace workings.Shared
{
    public class BlindStack
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Stack";
        public BlindStackType Type { get; set; } = BlindStackType.Normal;
        public decimal Offset { get; set; } = 6;
    }
    
    public enum BlindStackType
    {
        Normal,
        Waterfall,
        Reveal
    }
}