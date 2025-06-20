using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCProject.Customfilters;
using MVCProject.Mapper;
using MVCProject.Models;
using MVCProject.Repository;
using System;

namespace MVCProject
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                   
                }
                )
                .AddEntityFrameworkStores<LibraryContext>();
               
            builder.Services.AddAutoMapper(typeof(LibrarianMapper),typeof(BookMapper));
            builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICategoriesRepository, CategoeriesRepository>();
            builder.Services.AddScoped<ISalesRepository,SalesRepository>();
            builder.Services.AddScoped<IUserRepository, UsersRepository>();
            builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();

            // Exception Handiling By Using Customm Filter ,,,,!

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<MyFilters>();
            });


            builder.Services.AddControllersWithViews();
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
         
            app.MapStaticAssets();

            app.MapControllerRoute("Route1" , "DisplayAll" ,new
            {
                Controller = "Book" , action = "DisplayAllBooksForLibrarian"

            });

            app.MapControllerRoute("Route1", "AllBooks", new
            {
                Controller = "Book",
                action = "DisplayAllBooksForUser"

            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        
    }
}
