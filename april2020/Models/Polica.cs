using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {

    public class Polica {

        [Key]
        public int ID {set; get;}

        [Required]
        [MaxLength(25)]
        public String? Oznaka {get; set;}

        [Required]
        [Range(0, 40)]
        public int MaxBrDVDs {get; set;}

        [Required]
        [Range(0, 40)]
        public int TrenutnoDVDs {get; set;}

        [JsonIgnore]
        public VideoKlub? mojiVK {get; set;}


    }
}