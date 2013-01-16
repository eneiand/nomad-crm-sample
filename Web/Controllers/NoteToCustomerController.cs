using System;
using System.Web.Http;
using System.Web.Mvc;
using ViewModels;
using YetAnotherCRM;

namespace WebLayer.Controllers
{
    [SimpleHttpAuthorize]
    public class NoteToCustomerController : ApiController
    {
        public string Get()
        {
            return "value";
        }

        // POST new notes
        public object Post(NoteToCustomerModel value)
        {
            //Validate something about your input
            if (value == null)
                throw new ArgumentException();

            if (value.Content == "")
                throw new ArgumentException();
            
            var note = value.Content.Trim(' ');

            using (var crmContext = new CrmContext())
            {
                //Find the record in the DB
                var customer = crmContext.Customers.Find(value.CustomerId);

                if (customer != null)
                {
                    var newNote = new Note(note);
                    customer.Notes.Add(newNote);
                    crmContext.SaveChanges();

                    return new
                               {
                                   Success = true,
                                   ViewModel = new CustomerViewModel(customer)
                               };
                }

                return new
                           {
                               Success = false,
                               ViewModel = ""
                           };

            }
        }

    }
}
