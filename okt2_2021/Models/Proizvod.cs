using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {

    public class Proizvod {
        
        [Key]
        public int Id{get; set;}

        [Required]
        [MaxLength(30)]
        public String? Ime{get; set;}

        public String? Tip {get; set;}

        public int Kolicina {get; set;}
        
        public int Cena{get; set;}

        [JsonIgnore]
        public Prodavnica? Prodavnica{get; set;}
    }
}