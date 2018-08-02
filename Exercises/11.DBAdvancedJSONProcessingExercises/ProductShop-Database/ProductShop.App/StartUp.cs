namespace ProductShop.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();
            
            var context = new ProductShopContext();
            ResetDatabase(context);
            SeedDatabase(context);

            ProductInRange(context);
            SuccessfullySoldProducts(context);
            CategoriesByProductsCount(context);
            UsersAndProducts(context);
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = new
            {
                usersCount = context.Users.Where(x=>x.ProductsSold.Count>=1).Count(),
                users = context.Users
                .OrderByDescending(x=>x.ProductsSold.Count)
                .ThenBy(x=>x.LastName)
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(s => s.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(e=> new
                        {
                            name =e.Name,
                            price = e.Price
                        }).ToArray()
                    }
                }).ToArray()
            };

            var categoriesJson = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/users-and-products.json", categoriesJson);

        }

        public static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                //.Include(e=>e.CategoryProducts)
                //.ThenInclude(e=>e.Product)
                .OrderByDescending(e=>e.CategoryProducts.Count)
                 .Select(x => new
                 {
                     category = x.Name,
                     productsCount = x.CategoryProducts.Count,
                     averagePrice = x.CategoryProducts.Sum(e=>e.Product.Price)/ x.CategoryProducts.Count(),
                     totalRevenue = x.CategoryProducts.Sum(s=>s.Product.Price)
                 })
                 .ToArray();

            var categoriesJson = JsonConvert.SerializeObject(categories, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/categories-by-products", categoriesJson);
        }

        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            var userSoldProducts = context.Users.Include(e=>e.ProductsSold)
                .Where(x => x.ProductsSold.Count >=1)
                 .Select(s => new
                 {
                     firstName = s.FirstName,
                     lastName = s.LastName,
                     soldProducts = s.ProductsSold.Where(x => x.BuyerId != null)
                                     .Select(e => new
                                     {
                                         name = e.Name,
                                         price = e.Price,
                                         buyerFirstName = e.Buyer.FirstName,
                                         buyerLastName = e.Buyer.LastName,
                                     }).ToArray()
                 })
                 .OrderBy(e => e.lastName)
                 .ThenBy(e => e.firstName)
                 .ToArray();

            var productsJson = JsonConvert.SerializeObject(userSoldProducts,new JsonSerializerSettings {
            Formatting = Formatting.Indented,
            NullValueHandling =NullValueHandling.Ignore
            });

            File.WriteAllText("../../../Json/users-sold-products.json", productsJson);
        }

        private static void ProductInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(e => e.Price >= 500 && e.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName ?? " " + " " + x.Seller.LastName ?? " "
                })
                .OrderBy(x=>x.price)
                .ToArray();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("../../../Json/products-in-range.json", productsJson);

        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void SeedDatabase(ProductShopContext context)
        {
            var userJson = File.ReadAllText("../../../Json/users.json");
            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(userJson);

            var users = new List<User>();

            foreach (var item in deserializedUsers)
            {
                if (IsValid(item))
                {
                    users.Add(item);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            var productJson = File.ReadAllText("../../../Json/products.json");
            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(productJson);

            var random = new Random();
            foreach (var product in deserializedProducts)
            {
                product.SellerId = random.Next(1, 35);

                if (random.Next(1, 4) == 3)
                {
                    continue;
                }
                product.BuyerId = random.Next(35, 57);
            }

            context.Products.AddRange(deserializedProducts.Where(x=>IsValid(x)));
            context.SaveChanges();

            var categoryJson = File.ReadAllText(@"../../../Json/categories.json");
            var categories = JsonConvert.DeserializeObject<Category[]>(categoryJson);

            context.AddRange(categories.Where(s=>IsValid(s)));
            context.SaveChanges();

            var productIds = context.Products.Select(x => x.Id).ToArray();
            var categoryProducts = new List<CategoryProduct>();

            for (int i = 0; i < productIds.Length; i++)
            {
                var categoryProduct = new CategoryProduct()
                {
                    CategoryId = random.Next(1, 12),
                    ProductId = productIds[i]
                };
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        public static bool IsValid(object obj)
        {
            var validationContex = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, validationContex, results, true);
        }
    }
}
