using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroesApp.Data;
using SuperheroesApp.Models;
using System.Net;

namespace SuperheroesApp.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context;

        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperheroesController
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: SuperheroesController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var superhero = _context.Superheroes.SingleOrDefault(s => s.Id == id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // GET: SuperheroesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero newSuperhero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newSuperhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(newSuperhero);
            }
        }

        // GET: SuperheroesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var superhero = _context.Superheroes.SingleOrDefault(s => s.Id == id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // POST: SuperheroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Superhero updateSuperhero)
        {
            if (id != updateSuperhero.Id)
            {
                return NotFound();
            }

            var superheroToUpdate = _context.Superheroes.SingleOrDefault(s => s.Id == id);

            if (superheroToUpdate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Update(updateSuperhero); // one route that updates the entire entity in db
                superheroToUpdate.Name = updateSuperhero.Name;
                superheroToUpdate.AlterEgo = updateSuperhero.AlterEgo;
                superheroToUpdate.PrimaryAbility = updateSuperhero.PrimaryAbility;
                superheroToUpdate.SecondaryAbility = updateSuperhero.SecondaryAbility;
                superheroToUpdate.Catchphrase = updateSuperhero.Catchphrase;
                _context.Update(superheroToUpdate); // another route that only updates the changed fields
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateSuperhero);
        }

        // GET: SuperheroesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var superhero = _context.Superheroes.SingleOrDefault(s => s.Id == id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // POST: SuperheroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero deleteSuperhero)
        {
            if (id != deleteSuperhero.Id)
            {
                return NotFound();
            }
            var superheroToDelete = _context.Superheroes.SingleOrDefault(s => s.Id == id);
            if (superheroToDelete == null)
            {
                return NotFound();
            }
            _context.Superheroes.Remove(superheroToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
