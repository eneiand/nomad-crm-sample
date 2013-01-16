using System.Collections.Generic;
using System.Linq;
using YetAnotherCRM;

namespace ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }

        public CustomerViewModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            SecondName = customer.SecondName;
            Address = customer.Address;
            City = customer.City;
            ZipCode = customer.ZipCode;
            Phone = customer.Phone;
            EMailAddress = customer.EMailAddress;
            Notes = new List<NoteViewModel>(customer.Notes.Select(note => new NoteViewModel(note)));
        }

        public void ApplyToCustomer(Customer customer)
        {
            customer.CustomerId = CustomerId;
            customer.FirstName = FirstName;
            customer.SecondName = SecondName;
            customer.Address = Address;
            customer.City = City;
            customer.ZipCode = ZipCode;
            customer.Phone = Phone;
            customer.EMailAddress = EMailAddress;
        }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string EMailAddress { get; set; }

        public ICollection<NoteViewModel> Notes { get; private set; }

        
    }
}
