using System.Web.Http;

namespace WebLayer.Controllers
{
    [SimpleHttpAuthorize]
    public class AuthenticationController : ApiController
    {
        public bool Get()
        {
            return true;
        }
    }
}
