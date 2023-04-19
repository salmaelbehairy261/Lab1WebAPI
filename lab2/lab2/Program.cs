using lab2.DAL;
using lab2.BL;
using Microsoft.EntityFrameworkCore;
using lab2.BL.Managers.Tickets;
using lab2.BL.Managers.Department;
using lab2.DAL.Repos.Department;

namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("Database");
            builder.Services.AddDbContext<DAL.Models.Context>(
                options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketRepo, TicketRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            builder.Services.AddScoped<ITicketManager,TicketManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}