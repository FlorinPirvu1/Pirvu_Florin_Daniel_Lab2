using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pirvu_Florin_Daniel_Lab2.Models;
using Pirvu_Florin_Daniel_Lab2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Pirvu_Florin_Daniel_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Pirvu_Florin_Daniel_Lab2Context _context;

    public IndexModel(Pirvu_Florin_Daniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;
    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();

        CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
                .ThenInclude(c => c.Book)
                    .ThenInclude(b => b.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;
            Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();
            CategoryData.Books = category.BookCategories.Select(s => s.Book);
        }
    }
}