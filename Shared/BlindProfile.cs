namespace workings.Shared
{
    public class BlindProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BlindModel DefaultValues { get; set; } = new();
    }
}