using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {

    public class Grad {

        [Key]
        public int ID {get; set;}

        public String? Naziv {get; set;}

        public int X{get; set;}

        public int Y{get; set;}

        [JsonIgnore]
        public List<MeteoroloskiPodaci>? podaci {get; set;}
    }
}