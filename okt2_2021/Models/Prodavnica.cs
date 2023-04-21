using System.Text.Json.Serialization;

namespace Models {

    public class Prodavnica {

        public int Id { get; set; }

        public String? Naziv{get; set;}

        [JsonIgnore]
        public List<Proizvod>? proizvodi {get; set;}
    }
}