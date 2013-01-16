using System;
using System.Security.Principal;

namespace WebLayer
{
    public class SimpleHttpAuthorizeAttribute : BasicHttpAuthorizeAttribute
    {
        protected override bool TryCreatePrincipal(string user, string password, out IPrincipal principal)
        {
            principal = new GenericPrincipal(new GenericIdentity(user), new string[0]);
            return "admin".Equals(user, StringComparison.OrdinalIgnoreCase) && "password".Equals(password, StringComparison.Ordinal);
        }
    }
}