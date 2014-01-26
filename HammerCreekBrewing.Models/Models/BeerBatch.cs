using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace HammerCreekBrewing.Data.Models
{
    public class BeerBatch
    {
        [Key]
        [Required]
        public int BatchId { get; set; }

        [ForeignKey("BeerId")]
        public Beer Beer { get; set; }

        [Required]
        public int BeerId { get; set; }
        public decimal Abv { get; set; }
        public DateTime BrewDate { get; set; }
    }
}
