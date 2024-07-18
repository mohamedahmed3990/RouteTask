
using Microsoft.EntityFrameworkCore;
using OrderSystem.APIs.Extentions;
using OrderSystem.APIs.Helper;
using OrderSystem.Core;
using OrderSystem.Core.Services.Contract;
using OrderSystem.Repository;
using OrderSystem.Repository.Data;
using OrderSystem.Repository.Identity;
using OrderSystem.Service;
using System.Threading.RateLimiting;

namespace OrderSystem.APIs
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

            builder.Services.AddDbContext<OrderManagementDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "OrderManagementSystemDb");
            });


            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "IdentityOrderManagementSystemDb");
            });


            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            builder.Services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

            builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

            builder.Services.AddScoped(typeof(IInvoiceService), typeof(InvoiceService));

            builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));

            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddIdentityService(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
