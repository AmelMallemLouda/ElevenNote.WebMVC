using ElevenNote.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.CategoryModels
{
   public  class CategoryDetails
    {
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Display(Name = "Number of Notes in the Category")]
        public int NumOfNotes { get; set; }
        public List<NoteListItem> Notes { get; set; } = new List<NoteListItem>();
    }
}
