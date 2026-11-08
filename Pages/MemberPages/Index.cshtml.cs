using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pirvu_Florin_Daniel_Lab2.Models;

namespace Pirvu_Florin_Daniel_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Pirvu_Florin_Daniel_Lab2Context _context;

    public IndexModel(Pirvu_Florin_Daniel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Member.ToListAsync();
    }
}
