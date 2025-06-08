using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            //,sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

            builder.Services.AddAutoMapper(typeof(LibrarianMapper),typeof(BookMapper));
            builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ISalesRepository,SalesRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static void SalesRepository()
        {
            throw new NotImplementedException();
        }
    }
}
