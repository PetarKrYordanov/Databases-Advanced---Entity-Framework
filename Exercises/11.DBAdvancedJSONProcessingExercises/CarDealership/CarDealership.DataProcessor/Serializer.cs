namespace CarDealership.DataProcessor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using ExportDtos;

    public class Serializer
    {
        public static string OrderedCustomers(CarDealershipContext context)
        {

            var customers = context.Customers
                  .OrderBy(x => x.BirthDate)
                  .ThenBy(x => x.IsYoungDriver)
                  .Select(x => new
                  {
                      Id = x.Id,
                      Name = x.Name,
                      BirthDate = x.BirthDate,
                      IsYoungDriver = x.IsYoungDriver,
                      Sales = x.Sales
                  }).ToArray();

            var customersJson = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore
            });
            return customersJson;
        }

        public static string GetCarsWithListOfParts(CarDealershipContext context)
        {
            var cars = context.Cars
           .Select(e => new
           {
               Make = e.Make,
               Model = e.Model,
               TravelledDistance = e.TravelledDistance,
               Parts = e.CarParts.Select(x => new
               {
                   Name = x.Part.Name,
                   Price = x.Part.Price
               }).ToArray()
           })

           .ToArray();

            var carsJson = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore
            });
            return carsJson;
        }

        public static string GetSalesWithAppliedDicount(CarDealershipContext context)
        {
            var sales = context.Sales
                .Include(e => e.Customer)
                .Include(e => e.Car)
                .ThenInclude(e => e.CarParts)
                .ThenInclude(e => e.Part)
                .Where(e => e.Discount > 0)
                .ToArray();

            List<SalesWithAppliedDiscount> discountSales = new List<SalesWithAppliedDiscount>();
            foreach (var sale in sales)
            {
                var currentSale = new SalesWithAppliedDiscount();

                currentSale.customerName = sale.Customer.Name;
                currentSale.Car.Model = sale.Car.Model;
                currentSale.Car.Make = sale.Car.Make;
                currentSale.Car.TravelledDistance = sale.Car.TravelledDistance;


                currentSale.discount = sale.Discount;


                decimal partsPrice = 0;

                foreach (var carPart in sale.Car.CarParts)
                {
                    var currentPartPrice = carPart.Part.Price;
                    partsPrice += currentPartPrice;
                }

                currentSale.price = partsPrice;
                currentSale.priceWithDiscount = (1m - (decimal)currentSale.discount) * partsPrice;

                discountSales.Add(currentSale);
            }

            var discountSalesString = JsonConvert.SerializeObject(discountSales, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });


            return discountSalesString;

        }

        public static string TotalSalesByCustomer(CarDealershipContext context)
        {
            var customers = context.Customers
                .Include(e => e.Sales)
                .ThenInclude(e => e.Car)
                .ThenInclude(e => e.CarParts)
                .ThenInclude(e => e.Part)
                .Where(x => x.Sales.Count > 0)
                .ToArray();

            List<TotalSalesByCustomerDto> salesByCustomer = new List<TotalSalesByCustomerDto>();
            foreach (var customer in customers)
            {
                var totalSalesByCustomer = new TotalSalesByCustomerDto();
                totalSalesByCustomer.FullName = customer.Name;

                totalSalesByCustomer.BoughtCars = customer.Sales.Count;

                var spentMoney = 0M;

                foreach (var sale in customer.Sales)
                {
                    var partsPrice = 0m;
                    var saleDiscount = sale.Discount;
                    var salePrice = 0m;

                    foreach (var part in sale.Car.CarParts.Select(x => x.Part.Price))
                    {
                        partsPrice += part;
                    }
                    salePrice = (1m - (decimal)saleDiscount) * partsPrice;
                    spentMoney += salePrice;
                }
                totalSalesByCustomer.MoneySpent = Math.Round(spentMoney, 2);
                salesByCustomer.Add(totalSalesByCustomer);
            }
            salesByCustomer = salesByCustomer
                .OrderByDescending(x => x.MoneySpent)
                .ThenByDescending(x => x.BoughtCars).ToList();

            //var customers = context.Customers.Where(e=>e.Sales.Count>=1)
            //    //.Include(e => e.Sales)
            //    //.ThenInclude(e => e.Car)
            //    //.ThenInclude(e => e.CarParts)
            //    //.ThenInclude(e => e.Part)
            //    .Select(s => new
            //    {
            //        fullName =s.Name,
            //        boughtCars = s.Sales.Count,
            //        spentMoney = s.Sales.Sum(x=>x.Car.CarParts.Sum(e=>e.Part.Price))
            //        -(s.Sales.Sum(x=>x.Car.CarParts.Sum(e=>e.Part.Price))
            //        *s.Sales.Sum(k=>k.Discount)/100)
            //    })
            //    .OrderByDescending(e=>e.spentMoney)
            //    .ThenByDescending(e=>e.boughtCars)
            //    .ToArray();



            var customersJson = JsonConvert.SerializeObject(salesByCustomer, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return customersJson;


        }

        public static string GetLocalSuppliers(CarDealershipContext context)
        {
            var suppliers = context.Suppliers
               .Where(e => e.IsImporter == false)
             .Select(e => new LocalSupplierDto()
             {
                 Id = e.Id,
                 Name = e.Name,
                 PartsCount = e.Parts.Count
             })
             .OrderByDescending(e => e.PartsCount)
             .OrderBy(e => e.Name)
             .ThenByDescending(e => e.PartsCount)
               .ToArray();

            var localSuppliers = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return localSuppliers;
        }

        public static string GetToyotaCars(CarDealershipContext context)
        {
            var cars = context.Cars
                .Where(e => e.Make == "Toyota")
                .OrderBy(e => e.Model)
                .ThenByDescending(e => e.TravelledDistance)
                .Select(e => new
                {
                    Id = e.Id,
                    Make = e.Make,
                    Model = e.Model,
                    TravelledDistance = e.TravelledDistance
                })
                .ToArray();

            var toyotaCars = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return toyotaCars;
        }
    }
}
