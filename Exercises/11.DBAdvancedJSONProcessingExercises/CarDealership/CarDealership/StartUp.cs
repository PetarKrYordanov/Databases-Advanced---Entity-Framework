namespace CarDealership
{
  
    using System.IO;
    using System.Text;

    using Data;
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
                string carsWithDistance = Serializer.OrderedCustomers(context);
                File.WriteAllText(@"..\..\..\ExportJson\ordered-customers.json", carsWithDistance, Encoding.UTF8);

                string toyotaCars = Serializer.GetToyotaCars(context);
                File.WriteAllText(@"..\..\..\ExportJson\toyota-cars.json", toyotaCars, Encoding.UTF8);

                string localSuppliers = Serializer.GetLocalSuppliers(context);
                File.WriteAllText(@"..\..\..\ExportJson\local-suppliers.json", localSuppliers, Encoding.UTF8);

                string carsAndParts = Serializer.GetCarsWithListOfParts(context);
                File.WriteAllText(@"..\..\..\ExportJson\cars-and-parts.json", carsAndParts, Encoding.UTF8);

                string salesByCustomers = Serializer.TotalSalesByCustomer(context);
                File.WriteAllText(@"..\..\..\ExportJson\customers-total-sales.json", salesByCustomers, Encoding.UTF8);

                string salesWithApliedDiscount = Serializer.GetSalesWithAppliedDicount(context);
                File.WriteAllText(@"..\..\..\ExportJson\sales-discounts.json", salesWithApliedDiscount, Encoding.UTF8);
            }
        }

        private static void ImportData()
        {

            using (var context = new CarDealershipContext())
            {
                string suppliersAsString = File.ReadAllText(@"..\..\..\ImportJson\suppliers.json");
                Deserializer.ImportSuppliers(context, suppliersAsString);

                string partsAsString = File.ReadAllText(@"..\..\..\ImportJson\parts.json");
                Deserializer.ImportParts(context, partsAsString);

                string carsasstring = File.ReadAllText(@"..\..\..\importjson\cars.json");
                Deserializer.ImportCars(context, carsasstring);

                string customersAsString = File.ReadAllText(@"..\..\..\ImportJson\customers.json");
                Deserializer.ImportCustomers(context, customersAsString);

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
