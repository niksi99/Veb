using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace jan2021.Controllers;

[ApiController]
[Route("[controller]")]
public class GradController : ControllerBase {

    public GradContext Context {get; set;}
    
    public GradController(GradContext context) {
        Context = context;
    }

    [Route("PreuzmiGrad")]
    [HttpGet]
    public async Task<ActionResult> PreuzmiGrad() {

        try {
            var mojiGradovi = await Context.Gradovi.Include(p => p.podaci).ToListAsync();
            return Ok(mojiGradovi);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }

    }

    [Route("DodajGrad{Naziv}/{X}/{Y}")]
    [HttpPost]
    public async Task<ActionResult> DodajGrad(String Naziv, int X, int Y) {

        if(String.IsNullOrEmpty(Naziv)) {
            return BadRequest("Lose uneto ime");
        }

            Grad noviGrad = new Grad();
            noviGrad.X = X;
            noviGrad.Y = Y;
            noviGrad.Naziv = Naziv;

        try {
            Context.Gradovi.Add(noviGrad);
            await Context.SaveChangesAsync();
            return Ok($"Grad sa ID-om {noviGrad.ID} je dodat - {noviGrad.Naziv}");
        }       
        catch(Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}