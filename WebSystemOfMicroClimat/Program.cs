using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Data;
using WebSystemOfMicroClimat.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IServiceCollection services = builder.Services;
services.AddScoped<IUsersService, UsersService>();

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
//AddDbInitializer.Seed(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Create}/{id?}");


app.Run();