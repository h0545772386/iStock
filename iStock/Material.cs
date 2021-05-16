namespace iStock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatId { get; set; }

        public int MatNum { get; set; }

        public int Date1 { get; set; }

        [StringLength(50)]
        public string Batch1 { get; set; }

        [Required]
        [StringLength(200)]
        public string Name1 { get; set; }

        [StringLength(100)]
        public string Name2 { get; set; }

        [StringLength(70)]
        public string BrCode1 { get; set; }

        [StringLength(70)]
        public string BrCode2 { get; set; }

        [Required]
        [StringLength(200)]
        public string UOM1 { get; set; }

        [Required]
        [StringLength(200)]
        public string UOM2 { get; set; }

        [Required]
        [StringLength(200)]
        public string MName2 { get; set; }

        public decimal Price1 { get; set; }

        public decimal Price2 { get; set; }

        public decimal Price3 { get; set; }

        public decimal MinQTY { get; set; }

        public decimal MaxQTY { get; set; }

        public decimal TotalQTY { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}