namespace CarDealership.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using CarDealership.Data;
    using CarDealership.DataProcessor.ImpportDtos;
    using CarDealership.Models;
    public static class Deserializer
    {

        public static void ImportSuppliers(CarDealershipContext context, string suppliersAsString)
        {
            var suppliersListDto = new List<SupplierDto>();
            var suppliers = new List<Supplier>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<SupplierDto>), new XmlRootAttribute("suppliers"));

            using (TextReader reader = new StringReader(suppliersAsString))
            {
                suppliersListDto = (List<SupplierDto>)serializer.Deserialize(reader);
            }

            foreach (var item in suppliersListDto)
            {
                var suplier = new Supplier()
                {
                    Name = item.Name,
                    IsImporter = item.IsImporter
                };
                suppliers.Add(suplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

        }

        public static void ImportSales(CarDealershipContext context)
        {
            HashSet<Sale> sales = new HashSet<Sale>();

            List<double> discount = new List<double>() { 0.0, 0.05, 0.1, 0.15, 0.20, 0.3, 0.4, 0.5 };
            int[] carsById = context.Cars.Select(x => x.Id).ToArray();
            int[] customerById = context.Customers.Select(x => x.Id).ToArray();

            var random = new Random();

            for (int i = 0; i <= 500; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = carsById[random.Next(0, carsById.Length)],
                    CustomerId = customerById[random.Next(0,customerById.Length)],
                    Discount = discount[random.Next(0,discount.Count)]
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        public static void ImportCars(CarDealershipContext context, string carsAsString)
        {
            var carListDto = new List<CarDto>();
            var carsParts = new List<PartCar>();
            var cars = new List<Car>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<CarDto>), new XmlRootAttribute("cars"));

            using (TextReader reader = new StringReader(carsAsString))
            {
                carListDto = (List<CarDto>)serializer.Deserialize(reader);
            }
            var random = new Random();

            foreach (var item in carListDto)
            {
                var car = new Car()
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TravelDistance,

                };
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            var partsId = context.Parts.Select(x => x.Id).ToArray();
            var carsId = context.Cars.Select(x => x.Id).ToArray();

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
            var partListDto = new List<PartDto>();
            var parts = new List<Part>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<PartDto>), new XmlRootAttribute("parts"));

            using (TextReader reader = new StringReader(partsAsString))
            {
                partListDto = (List<PartDto>)serializer.Deserialize(reader);
            }
            var random = new Random();
            var suppliersId = context.Suppliers.Select(x => x.Id).ToArray();

            foreach (var item in partListDto)
            {
                var part = new Part()
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    SupplierId = random.Next(1, suppliersId.Count())
                };
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        public static void ImportCustomers(CarDealershipContext context, string suppliersAsString)
        {
            var customersListDto = new List<CustomerDto>();
            var customers = new List<Customer>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerDto>), new XmlRootAttribute("customers"));

            using (TextReader reader = new StringReader(suppliersAsString))
            {
                customersListDto = (List<CustomerDto>)serializer.Deserialize(reader);
            }

            foreach (var item in customersListDto)
            {
                var customer = new Customer()
                {
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    IsYoungDriver = item.IsYoungDriver
                };
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
