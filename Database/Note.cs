using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace YetAnotherCRM
{
    public class Note
    {
        public Note()
        {
        }

        public Note(string content)
        {
            Content = content;
        }

        public int NoteId { get; set; }
    
        [JsonIgnore]
        public Customer Customer { get; private set; }

        [Required]
        public string Content { get; private set; }
    }
}