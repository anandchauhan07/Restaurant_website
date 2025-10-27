using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restraurant.Data;

namespace Restraurant.Controllers
{
    public class MenuController : Controller
        
    {
        private readonly MenuContext _context;

        public MenuController(MenuContext context)
        {
            _context=context;
        }

        public async Task< IActionResult> Index(string searchstring)
        {
            List<Models.Dish> dishes;
            if (string.IsNullOrEmpty(searchstring))
               dishes = await _context.dishes.ToListAsync();
            else
            
                dishes=await _context.dishes
                    .Where(d=> d.Name.Contains(searchstring))
                    .ToListAsync();
            
                return View(dishes);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.dishes
            .Include(d => d.DishIngredients)
            .ThenInclude(di=> di.Ingredient)
            .FirstOrDefaultAsync(m => m.Id == id);

            return View(dish);
        }
    }
}
