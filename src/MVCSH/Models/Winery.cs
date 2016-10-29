using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace MVCSH.Models
{
    public class Winery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }


        public Country Country { get; set; }
        public virtual ICollection<Wine> Wines { get; set; } // Relationship Between Winery And Wine - Relationship Between 2 Models!
    }

    public enum Country
    {
        Israel, Germany, Australia, France , Italy, UK , China , Other
    }
}
