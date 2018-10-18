using Microsoft.AspNetCore.Mvc;

namespace Sforex4u.Controllers
{

    public class ErrorController : Controller {

        public ViewResult Error() => View();
    }
}
