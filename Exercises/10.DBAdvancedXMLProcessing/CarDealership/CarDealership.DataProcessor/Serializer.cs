namespace CarDealership.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Xml;
    using System.Data.Sql;
    using System.Data;

    using Data;
    using ExportDtos;
    using System.IO;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        public static string GetCarsWithDistance(CarDealershipContext context)
        {

            var cars = context.Cars
                .Where(e => e.TravelledDistance > 2000000)
                .Select(e => new CarDto
                {
                    Make = e.Make,
                    Model = e.Model,
                    TravelledDistance = e.TravelledDistance
                })
                .OrderBy(e => e.Make)
                .ThenBy(e => e.Model)
                .ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString();
        }

        public static string GetCarsWithListOfParts(CarDealershipContext context)
        {
            var cars = context.Cars         
           .Select(e => new CarWithPartsDto
           {
               Make = e.Make,
               Model = e.Model,
               TravelledDistance = e.TravelledDistance,
               Parts =e.CarParts.Select(x=> new PartListDto()
               {
                   Name = x.Part.Name,
                   Price = x.Part.Price
               }).ToList()
           })
           .OrderBy(e => e.Make)
           .ThenBy(e => e.Model)
           .ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(CarWithPartsDto[]), new XmlRootAttribute("cars"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString();
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

                currentSale.CustomerName = sale.Customer.Name;
                currentSale.IsYoungDriver = sale.Customer.IsYoungDriver;
                currentSale.Car.Model = sale.Car.Model;
                currentSale.Car.Make = sale.Car.Make;
                currentSale.Car.TravelledDistance = sale.Car.TravelledDistance;

                if (currentSale.IsYoungDriver)
                {
                    currentSale.Discount = sale.Discount + 0.05;
                }
                else
                {
                    currentSale.Discount = sale.Discount;
                }

                decimal partsPrice = 0;

                foreach (var carPart in sale.Car.CarParts)
                {
                   var currentPartPrice = carPart.Part.Price;
                    partsPrice += currentPartPrice;
                }

                currentSale.Price = partsPrice;
                currentSale.DiscountPrice = (1m - (decimal)currentSale.Discount) * partsPrice;

                discountSales.Add(currentSale);
            }
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(List<SalesWithAppliedDiscount>), new XmlRootAttribute("sales"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), discountSales, xmlNamespaces);

            return sb.ToString();

        }

        public static string TotalSalesByCustomer(CarDealershipContext context)
        {
            var customers = context.Customers
                .Include(e => e.Sales)
                .ThenInclude(e => e.Car)
                .ThenInclude(e => e.CarParts)
                .ThenInclude(e=>e.Part)
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

                    foreach (var part in sale.Car.CarParts.Select(x=>x.Part.Price))
                    {
                        partsPrice += part;
                    }
                    salePrice = (1m - (decimal)saleDiscount) * partsPrice;                    
                    spentMoney += salePrice;
                }
                totalSalesByCustomer.MoneySpent = Math.Round(spentMoney,2);
                salesByCustomer.Add(totalSalesByCustomer);
            }
            salesByCustomer = salesByCustomer
                .OrderByDescending(x => x.MoneySpent)
                .ThenByDescending(x => x.BoughtCars).ToList();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(List<TotalSalesByCustomerDto>), new XmlRootAttribute("customers"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), salesByCustomer, xmlNamespaces);

            return sb.ToString();

        }

        public static string GetLocalSuppliers(CarDealershipContext context)
        {
            var suppliers = context.Suppliers
               .Where(e => e.IsImporter == false)
             .Select(e=> new LocalSupplierDto()
             {
                 Id = e.Id,
                 Name = e.Name,
                 PartsCount = e.Parts.Count
             })
             .OrderByDescending(e=>e.PartsCount)
               .ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(LocalSupplierDto[]), new XmlRootAttribute("supliers"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), suppliers, xmlNamespaces);

            return sb.ToString();
        }

        public static string GetFerrariCars(CarDealershipContext context)
        {
            var cars = context.Cars
                .Where(e => e.Make =="Ferrari")
                .OrderBy(e=>e.Model)
                .ThenByDescending(e=>e.TravelledDistance)
                .Select(e => new FerrariCarsDto
                {
                    Id = e.Id,
                    Model = e.Model,
                    TravelledDistance = e.TravelledDistance
                })               
                .ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(FerrariCarsDto[]), new XmlRootAttribute("cars"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            return sb.ToString();
        }
    }
}
