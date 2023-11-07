using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// Required namesspaces
using WestWindSystem.DAL;
using WestWindSystem.BLL;

namespace WestWindSystem
{
	public static class BackEndExtensions
	{
		public static void WWBackEndDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
		{
			// Register all the services that the system provides
			services.AddDbContext<WestWindContext>(options);

			// Register services classes as transient services
			services.AddTransient<CustomerServices>((ServiceProvider) =>
			{
				var context = ServiceProvider.GetService<WestWindContext>();
				
				return new CustomerServices(context!);
			});

            services.AddTransient<CategoryServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();

                return new CategoryServices(context!);
            });

            services.AddTransient<ProductServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();

                return new ProductServices(context!);
            });

        }
	}
}