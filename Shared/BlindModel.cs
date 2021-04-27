using System.ComponentModel.DataAnnotations;

namespace workings.Shared
{
    public class BlindModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Client { get; set; }

        [StringLength(10, ErrorMessage = "Name is too long.")]
        public Customer Customer { get; set; }

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