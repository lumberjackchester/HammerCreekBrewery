using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HammerCreekBrewing.Data
{
    public class Container
    {
        [Key]
        public int ContainerId { get; set; }
        [Required]
        public string ContainerType { get; set; }
        [Required]
        public string ContainerSize { get; set; }
    }
}
