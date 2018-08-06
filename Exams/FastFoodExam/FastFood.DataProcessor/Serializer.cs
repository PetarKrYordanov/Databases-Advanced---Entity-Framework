using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var employeeOrders = context.Employees.Where(e => e.Name == employeeName).Select(e => new
            {
                Name = (string)e.Name,

                Orders = e.Orders.Where(f => f.Type == Enum.Parse<OrderType>(orderType)).Select(o => new
                {
                    Customer = (string)o.Customer,

                    Items = o.OrderItems.Select(oi => new
                    {
                        Name = (string)oi.Item.Name,
                        Price = oi.Item.Price,
                        Quantity = oi.Quantity
                    }).OrderByDescending(oi => oi.Quantity * oi.Price).ToArray(),

                    TotalPrice = o.OrderItems.Sum(oi => (decimal)oi.Quantity * oi.Item.Price),

                }).OrderByDescending(s => s.TotalPrice).ToArray(),
            }).First();
            var totalSpendMoney = employeeOrders.Orders.Sum(r => r.TotalPrice);

            var employeeOrdersWithTotalPrice = context.Employees.Where(e => e.Name == employeeName).Select(e => new
            {
                Name = e.Name,

                Orders = e.Orders.Where(f => f.Type == Enum.Parse<OrderType>(orderType)).Select(o => new
                {
                    Customer = o.Customer,

                    Items = o.OrderItems.Select(oi => new
                    {
                        Name = oi.Item.Name,
                        Price = oi.Item.Price,
                        Quantity = oi.Quantity
                    })
                    //    .OrderByDescending(oi => oi.Quantity * oi.Price)
                    .ToArray(),

                    TotalPrice = o.OrderItems.Sum(oi => (decimal)oi.Quantity * oi.Item.Price),

                }).OrderByDescending(s => s.TotalPrice).ToArray(),
                TotalMade = totalSpendMoney
            }).First();

            var employeeOrdersJson = JsonConvert.SerializeObject(employeeOrdersWithTotalPrice, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting =Newtonsoft.Json.Formatting.Indented

            });

            return employeeOrdersJson;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categories = categoriesString.Split(',').ToArray();

            var cat = context.Categories.Where(e => categories.Any(x => x == e.Name));

            var categoryStatistick = cat.Include(e => e.Items).ThenInclude(e => e.OrderItems)
                .Select(e => new CategoryDto
                {
                    Name = e.Name,
                    MostPopularItem = e.Items.Select(i => new PopularItemDto
                    {
                      Name = i.Name,
                      TotalMade = i.Price* i.OrderItems.Sum(b => b.Quantity),
                      TimesSold = i.OrderItems.Sum(b=>b.Quantity),

                    }).OrderByDescending(i => i.TotalMade).FirstOrDefault()

                }).OrderByDescending(e=>e.MostPopularItem.TotalMade).ToArray();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), categoryStatistick, xmlNamespaces);

            return sb.ToString();

            //var categoryStatistick = context.Items.Where(e=>e.Category.Name == categories[0]).Select (e => new CategoryDto
            //{
            //   Name = e.Category.Name,
            //   MostPopularItem = e.OrderItems.Select(i=>new PopularItemDto
            //   {
            //       Name = e.Name,
            //       TimesSold = e.OrderItems.Count,
            //       TotalMade = e.Price *(decimal)i.Quantity
            //   }).OrderByDescending(i=>i.TotalMade).FirstOrDefault()

            //}).ToArray();

        }
    }
}