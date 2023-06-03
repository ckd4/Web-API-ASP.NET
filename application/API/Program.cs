using BusinessLogic.Services;
using DataAccess;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Context>(
                options => options.UseSqlServer("Server=DB-COL-SMIRNOVTORTURELETMEOUT.mssql.somee.com; Database=DB-COL-SMIRNOVTORTURELETMEOUT; User Id=ah308; Password=3221488228;"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

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