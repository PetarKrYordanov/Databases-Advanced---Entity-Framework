namespace CarDealership
{
    using System;

    using Data;
    using System.Text;
    using System.IO;
    using CarDealership.DataProcessor;

    class StartUp
    {
        static void Main(string[] args)
        {
            InitializeDatabase();
            ImportData();
            ExportData();
        }

        private static void ExportData()
        {
            using (var context = new CarDealershipContext())
            {
                string carsWithDistance = Serializer.GetCarsWithDistance(context);
                File.WriteAllText(@"..\..\..\ExportXml\cars.xml", carsWithDistance, Encoding.UTF8);

                string ferrariCars = Serializer.GetFerrariCars(context);
                File.WriteAllText(@"..\..\..\ExportXml\ferrari-cars.xml", ferrariCars, Encoding.UTF8);

                string localSuppliers = Serializer.GetLocalSuppliers(context);
                File.WriteAllText(@"..\..\..\ExportXml\local-suppliers.xml", localSuppliers, Encoding.UTF8);

                string carsAndParts = Serializer.GetCarsWithListOfParts(context);
                File.WriteAllText(@"..\..\..\ExportXml\cars-and-parts.xml", carsAndParts, Encoding.UTF8);

                string salesByCustomers = Serializer.TotalSalesByCustomer(context);
                File.WriteAllText(@"..\..\..\ExportXml\customers-total-sales.xml", salesByCustomers, Encoding.UTF8);

                string salesWithApliedDiscount = Serializer.GetSalesWithAppliedDicount(context);
                File.WriteAllText(@"..\..\..\ExportXml\sales-discounts.xml", salesWithApliedDiscount, Encoding.UTF8);
            }
        }

        private static void ImportData()
        {

            using (var context = new CarDealershipContext())
            {
              

                string suppliersAsString = File.ReadAllText(@"..\..\..\ImportXml\suppliers.xml");
                Deserializer.ImportSuppliers(context, suppliersAsString);

                string customersAsString = File.ReadAllText(@"..\..\..\ImportXml\customers.xml");
                Deserializer.ImportCustomers(context, customersAsString);

                string partsAsString = File.ReadAllText(@"..\..\..\ImportXml\parts.xml");
                Deserializer.ImportParts(context, partsAsString);

                string carsAsString = File.ReadAllText(@"..\..\..\ImportXml\cars.xml");
                Deserializer.ImportCars(context, carsAsString);

                Deserializer.ImportSales(context);
            }            
        }

        private static void InitializeDatabase()
        {
            var context = new CarDealershipContext();

            using (context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

        }
    }
}
