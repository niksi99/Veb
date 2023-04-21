
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace okt2_2021.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdavnicaController : ControllerBase{

    public Context Context { get; set; }

    public ProdavnicaController(Context c) { 
        Context = c;
    }

    [Route("PrikaziProdavnice")]
    [HttpGet]
    public async Task<ActionResult> PrikaziProdavnice() {
        
        try {
            return Ok( await Context.Prodavnice.ToListAsync() );
        }
        catch(Exception e) {
            return BadRequest(e.Message);
        }
    }

    [Route("DodajProdavnice/{Naziv}")]
    [HttpPut]
    public async Task<ActionResult> DodajProdavnice(String Naziv) {

        var proveraProdavnice = Context.Prodavnice
            .Include(p => p.proizvodi)
            .Where(p => p.Naziv == Naziv);

        if(proveraProdavnice == null) {
            return BadRequest($"U bazi vec postoji prodavnica sa imenom {Naziv}");
        }

        Prodavnica novaP = new Prodavnica();
        novaP.Naziv = Naziv;

        try {
            Context.Prodavnice.Add(novaP);
            await Context.SaveChangesAsync();
            return Ok(novaP);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [Route("PreuzmiSveZaProdavnicu/{Id}/{Tip}")]
    [HttpGet]
    public async Task <ActionResult> preuzmiSveZaProdavnicu(int Id, String Tip) {
        
         var proveriProdavnicu1 = Context.Prodavnice
            .Where(p => p.Id == Id)
            .Include(p => p.proizvodi)
            .FirstOrDefault();

        try {
            var mojiProz = await Context.Proizvodi
                .Where(p => p.Prodavnica == proveriProdavnicu1 && p.Tip == Tip).ToListAsync();
            return Ok(mojiProz);
        }

        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [Route("PreuzmiTipove/{Id}")]
    [HttpGet]
    public async Task <ActionResult> PreuzmiTipove(int Id) {

        var proveraProdavnice = Context.Prodavnice
            .Where(p => p.Id == Id)
            .Include(p => p.proizvodi)
            .FirstOrDefault();

        if(proveraProdavnice == null) {
            return BadRequest("Nepostojeci proizvod");
        }

        List<string> tipovi = new List<string>();
        foreach(Proizvod pr in proveraProdavnice.proizvodi) {
            if(!tipovi.Contains(pr.Tip))
                tipovi.Add(pr.Tip);
        }

        try {
            return Ok(tipovi);
        }
        catch(Exception e) {
            return BadRequest(e.Message);
        }
    }

}