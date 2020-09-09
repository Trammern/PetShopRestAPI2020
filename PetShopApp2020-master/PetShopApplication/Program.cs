using Microsoft.Extensions.DependencyInjection;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.ApplicationServices.Services;
using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using PetShopApp.Infrastructure.Data;
using System;
using System.Runtime.CompilerServices;

namespace PetShopApplication
{
    public class Program
    {

        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetServices>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();

        }






    }
}
