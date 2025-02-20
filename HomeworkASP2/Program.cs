using HomeworkASP2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string connectionString = builder!;

//var connectionString = @"Data Source=HUAWEI;Initial Catalog=Books;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<BookDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.MapDefaultControllerRoute();


app.Run();
