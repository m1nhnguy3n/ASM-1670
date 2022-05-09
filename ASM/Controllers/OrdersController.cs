using ASM.Areas.Identity.Data;
using ASM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UserContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrdersController(UserContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            return View(_context.Orders.Where(c => c.UId == thisUserId));
        }
        public IActionResult OrderHistory()
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            return View(_context.Orders.Where(c => c.UId == thisUserId));
        }

        public async Task<IActionResult> Detail(int id)
        {
            return View(_context.OrderDetails.Where(a => a.OrderId == id).Include(a => a.Book));
        }



    }
}

