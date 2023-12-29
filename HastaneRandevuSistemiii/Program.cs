using HastaneRandevuSistemiii.Data;
using HastaneRandevuSistemiii.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HastaneRandevuuContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//  builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<HastaneRandevuuContext>();
builder.Services.AddIdentity<Kullanici,IdentityRole>()
     .AddDefaultTokenProviders()
     .AddDefaultUI()
     .AddEntityFrameworkStores<HastaneRandevuuContext>();

///////Password
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Password.RequiredLength = 3;
});

var options = new JsonSerializerOptions()
{
    ReferenceHandler = ReferenceHandler.Preserve,
};

//var json = JsonSerializer.Serialize(obj, options);

//  builder.Services.ConfigureApplicationCookie(options=>
//  options.AccessDeniedPath=)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
