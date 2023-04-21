using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[ApiController]
[Route("[controller]")]
public class MeteoroloskiPodaciController : ControllerBase {

        public MeteoroloskiPodaciController(GradContext context) 
        {
            this.Context = context;
               
        }
            public GradContext Context {get; set;}
 

    [Route("DodajPodatke{idGrada}/{temp}/{padav}/{brSunDana}")]
    [HttpPut]
    public async Task<ActionResult> DodajPodatke(int idGrada, int temp, int padav, int brSunDana) {
        
        if(idGrada < 0) {
            return BadRequest("lose unet mesec");
        }

        if(brSunDana < 0 || brSunDana > 31) {
            return BadRequest("lose unet broj sun dana");
        }

        if(padav < 0) {
            return BadRequest("lose unet broj sun dana");
        }
        
        var proveraGrad = Context.Gradovi.Include(p => p.podaci)
            .Where(p => p.ID == idGrada).FirstOrDefault();

        //  var proveraGrad1 = Context.Gradovi.Include(p => p.podaci)

        if(proveraGrad == null) {
            return BadRequest("Nepostojeci grad");
        }

        
        if(proveraGrad.podaci.Count() == 12) {
            return BadRequest("Max napunjen grad s podaci");
        }

        MeteoroloskiPodaci podatak = new MeteoroloskiPodaci();
        podatak.Grad = proveraGrad;
        podatak.prosecnaDnevnaTemperatura = temp;
        podatak.kolicinaPadavina = padav;
        podatak.brojSuncanihDana = brSunDana;
        podatak.Mesec = proveraGrad.podaci.Count() + 1;
        try 
        {
            Context.Podaci.Add(podatak);
            await Context.SaveChangesAsync();
            return Ok(podatak);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [Route("IzmeniTemp/{idPodatka}/{novaTemp}")]
    [HttpPost]
    public async Task<ActionResult> izmeniTemp(int idPodatka, int novaTemp) {

        var proveraPodatka = Context.Podaci.Where(p => p.ID == idPodatka).FirstOrDefault();
        if(proveraPodatka == null) {
            return BadRequest("nepostojeci podatak");
        }

        if(idPodatka == 0) {
            return BadRequest("Nevalidan ID");
        }
        proveraPodatka.prosecnaDnevnaTemperatura = novaTemp;

        try {
            Context.Podaci.Update(proveraPodatka);
            await Context.SaveChangesAsync();
            return Ok(proveraPodatka);
        }
        catch (Exception en) {
            return BadRequest(en.Message);
        }
    }

    [Route("IzmeniPadav/{idPodatka}/{novaKolPad}")]
    [HttpPost]
    public async Task<ActionResult> izmeniPadav(int idPodatka, int novaKolPad) {

        var proveraPodatka = Context.Podaci.Where(p => p.ID == idPodatka).FirstOrDefault();
        if(proveraPodatka == null) {
            return BadRequest("nepostojeci podatak");
        }

        if(idPodatka == 0) {
            return BadRequest("Nevalidan ID");
        }

        if(novaKolPad < 0) {
            return BadRequest("Ic ne moze toj");
        }

        proveraPodatka.kolicinaPadavina = novaKolPad;

        try {
            Context.Podaci.Update(proveraPodatka);
            await Context.SaveChangesAsync();
            return Ok(proveraPodatka);
        }
        catch (Exception en) {
            return BadRequest(en.Message);
        }
    }

    [Route("IzmeniBrSunDana/{idPodatka}/{noviBRS}")]
    [HttpPost]
    public async Task<ActionResult> izmeniBrSunDana(int idPodatka, int noviBRS) {

        var proveraPodatka = Context.Podaci.Where(p => p.ID == idPodatka).FirstOrDefault();
        if(proveraPodatka == null) {
            return BadRequest("nepostojeci podatak");
        }

        if(idPodatka == 0) {
            return BadRequest("Nevalidan ID");
        }

        if(noviBRS < 0 || noviBRS > 31) {
            return BadRequest("Ic ne moze toj");
        }

        proveraPodatka.kolicinaPadavina = noviBRS;

        try {
            Context.Podaci.Update(proveraPodatka);
            await Context.SaveChangesAsync();
            return Ok(proveraPodatka);
        }
        catch (Exception en) {
            return BadRequest(en.Message);
        }
    }

}