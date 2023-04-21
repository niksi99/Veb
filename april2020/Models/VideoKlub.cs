using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {

    public class VideoKlub {
        
        [Key]
        public int ID {set; get;}

        [Required]
        [MaxLength(34)]
        public String? Naziv {get; set;}

        [JsonIgnore]
        public List<Polica>? mojePolice {get; set;}
    }
}