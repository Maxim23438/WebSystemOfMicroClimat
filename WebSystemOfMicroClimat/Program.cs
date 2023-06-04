using Microsoft.EntityFrameworkCore;
using WebSystemOfMicroClimat.Data;
using WebSystemOfMicroClimat.Data.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSystemOfMicroClimat.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IServiceCollection services = builder.Services;
services.AddScoped<IUsersService, UsersService>();
services.AddScoped<IValuesService, ValuesService>();
services.AddScoped<ITempService, TempService>();
services.AddScoped<ILightService, LightService>();
services.AddScoped<IHumidityService, HumidityService>();
services.AddScoped<IReviewService, ReviewService>();

var emailSettings = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
//services.AddSingleton<EmailSettings>(emailSettings);
services.AddScoped<IEmailService, EmailService>();
//Console.WriteLine(emailSettings.Username);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//AddDbInitializer.Seed(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BasePage}/{action=Index}/{id?}");

var scp = app.Services.CreateScope();

var db = scp.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

//new ArduinoService("https://dweet.io:443/get/latest/dweet/for/NULP",1000,db).Start();
app.Run();
