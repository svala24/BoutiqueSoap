using BoutiqueSoap.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace BoutiqueSoap.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BoutiqueSoapContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BoutiqueSoapContext>>()))
        {
            // Look for any movies.
            if (context.Soap.Any())
            {
                return;   // DB has been seeded
            }
            context.Soap.AddRange(
                new Soap
                {
                    Name = "Aloe Vera Fresh",
                    Scent = "Mild Aloe",
                    Weight = "120 grams",
                    Price = "$4.50",
                    Description = "Refreshing soap with soothing aloe vera."
                },
                new Soap
                {
                    Name = "Oatmeal Delight",
                    Scent = "Beige",
                    Weight = "130 grams",
                    Price = "$5.00",
                    Description = "Gentle exfoliating soap with oatmeal."
                },
                new Soap
                {
                    Name = "Rose Petal Luxury",
                    Scent = "Rose",
                    Weight = "140 grams",
                    Price = "$8.99",
                    Description = "Luxurious soap with rose petal extract."
                },
                new Soap
                {
                    Name = "Coconut Cream",
                    Scent = "Coconut",
                    Weight = "125 grams",
                    Price = "$6.50",
                    Description = "Moisturizing soap with coconut oil."
                },
                new Soap
                {
                    Name = "Citrus Burst",
                    Scent = "Beige",
                    Weight = "130 grams",
                    Price = "$5.00",
                    Description = "Gentle exfoliating soap with oatmeal."
                },
                new Soap
                {
                    Name = "Lavender Bliss",
                    Scent = "Lavender",
                    Weight = "150 grams",
                    Price = "$7.99",
                    Description = "Calming soap with lavender essence."
                }
            );
            context.SaveChanges();
        }
    }
}