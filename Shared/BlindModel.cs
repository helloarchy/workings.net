using System.ComponentModel.DataAnnotations;

namespace workings.Shared
{
    public class BlindModel
    {
        [Required]
        public BusinessClient BusinessClient { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Customer { get; set; }

        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Reference { get; set; }

        public int BlindCount { get; set; }

        public string RailingType { get; set; }
    }

    /* TODO: JFDI and use database!!! */
    public enum Customer
    {
        BlindsNBlessings,
        ChelseaFabrics,
        CurtainFactoryOutlet,
        FabricHouse,
        JudyFletcher,
        PosnerInteriors
    }
}