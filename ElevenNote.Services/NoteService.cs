using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }


        //Create an instance of Note
        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,//We want the user who creates the note to be the user who is logged in
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //see all the notes that belong to a specific user.
        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
    

    

