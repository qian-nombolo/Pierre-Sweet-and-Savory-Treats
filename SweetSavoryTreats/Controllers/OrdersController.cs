using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SweetSavoryTreats.Models;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavoryTreats.Controllers
{
  [Authorize]

  public class OrdersController : Controller
  {
    private readonly SweetSavoryTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(UserManager<ApplicationUser> userManager, SweetSavoryTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      List<Order> userOrders = _db.Orders
      .Where(entry => entry.User.Id == currentUser.Id)
      .OrderBy(order => order.OrderAmount).ToList();                            
      return View(userOrders);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
      if (!ModelState.IsValid)
      {
        return View(order);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

        order.User = currentUser;

        _db.Orders.Add(order);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      
    }
   
    public ActionResult Details(int id)
    {
      Order thisOrder = _db.Orders
                             .Include(order => order.OTJoinEntities)
                             .ThenInclude(join => join.Treat)
                             .FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    public async Task<ActionResult> Edit(int id)
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      if (thisOrder.User == currentUser)
      {
        return View(thisOrder);
      }
      else
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public ActionResult Edit(Order order)
    {
      if (!ModelState.IsValid)
      {
        return View(order);
      }
      else
      {
        _db.Orders.Update(order);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public async Task<ActionResult> Delete(int id)
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      if (thisOrder.User == currentUser)
      {
        return View(thisOrder);
      }
      else
      {
        return RedirectToAction("Index");
      }
      
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Order thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      _db.Orders.Remove(thisOrder);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> AddTreat(int id)
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      // order should have all the treat to choose
      List<Treat> allTreats = _db.Treats
                                .OrderBy(treat => treat.TreatName)
                                .ToList();

      Order thisOrder = _db.Orders.FirstOrDefault(order=> order.OrderId == id);
      
      ViewBag.TreatId = new SelectList(allTreats, "TreatId", "TreatName");
      
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult AddTreat(Order order, int treatId)
    {
      #nullable enable
      OrderTreat? otjoinEntity = _db.OrderTreats.FirstOrDefault(otjoin => (otjoin.TreatId == treatId && otjoin.OrderId == order.OrderId));
      #nullable disable

      if (otjoinEntity == null && treatId != 0)
      {
        _db.OrderTreats.Add(new OrderTreat() { TreatId = treatId, OrderId = order.OrderId });
        _db.SaveChanges();
      }

      return RedirectToAction("Details", new { id = order.OrderId });
    }  

    [HttpPost]
    public async Task<ActionResult> DeleteJoin(int otjoinId)
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);

      OrderTreat otjoinEntry = _db.OrderTreats.FirstOrDefault(entry => entry.OrderTreatId == otjoinId);
      Order thisOrder = _db.Orders.FirstOrDefault(entry => entry.OrderId == otjoinEntry.OrderId);

      if (thisOrder.User == currentUser)
      {
        _db.OrderTreats.Remove(otjoinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
    }

  }
}
 
