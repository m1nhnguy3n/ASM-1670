using ASM.Areas.Identity.Data;
using ASM.Data;
using ASM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASM.Controllers
{
    public class CartsController : Controller
    {
        private readonly UserContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartsController(UserContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            return View(_context.Carts.Where(c => c.UId == thisUserId)
                .Include(c => c.Book));
        }

        
        public async Task<IActionResult> Plus(string isbn)
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            Cart myCart = new Cart() { UId = thisUserId, BookIsbn = isbn, Quantity = 1 };
            Cart fromDb = _context.Carts.FirstOrDefault(c => c.UId == thisUserId && c.BookIsbn == isbn);
            //if not existing (or null), add it to cart. If already added to Cart before, ignore it.

            if (fromDb != null)
            {
                fromDb.Quantity++;
                _context.Update(fromDb);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(myCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Carts");
        }

        public async Task<IActionResult> Sub(string isbn)
        {
            
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            Cart myCart = new Cart() { UId = thisUserId, BookIsbn = isbn, Quantity = 1 };
            Cart fromDb = _context.Carts.FirstOrDefault(c => c.UId == thisUserId && c.BookIsbn == isbn);
            //if not existing (or null), add it to cart. If already added to Cart before, ignore it.

            if (fromDb.Quantity > 1)
            {

                if (fromDb != null)
                {
                    fromDb.Quantity--;
                    _context.Update(fromDb);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Add(myCart);
                    await _context.SaveChangesAsync();
                }
            }
            

            return RedirectToAction("Index", "Carts");
        }
        public async Task<IActionResult> Delete(string id)
        {
            string thisUserId = _userManager.GetUserId(HttpContext.User);
            Cart fromDb = _context.Carts.FirstOrDefault(c => c.UId == thisUserId && c.BookIsbn == id);

            _context.Carts.Remove(fromDb);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Carts");
        }


    }

}