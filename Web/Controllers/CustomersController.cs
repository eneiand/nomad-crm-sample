using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using ViewModels;
using YetAnotherCRM;

namespace WebLayer.Controllers
{
    /*
     * Useful Fiddler request to test the Web API
            
            Host: localhost:51708
            Connection: keep-alive
            Cache-Control: max-age=0
            Authorization: Basic YWRtaW46cGFzc3dvcmQ=
            User-Agent: Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11
            Accept: application/json
            Accept-Encoding: gzip,deflate,sdch
            Accept-Language: en-GB,en-US;q=0.8,en;q=0.6
            Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3
            Cookie: glimpsePolicy=On; glimpseKeepPopup=null; glimpseState=null; glimpseClientName=null; glimpseOptions=null
     */

    [SimpleHttpAuthorize]
    public class CustomersController : ApiController
    {
        // GET api/values
        public IEnumerable<CustomerViewModel> Get()
        {
            Database.SetInitializer(new InitializerWithTestData());
            using (var context = new CrmContext())
            {
                return context.Customers.ToList().Select(customer => new CustomerViewModel(customer)).ToList();
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public object Post(CustomerViewModel value)
        {
            //Validate something about your input
            if (value == null)
                throw new ArgumentException();

            using (var crmContext = new CrmContext())
            {
                //Find the record in the DB
                Customer customer = crmContext.Customers.Find(value.CustomerId);

                if (customer != null)
                {
                    //Update the record
                    value.ApplyToCustomer(customer);

                    //Save the crmContext back
                    crmContext.SaveChanges();

                    return new
                               {
                                   Success = true,
                                   ViewModel = new CustomerViewModel(customer)
                               };
                }
            }

            return new
                       {
                           Success = false
                       };
        }

        // PUT api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}