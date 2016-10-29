using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace MVCSH.Models
{
    public class Wine
    {
        [Key] // Primery Key - I Add This - Data Annotations - Always Above Property Name With []
        public int Id { get; set; }

        [Required] // Param Cant Be A Null Value
        [StringLength(25,ErrorMessage ="My Message,, Can Delete All The Error Massage Attr")] // Max Length 25 Char
        public string Name { get; set; }

        [Range(10, 200)]
        public double Price { get; set; }

        [Range(2000,2999)]
        public int YearOfBottling { get; set; }

        [Range(8.5,22, ErrorMessage = "Alc Must Be Between Bla..")]
        public double AlcoholPrecentage { get; set; }

        public string ImagePath { get; set; }

        [DataType(DataType.MultilineText)] // Generate Text Area Insted Of A Text Field
        public string Description { get; set; }


        public WineType WineType { get; set; }

        //*** Singel Relationship Between Winery And Wine - Wine Can Be Manifacture At One Winery - One To Many
        [Display(Name ="Winery")] // Display This Name On The Web Page
        public int WineryId { get; set; } 
        public virtual Winery Winery { get; set; } 
        //***

    }

    public enum WineType
    {
            Sauvingnon, Rieslinger, Merlot, Cabarnet, Other
    }
}
