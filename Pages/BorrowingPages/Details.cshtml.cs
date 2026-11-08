using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pirvu_Florin_Daniel_Lab2.Models;

namespace Pirvu_Florin_Daniel_Lab2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Pirvu_Florin_Daniel_Lab2Context _context;
    public DetailsModel(Pirvu_Florin_Daniel_Lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        else
        {
            Borrowing = borrowing;
        }

        return Page();
    }
}
