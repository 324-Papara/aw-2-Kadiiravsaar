
using Microsoft.EntityFrameworkCore;
using Papara.Data.Context;
using Papara.Data.UnitOfWork;
using System.Text.Json.Serialization;

namespace Papara.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				options.JsonSerializerOptions.WriteIndented = true;
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			}); 
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			string connectionStringMsSql = builder.Configuration.GetConnectionString("MsSqlConnection");
			builder.Services.AddDbContext<PaparaMsSqlDbContext>(x => x.UseSqlServer(connectionStringMsSql));


			// diðer bir yol => 
			// SQL Server için DbContext
			// services.AddDbContext<PaparaSqlDbContext>(options =>
			//  options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));


			//var connectionStringPostgre = builder.Configuration.GetConnectionString("PostgresSqlConnection");
			//builder.Services.AddDbContext<PaparaPostgreDbContext>(options => options.UseNpgsql(connectionStringPostgre));

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
