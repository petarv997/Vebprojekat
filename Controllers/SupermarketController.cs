using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupermarketController : ControllerBase
    {
        public ProjectContext Context;

        public SupermarketController(ProjectContext context)
        {
            Context = context;
        }

        
        [Route("Preuzmi")]
        [HttpGet]
        public async Task<List<Supermarket>> GetSupermarkets()
        {
            return await Context.supermarketi
            
            .ToListAsync();
        }

        [Route("PreuzmiRedove")]
        [HttpGet]
        public async Task<List<Red>> GetRows()
        {
            return await Context.redovi
            .Include(q => q.Proizvodi)
            .ToListAsync();
        }
        [Route("PreuzmiOdrRedove/{smID}")]
        [HttpGet]
        public async Task<List<Red>> GetRows(int smID)
        {
            return await Context.redovi.Where(red=>red.Supermarket.ID == smID)
            .Include(q => q.Proizvodi)
            .ToListAsync();
        }

        [Route("PostRed")]
        [HttpPost]

        public async Task PostRed(int SMID, [FromBody] Red r)
        {
            var supermarket = await Context.supermarketi.FindAsync(SMID);
            r.Supermarket = supermarket;
            Context.redovi.Add(r);
            await Context.SaveChangesAsync();
        }

        [Route("PreuzmiSkladista")]
        [HttpGet]
        public async Task<List<Skladiste>> GetStorage()
        {
            return await Context.skladista
            .Include(q => q.SProizvod)
            .ToListAsync();
        }

        [Route("PreuzmiProizvode")]
        [HttpGet]
        public async Task<List<Proizvod>> GetProducts()
        {
            return await Context.proizvodi
            .ToListAsync();
        }
        
        [Route("PreuzmiOdrProizvode/{rID}")]
        [HttpGet]
        public async Task<List<Proizvod>> GetProducts(int rID)
        {
            return await Context.proizvodi.Where(prz=>prz.Red.ID == rID)
            .ToListAsync();
        }

        [Route("PostSupermarkets")]
        [HttpPost]
        public async Task PostSupermarkets([FromBody] Supermarket supermarket)
        {
            Context.supermarketi.Add(supermarket);
            await Context.SaveChangesAsync();
        }

        [Route("UpdateSupermarket")]
        [HttpPut]
        public async Task UpdateSupermarket([FromBody] Supermarket supermarket)
        {
            Context.Update<Supermarket>(supermarket);
            await Context.SaveChangesAsync();
        }

        [Route("DeleteSupermarket/{id}")]
        [HttpDelete]
        public async Task DeleteSupermarket(int id)
        {
            var supermarket = await Context.FindAsync<Supermarket>(id);
            Context.Remove(supermarket);
            await Context.SaveChangesAsync();
        }

        

        [Route("PostProizvod")]
        [HttpPost]
        public async Task<IActionResult> PostRedProizvod(int RedID, [FromBody] Proizvod proizvod)
        {
            var red = await Context.redovi.FindAsync(RedID);
            proizvod.Red = red;

            if (proizvod.Naziv == "" || proizvod.Cena < 1 || proizvod.Kolicina < 0)
            {
                return StatusCode(406);
            }
            else
            {
                Context.proizvodi.Add(proizvod);
                await Context.SaveChangesAsync();
                int a = proizvod.ID;
                return Ok(a);
            }

        }

        [Route("PostSkladiste")]
        [HttpPost]

        public async Task PostSkladiste(int SMID, [FromBody] Skladiste sk)
        {
            var supermarket = await Context.supermarketi.FindAsync(SMID);
            sk.Supermarket = supermarket;
            Context.skladista.Add(sk);
            await Context.SaveChangesAsync();
        }

        [Route("PostSProizvod")]
        [HttpPost]
        public async Task<IActionResult> PostSkladisteProizvod(int SID, [FromBody] SProizvod sproizvod)
        {
            var skl = await Context.skladista.FindAsync(SID);
            sproizvod.Skladiste = skl;

            if (sproizvod.Naziv == "" || sproizvod.Kolicina < 0)
            {
                return StatusCode(406);
            }
            else
            {
                Context.sproizvodi.Add(sproizvod);
                await Context.SaveChangesAsync();
                int a = sproizvod.ID;
                return Ok(a);
            }

        }

        [Route("KupiProizvod/{pid}")]
        [HttpPost]
        public async Task<IActionResult> KupiProizvod(int pid)
        {
            var proizvod = await Context.proizvodi.FindAsync(pid);
            
            if (proizvod.Naziv == "" || proizvod.Cena < 1 || proizvod.Kolicina <= 0)
            {
                return StatusCode(406);
            }
            else
            {
                proizvod.Kolicina--;
                Context.Update<Proizvod>(proizvod);
                await Context.SaveChangesAsync();
                return Ok();
            }
        }

        [Route("DodajProizvod/{pid}")]
        [HttpPost]
        public async Task<IActionResult> DodajProizvod(int pid)
        {
            var proizvod = await Context.proizvodi.FindAsync(pid);
            
            if (proizvod.Naziv == "" || proizvod.Cena < 1 || proizvod.Kolicina <= 0)
            {
                return StatusCode(406);
            }
            else
            {
                proizvod.Kolicina++;
                Context.Update<Proizvod>(proizvod);
                await Context.SaveChangesAsync();
                return Ok();
            }
        }

        [Route("UpdateProizvod")]
        [HttpPut]
        public async Task<IActionResult> UpdateProizvod([FromBody] Proizvod proizvod)
        {
            if (proizvod.Naziv == "" || proizvod.Cena < 1 || proizvod.Kolicina < 0)
            {
                return StatusCode(406);
            }
            else
            {
                Context.Update<Proizvod>(proizvod);
                await Context.SaveChangesAsync();
                return Ok();
            }
        }

        [Route("DeleteProizvod/{id}")]
        [HttpDelete]
        public async Task DeleteProizvod(int id)
        {
            var proizvod = await Context.FindAsync<Proizvod>(id);
            Context.Remove(proizvod);
            await Context.SaveChangesAsync();
        }
    }
}
