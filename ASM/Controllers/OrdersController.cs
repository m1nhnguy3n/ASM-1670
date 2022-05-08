using ASM.Areas.Identity.Data;
using ASM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}

