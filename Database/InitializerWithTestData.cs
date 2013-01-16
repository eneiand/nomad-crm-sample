using System.Collections.Generic;
using System.Data.Entity;

namespace YetAnotherCRM
{
    public class InitializerWithTestData : CreateDatabaseIfNotExists<CrmContext>
    {
        protected override void Seed(CrmContext context)
        {
            context.Customers.Add(new Customer("Kevin", "Boyle", "Newnham House", "Cambridge", "CB4 0ZW", "kevin.boyle@red-gate.com", "07919888074", new List<Note>
                                                                                                                                                         {
                                                                                                                                                             new Note("all these constuctors were a bad idea")
                                                                                                                                                         }));
            context.Customers.Add(new Customer("James", "Kirk", "Enterprise", "Space", "SP1 7EN", "james.kirk@starfleet.com", "1701001701", new List<Note>
                                                                                                                                                         {
                                                                                                                                                             new Note("Beam me up scotty")
                                                                                                                                                         }));
        }
    }
}
