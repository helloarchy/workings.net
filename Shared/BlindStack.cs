namespace Workings.Shared
{
    public class BlindStack
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Stack";
        public BlindStackType Type { get; set; } = BlindStackType.Normal;
        public double Offset { get; set; } = 0;
    }
    
    public enum BlindStackType
    {
        Normal,
        Waterfall,
        Reveal
    }
}