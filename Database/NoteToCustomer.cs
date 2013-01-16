namespace YetAnotherCRM
{
    public class NoteToCustomer
    {
        public NoteToCustomer()
        {
        }

        public NoteToCustomer(int customerId, string content)
        {
            CustomerId = customerId;
            Content = content;
        }

        public int CustomerId { get; set; }
        public string Content { get; set; }
    }
}
