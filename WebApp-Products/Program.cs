//using BLL;
//using BOL;
//using DAL;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApp_Products.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<ManageProductsContext>(Options =>Options.UseSqlServer(builder.Configuration.GetConnectionString("DbProductsConnection")));




//builder.Services.AddTransient<Product>();

//builder.Services.AddTransient<ProductDA>();
//builder.Services.AddTransient<ProductBL>();

//builder.Services.AddTransient<UserDA>();
//builder.Services.AddTransient<UserBL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}");

app.Run();


// name: "default",
//pattern: "/{controller=Home}/{action=Index}/{id?}");
// pattern: "{api}/{controller}/{action}/{id?}");