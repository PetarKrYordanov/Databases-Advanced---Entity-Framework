namespace Employees.App
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    using Employees.Data;
    using Employees.Services;
    class StartUp
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(options =>
            options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<EmployeeService>();         
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
