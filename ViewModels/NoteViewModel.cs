using YetAnotherCRM;

namespace ViewModels
{
    public class NoteViewModel
    {
        public NoteViewModel()
        {
        }

        public NoteViewModel(Note note)
        {
            NoteId = note.NoteId;
            Content = note.Content;
        }

        public int NoteId { get; set; }

        public string Content { get; private set; }
    }
}