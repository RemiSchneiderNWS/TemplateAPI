using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemplateAPI.Context;
using TemplateAPI.Models;

namespace TemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetController : Controller
    {
        private readonly AppDbContext context;
        public ObjetController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Objet>> GetAllObjet()
        {
            return context.objet.ToList();
        }



        // POST: ObjetController/Create
        [HttpPost("createObjet")]
   
        public ActionResult Create(Objet objet)
        {
            context.objet.Add(objet);
            context.SaveChanges();
            return CreatedAtAction("GetObjet", new { Id = objet.Id }, objet);
        }

        

        // POST: ObjetController/Edit/5
        [HttpPost("editObjet/{id}")]

        public ActionResult Edit(int id, Objet objet)
        {
            if (id != objet.Id)
            {
                return BadRequest();
            }

            context.Entry(objet).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

   
        // POST: ObjetController/Delete/5
        [HttpDelete("Delete/{id}")]

        public ActionResult Delete(int id)
        {
           var objet = context.objet.Find(id);
            if (objet == null) { 
                return NotFound();
            }

            context.Remove(objet);

            context.SaveChanges();
            return Ok();
        }

        private bool ObjetExists(int id)
        {
            return context.objet.Any(e => e.Id == id);
        }
    }
}
