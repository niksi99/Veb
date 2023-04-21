using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("[controller]")]
public class ProizvodController : ControllerBase{
    
    public Context Context { get; set; }

    public ProizvodController(Context c) {
        Context = c;
    }

    [Route("IzmeniCenuIKolicinu/{Id}/{cena}/{kolicina}")]
    [HttpPost]
    public async Task<ActionResult> IzmeniCenuIKolicinu(int Id, int cena, int kolicina) {

        var proveraProizvoda = Context.Proizvodi.Where(p => p.Id == Id).FirstOrDefault();
        if(proveraProizvoda == null) {
            return BadRequest("Nepostoji takav proziovd");
        }

        if(cena < 0 || kolicina < 0) {
            return BadRequest("Nemoguce vrednosti parametara");
        }

        var noviProizvod = proveraProizvoda;
        noviProizvod.Cena = cena;
        noviProizvod.Kolicina = kolicina;

        try {
            Context.Proizvodi.Add(noviProizvod);
            await Context.SaveChangesAsync();
            return Ok(noviProizvod);
        }
        catch(Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [Route("DodajPodatke/{Ime}/{Tip}/{Kolicina}/{Cena}/{IdProdavnice}")]
    [HttpPut]
    public async Task<ActionResult> dodajPodatke(String Ime, String Tip, int Kolicina, int Cena, int IdProdavnice) {
        
        if(String.IsNullOrEmpty(Ime) || String.IsNullOrEmpty(Tip) || Cena < 0 || IdProdavnice < 0 || Kolicina < 0) {
            return BadRequest("Lose uneti parametr");
        }

        var proveraProdavnice = Context.Prodavnice.Where(p => p.Id == IdProdavnice).FirstOrDefault();
        if(proveraProdavnice == null) {
            return BadRequest ("Nepostoji ova prodavnica");
        }

        var proveraProizvoda = Context.Proizvodi.Where(p => p.Ime == Ime).FirstOrDefault();
        if(proveraProizvoda != null) {
            return BadRequest ("Ovaj proizvod vecpsotij");
        }

        Proizvod noviProizvod = new Proizvod();
        noviProizvod.Prodavnica = proveraProdavnice;
        noviProizvod.Ime = Ime;
        noviProizvod.Tip = Tip;
        noviProizvod.Kolicina = Kolicina;
        noviProizvod.Cena = Cena;

        try {
            Context.Proizvodi.Add(noviProizvod);
            await Context.SaveChangesAsync();
            return Ok("noviProizvod");
        }

        catch (Exception e) {
            return Ok(e.Message);
        }
        
    }

    [Route("SmanjiKolicinu/{Id}/{Kolicina}")]
    [HttpPost]
    public async Task<ActionResult> smanjiKolicinu(int Id, int Kolicina) {
       
       if(Id < 0) {
           return BadRequest("Id ic ne moze da bude nula");
       }

       var proveraProizvoda = Context.Proizvodi.Where(p => p.Id == Id).FirstOrDefault();
       if(proveraProizvoda == null) {
           return BadRequest("Nepostojeci proizovd");
       }

       if(Kolicina > proveraProizvoda.Kolicina) {
           return BadRequest("Prevelika kolicina");
       }

       proveraProizvoda.Kolicina = proveraProizvoda.Kolicina - Kolicina;

       try {
           Context.Proizvodi.Update(proveraProizvoda);
           await Context.SaveChangesAsync();
           return Ok(proveraProizvoda);
       }
       catch(Exception e) {
           return BadRequest(e.Message);
       }

    }
}