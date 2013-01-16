using YetAnotherCRM;

namespace ViewModels
{
    public class NoteToCustomerModel
    {
        public NoteToCustomerModel()
        {
        }

        public NoteToCustomerModel(NoteToCustomer data)
        {
            CustomerId = data.CustomerId;
            Content = data.Content;
        }

        public int CustomerId { get; set; }
        public string Content { get; set; }
    }
}
