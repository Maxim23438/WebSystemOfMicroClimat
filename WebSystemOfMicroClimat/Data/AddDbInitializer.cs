using Microsoft.AspNetCore.Builder;
using WebSystemOfMicroClimat.Models;

namespace WebSystemOfMicroClimat.Data
{
    public class AddDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if(context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Name = "Maks",
                            Email = "maxim.milinevskiy@gmail.com",
                            Password = "123456",
                            House = false,
                            Flat = false,
                            GreenHouse = false
                        }
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
