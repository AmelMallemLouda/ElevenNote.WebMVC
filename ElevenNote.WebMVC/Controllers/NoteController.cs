using ElevenNote.Models;
using ElevenNote.Services;
using ElevenNote.WebMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    [Authorize]//This annotation makes it so that the views are accessible only to logged in users
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = service.GetNotes();
           
            return View(model);//That View() method will return a view that corresponds to the NoteController. view() displays all the notes for the current user.
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
     [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your note was created."; //?

                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Note could not be created.");//?

            return View(model);
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new NoteService(userId);
            return service;
        }
    }
}