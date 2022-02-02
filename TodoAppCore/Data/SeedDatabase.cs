using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoAppCore.Entities;

namespace TodoAppCore.Data
{
    public class SeedDatabase
    {
        public static async Task Seed(DbContext context, UserManager<AppUser> userManager)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                if (context is AppDbContext)
                {
                    var _context = (AppDbContext)context;

                    AppUser user = new AppUser()
                    {
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                    };
                    await userManager.CreateAsync(user, "123456");

                    if ((await _context.Todos.ToListAsync()).Any())
                    {
                        await _context.Todos.AddRangeAsync(new List<Todo>()
                        {
                            new Todo()
                            {
                                AppUserId = user.Id,
                                Content = "Seed todo content",
                                Title = "Seed todo",
                                CreatedDate = DateTime.Now,
                                IsCompleted = false,
                                IsDeleted = false,
                            },
                            new Todo()
                            {
                                AppUserId = user.Id,
                                Content = "Seed todo content 2",
                                Title = "Seed todo 2",
                                CreatedDate = DateTime.Now.AddDays(-2),
                                IsCompleted = true,
                                IsDeleted = false,
                            }
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
