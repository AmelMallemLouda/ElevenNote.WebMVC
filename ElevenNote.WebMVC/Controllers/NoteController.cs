using ElevenNote.Models;
using ElevenNote.WebMVC.Models;
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

            var model = new NoteListItem[0];//we are initializing a new instance of the NoteListItem as an IEnumerable with the [0] syntax
            return View(model);//That View() method will return a view that corresponds to the NoteController
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}