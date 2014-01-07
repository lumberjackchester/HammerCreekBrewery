using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Domain
{
    public class Beer : DomainBase
    {

        public string Name { get; set; }        
        public string TapName { get; set; }
        public string LocationId { get; set; }
        public DateTime BrewDate { get; set; }
        public DateTime? KeggedDate { get; set; }
        public DateTime? TappedDate { get; set; }
        public decimal Abv { get; set; }
        public int? KegId { get; set; }
        public bool OnTap { get; set; }

        // Style
        public virtual Style Style { get; set; }
        public int StyleId { get; set; }

    }
}