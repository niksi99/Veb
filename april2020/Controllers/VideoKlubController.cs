
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace april2020.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoKlubController : ControllerBase {

    public VideoKlubContext Context {get; set;}

    public VideoKlubController(VideoKlubContext c) {
        Context = c;
    }

    [Route("PrikaziSveVK")]
    [HttpGet]
    public async Task<ActionResult> prikazi() {

        try {
            var VKs = await Context.VideoKlubovi.ToListAsync();
            return Ok(VKs);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("DodajNoviVK")]
    [HttpPost]
    public async Task<ActionResult> dodaj(String imeVK) {

        var proveraPonavljanja = await Context.VideoKlubovi.Where(p => p.Naziv == imeVK).FirstOrDefaultAsync();
        if(proveraPonavljanja != null) {
            return BadRequest("Vec postoji VK sa ovim imenom");
        }

        if(String.IsNullOrWhiteSpace(imeVK) || imeVK.Length > 34) {
            return BadRequest("Lose uneto ime novog VK-a");
        }

        VideoKlub noviVK = new VideoKlub();
        noviVK.Naziv = imeVK;
        try 
        {   
            await Context.VideoKlubovi.AddAsync(noviVK);
            await Context.SaveChangesAsync();
            return Ok($"Dodat je novi VK sa id-em {noviVK.ID}");
        }
        catch (Exception e) {
            return BadRequest(e.Message);
        }

       
    }

    [Route("PokupiOznake/{klubID}")]
    [HttpGet]
    public async Task<ActionResult> oznake(int klubID) {

        if(klubID < 0) {
            return BadRequest("Los id");
        }
         

        var klub =  Context.VideoKlubovi
            .Where(p => p.ID == klubID).FirstOrDefault();

        if(klub == null) {
            return BadRequest("Nepostojeci klub si izabrao");
        }
       
        var mojaPolica =  Context.Police.Where(p => p.mojiVK == klub).ToList();
       
        if(mojaPolica == null) {
            return Ok("mojaPolica null");
        }

         try 
        {
            var pol = Context.Police.Select(p=> new{oznaka=p.Oznaka, id=p.ID}).ToList();
         
            return Ok(
                pol
            );
        }
        catch(Exception e) {
            return BadRequest(e.Message);
        }
    }

    [Route("PreuzmiOznakePolica/{id}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiOznakePolica(int id)
        {
            var klub=Context.VideoKlubovi.Where(k=> k.ID==id).FirstOrDefault();
            if(klub==null) return BadRequest("Nepostojeci klub!");

            var police= await Context.Police.Where(p=> p.mojiVK==klub)
			.ToListAsync();

            try
            {
                return Ok(police.Select(p=> new{oznaka=p.Oznaka, id=p.ID})
				.ToList());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

}