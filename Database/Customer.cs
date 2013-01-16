using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace YetAnotherCRM
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string firstName, string secondName, string address, string city, string zipCode, string eMailAddress, string phone)
            : this(firstName, secondName, address, city, zipCode, eMailAddress, phone, Enumerable.Empty<Note>())
        {
        }

        public Customer(string firstName, string secondName, string address, string city, string zipCode, string eMailAddress, string phone, IEnumerable<Note> notes)
        {
            FirstName = firstName;
            SecondName = secondName;
            Address = address;
            ZipCode = zipCode;
            Phone = phone;
            EMailAddress = eMailAddress;
            Notes = new List<Note>(notes);
            City = city;
        }

        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string EMailAddress { get; set; }

        [JsonIgnore]
        public virtual ICollection<Note> Notes { get; private set; }
    }
}
