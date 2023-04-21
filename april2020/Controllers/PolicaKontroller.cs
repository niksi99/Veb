//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace april2020.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class PolicaController : ControllerBase {
    
    public VideoKlubContext Context {get; set;}
    
    public PolicaController(VideoKlubContext c) {
        Context = c;
    }

    [Route("DodajPolice")]
    [HttpPost]
    public async Task<ActionResult> dodajPolice(int idKluba, String oznaka, int trenutnoDVD, int maxdvds) {

        if(trenutnoDVD > maxdvds) {
            return BadRequest("Nevalidan unos");
        }

        if(maxdvds < 0 || maxdvds > 40) {
            return BadRequest("Van opsega");
        }

        if(String.IsNullOrWhiteSpace(oznaka) || oznaka.Length > 25) {
            return BadRequest("Nevalidna oznaka");
        }

        var klub = Context.VideoKlubovi.Where(p => p.ID == idKluba).FirstOrDefault();
        if(klub == null) {
            return BadRequest("Nepostojeci Video klub u bazi");
        }

        var provera = Context.Police.Where(p => p.Oznaka == oznaka).FirstOrDefault();
        if(provera != null) {
            return BadRequest("Polica sa ovom oznakom vec postoji");
        }

        Polica novaPolica = new Polica();
        novaPolica.mojiVK = klub;
        novaPolica.Oznaka = oznaka;
        novaPolica.MaxBrDVDs = maxdvds;
        novaPolica.TrenutnoDVDs = trenutnoDVD;
       
        try
        {
            Context.Police.Add(novaPolica);
            await Context.SaveChangesAsync();
            return Ok(novaPolica);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("DodajDiskove/{idPolice}/{brojDVDs}")]
    [HttpPut]
    public async Task<ActionResult> dodajDVDs(int idPolice, int brojDVDs) {

        if(brojDVDs < 0 || brojDVDs > 40) {
            return BadRequest("broj diskova premasuje opseg");
        }

        var novaDisk = await Context.Police.Where(p => p.ID == idPolice).FirstOrDefaultAsync();
        if(novaDisk == null) {
            return BadRequest("Nepostojeca polica");
        }

        if(novaDisk.TrenutnoDVDs + brojDVDs > novaDisk.MaxBrDVDs) {
            return BadRequest("Nema dovoljno mesta");
        }
        
        novaDisk.TrenutnoDVDs+=brojDVDs;

        try 
        {
            Context.Police.Update(novaDisk);
            await Context.SaveChangesAsync();
            return Ok(novaDisk);
        }
        catch(Exception e) {
            return BadRequest(e.Message);
        }
    }
}