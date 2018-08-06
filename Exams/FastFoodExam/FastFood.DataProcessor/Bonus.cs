using System;
using System.Linq;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
            var result = string.Empty;

            if (!context.Items.Any(e=>e.Name ==itemName))
            {
                return result = $"Item {itemName} not found!";
            }

            var item = context.Items.FirstOrDefault(e => e.Name == itemName);
            var oldPrice = item.Price;
            item.Price = newPrice;
            context.Items.Update(item);
            context.SaveChanges(); 

            result = $"{itemName} Price updated from ${oldPrice:f2} to ${newPrice}";
            return result;
	    }
    }
}
