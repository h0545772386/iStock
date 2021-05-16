namespace iStock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConvUOM
    {
        [Key]
        public int ConvId { get; set; }

        public int MatId { get; set; }

        [Required]
        [StringLength(200)]
        public string UOM1 { get; set; }

        public int XUOM1 { get; set; }

        public decimal QTY1 { get; set; }

        [Required]
        [StringLength(200)]
        public string UOM2 { get; set; }

        public int YUOM2 { get; set; }

        public decimal QTY2 { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
