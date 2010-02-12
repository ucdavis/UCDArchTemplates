using System.Web.Mvc;
using UCDArchTemplates.Models;

namespace UCDArchTemplates.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            var customers = Customer.GetAll();

            return View(customers);
        }

    }
}
