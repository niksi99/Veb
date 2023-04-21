using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {

    public class MeteoroloskiPodaci{
        
        [Key]
        public int ID {get; set; }

        public int prosecnaDnevnaTemperatura {get; set; }

        public int kolicinaPadavina {get; set; }

        [Range(0,31)]
        public int brojSuncanihDana {get; set;}

        [JsonIgnore]
        public Grad? Grad {get; set;}

        [Range(0, 12)]
        public int Mesec {get; set;}
    }
}