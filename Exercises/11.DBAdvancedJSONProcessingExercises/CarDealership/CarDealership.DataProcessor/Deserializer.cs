namespace CarDealership.DataProcessor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using CarDealership.Data;
    using CarDealership.Models;

    public static class Deserializer
    {

        public static void ImportSuppliers(CarDealershipContext context, string suppliersAsString)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(suppliersAsString);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

        }

        public static void ImportSales(CarDealershipContext context)
        {
            HashSet<Sale> sales = new HashSet<Sale>();

            List<decimal> discount = new List<decimal>() { 0.0m, 0.05m, 0.1m, 0.15m, 0.20m, 0.3m, 0.4m, 0.5m };
            int[] carsById = context.Cars.Select(x => x.Id).ToArray();
            int[] customerById = context.Customers.Select(x => x.Id).ToArray();

            var random = new Random();

            for (int i = 0; i <= 500; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = carsById[random.Next(0, carsById.Length)],
                    CustomerId = customerById[random.Next(0, customerById.Length)],
                    Discount = discount[random.Next(0, discount.Count)]
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        public static void ImportCars(CarDealershipContext context, string carsAsString)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(carsAsString);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            var partsId = context.Parts.Select(x => x.Id).ToArray();
            var carsId = context.Cars.Select(x => x.Id).ToArray();
            var random = new Random();
            var carsParts = new List<PartCar>();

            for (int i = 0; i < carsId.Length; i++)
            {
                for (int j = 0; j < random.Next(15, 20); j++)
                {
                    var carPart = new PartCar()
                    {
                        CarId = carsId[i],
                        PartId = partsId[random.Next(1, partsId.Length)]
                    };
                    if (carsParts.Any(x => x.CarId == carPart.CarId && x.PartId == carPart.PartId))
                    {
                        continue;
                    }
                    carsParts.Add(carPart);
                }
            }

            context.PartCars.AddRange(carsParts);
            context.SaveChanges();
        }

        public static void ImportParts(CarDealershipContext context, string partsAsString)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(partsAsString);


            var random = new Random();
            var suppliersId = context.Suppliers.Select(x => x.Id).ToArray();

            foreach (var item in parts)
            {

                item.SupplierId = suppliersId[random.Next(0, suppliersId.Count())];

            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        public static void ImportCustomers(CarDealershipContext context, string customersAsString)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(customersAsString);

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
