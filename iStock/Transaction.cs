namespace iStock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [Key]
        public int TrnId { get; set; }

        public int Date1 { get; set; }

        public int LoadNum { get; set; }   /* load from file numerator*/ 

        public int MatId { get; set; }

        [StringLength(50)]
        public string Batch1 { get; set; }

        [Required]
        [StringLength(100)]
        public string Direction { get; set; }  /*IN or OUT*/

        public decimal TrnQTY { get; set; }

        [Required]
        [StringLength(20)]
        public string UOM1 { get; set; }

        public decimal Price1 { get; set; }

        public decimal Price2 { get; set; }

        public decimal Price3 { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [NotMapped]
        public string Name1 { get; set; }

    }
}
