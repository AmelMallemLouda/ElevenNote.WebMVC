using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {
        [Key] //uniquely identifies an entity
        public int NoteId { get; set; }

        [Required]// To ensure that the user does not enter a null value
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]

        public DateTimeOffset CreatedUtc { get; set; }//DateTimeOffset is a value type, they can't be null

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
