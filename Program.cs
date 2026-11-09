using Pirvu_Florin_Daniel_Lab2.Data;
using Pirvu_Florin_Daniel_Lab2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pirvu_Florin_Daniel_Lab2.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Pirvu_Florin_Daniel_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pirvu_Florin_Daniel_Lab2Context' not found.");
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/MemberPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/PublisherPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});

builder.Services.AddDbContext<Pirvu_Florin_Daniel_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirvu_Florin_Daniel_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pirvu_Florin_Daniel_Lab2Context' not found.")));

builder.Services.AddDbContext<Pirvu_Florin_Daniel_Lab2.Data.LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pirvu_Florin_Daniel_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Pirvu_Florin_Daniel_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Pirvu_Florin_Daniel_Lab2.Data.LibraryIdentityContext>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
