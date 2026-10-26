using Microsoft.EntityFrameworkCore;

public class Pirvu_Florin_Daniel_Lab2Context(DbContextOptions<Pirvu_Florin_Daniel_Lab2Context> options) : DbContext(options)
{
    public DbSet<Pirvu_Florin_Daniel_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Pirvu_Florin_Daniel_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Pirvu_Florin_Daniel_Lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Pirvu_Florin_Daniel_Lab2.Models.Category> Category { get; set; } = default!;
}
