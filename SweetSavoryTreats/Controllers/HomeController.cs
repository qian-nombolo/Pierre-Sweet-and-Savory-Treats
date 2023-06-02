using Microsoft.AspNetCore.Mvc;
using SweetSavoryTreats.Models;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavoryTreats.Controllers
{
    public class HomeController : Controller
    {

      private readonly SweetSavoryTreatsContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public HomeController(UserManager<ApplicationUser> userManager, SweetSavoryTreatsContext db)
      {
        _userManager = userManager;
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Treat[] treats = _db.Treats.OrderByDescending(treat => treat.TreatRate).ToArray();
        Flavor[] flavors = _db.Flavors.OrderBy(flavor  => flavor.FlavorName).ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
                
        model.Add("recipes", treats);
        model.Add("flavors", flavors);
                
        return View(model);
      }      

    }
}