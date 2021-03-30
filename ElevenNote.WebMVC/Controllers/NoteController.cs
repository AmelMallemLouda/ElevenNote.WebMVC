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
        public ActionResult Index()//The ActionResult is a return type.it allows us to return a View() method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = service.GetNotes();
           
            return View(model);//That View() method will return a view that corresponds to the NoteController. view() displays all the notes for the current user.
        }

        //GET
        public ActionResult Create()//GET method that gives users a View in which they can fill in the Title and Content for a new note.
        {
            return View();
        }

        [HttpPost]
     [ValidateAntiForgeryToken]//The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks
        public ActionResult Create(NoteCreate model)//[HttpPost] method  will push the data inputted in the view through our service and into the db.
        {
            if (!ModelState.IsValid) return View(model);//makes sure the model is valid

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                //TempData removes information after it's accessed
                TempData["SaveResult"] = "Your note was created."; //?

                return RedirectToAction("Index"); //returns the user back to the index view
            };
            ModelState.AddModelError("", "Note could not be created.");//?

            return View(model);
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());// grabs the current userId

            var service = new NoteService(userId);
            return service;
        }
    }
}