using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.AppDbContext _context;

        public IndexModel(WebApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItems.ToListAsync();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();

            todo.IsDone = !todo.IsDone;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
