using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();
            var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);
            var validEmployes = new List<Employee>();
            foreach (var employeeDto in deserializedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(string.Format(FailureMessage, employeeDto.Name));
                    continue;
                }

                if (!context.Positions.Any(e => e.Name == employeeDto.Position))
                {
                  var  positionToAdd = new Models.Position();
                    positionToAdd.Name = employeeDto.Position;
                    context.Positions.Add(positionToAdd);
                    context.SaveChanges();
                }
               var position = context.Positions.FirstOrDefault(e => e.Name == employeeDto.Position);

                var employee = new Employee();
                employee.Name = employeeDto.Name;
                employee.PositionId = position.Id;
                employee.Age = employeeDto.Age;

                validEmployes.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }
            context.Employees.AddRange(validEmployes);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();
            var validItems = new List<Item>();
            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(string.Format(FailureMessage, itemDto.Name));
                    continue;
                }

                if (context.Items.Any(e=>e.Name==itemDto.Name))
                {
                    sb.AppendLine(string.Format(FailureMessage, itemDto.Name));
                    continue;
                }

                if (!context.Categories.Any(e => e.Name == itemDto.Category))
                {
                    var categoryToAdd = new Category();
                    categoryToAdd.Name = itemDto.Category;
                    context.Categories.Add(categoryToAdd);
                    context.SaveChanges();
                }
                var category = context.Categories.FirstOrDefault(e => e.Name == itemDto.Category);

                var item = new Item();
                item.Name = itemDto.Name;
                item.Price = itemDto.Price;
                item.CategoryId = category.Id;

                context.Items.Add(item);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }
   
            var result = sb.ToString().Trim();
            return result;
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            //var inputXml = @"<Orders><Order><Customer>Enrique</Customer><Employee>Elizabet Trentham</Employee><DateTime>11/06/2017 14:08</DateTime><Type>ForHere</Type><Items><Item><Name>Daily Double</Name><Quantity>3</Quantity></Item><Item><Name>Tasty Basket</Name><Quantity>4</Quantity></Item><Item><Name>Tuna Salad</Name><Quantity>2</Quantity></Item><Item><Name>Minion</Name><Quantity>5</Quantity></Item></Items></Order><Order><Customer>Joann</Customer><Employee>Avery Rush</Employee><DateTime>08/09/2017 23:19</DateTime><Type>ToGo</Type><Items><Item><Name>Bacon Deluxe</Name><Quantity>1</Quantity></Item><Item><Name>Minion</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Ray</Customer><Employee>Jolanda Discher</Employee><DateTime>25/08/2017 20:13</DateTime><Type>ForHere</Type><Items><Item><Name>Tasty Basket</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Roberta</Customer><Employee>Maxwell Shanahan</Employee><DateTime>02/03/2017 07:19</DateTime><Type>ForHere</Type><Items><Item><Name>Premium chicken sandwich</Name><Quantity>2</Quantity></Item><Item><Name>Purple Drink</Name><Quantity>5</Quantity></Item><Item><Name>Cesar Salad</Name><Quantity>2</Quantity></Item><Item><Name>Tuna Salad</Name><Quantity>1</Quantity></Item><Item><Name>Batman</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Daniel</Customer><Employee>Dorethea Mumford</Employee><DateTime>16/12/2017 20:13</DateTime><Type>ForHere</Type><Items><Item><Name>Ranger Burger</Name><Quantity>4</Quantity></Item><Item><Name>BBQ Burger</Name><Quantity>5</Quantity></Item></Items></Order><Order><Customer>Yolanda</Customer><Employee>Kym Douse</Employee><DateTime>28/10/2017 04:25</DateTime><Type>ForHere</Type><Items><Item><Name>Quarter Pounder</Name><Quantity>5</Quantity></Item><Item><Name>BBQ Burger</Name><Quantity>4</Quantity></Item><Item><Name>Fries</Name><Quantity>1</Quantity></Item></Items></Order><Order><Customer>Pablo</Customer><Employee>Annett Lewallen</Employee><DateTime>26/03/2017 06:33</DateTime><Type>ForHere</Type><Items><Item><Name>Crispy Chicken Deluxe</Name><Quantity>5</Quantity></Item><Item><Name>Cake</Name><Quantity>3</Quantity></Item><Item><Name>Just Lettuce</Name><Quantity>4</Quantity></Item></Items></Order><Order><Customer>Ray</Customer><Employee>Shin Vallejos</Employee><DateTime>11/03/2017 04:07</DateTime><Type>ForHere</Type><Items><Item><Name>Crispy Chicken Deluxe</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Bobbie</Customer><Employee>Denita Providence</Employee><DateTime>09/02/2017 01:50</DateTime><Type>ToGo</Type><Items><Item><Name>Premium Chicken Wrap</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Miguel</Customer><Employee>Herta Balser</Employee><DateTime>03/03/2017 21:41</DateTime><Type>ToGo</Type><Items><Item><Name>Bacon Deluxe</Name><Quantity>1</Quantity></Item><Item><Name>Premium Chicken Wrap</Name><Quantity>3</Quantity></Item><Item><Name>Crispy Fries</Name><Quantity>5</Quantity></Item></Items></Order><Order><Customer>Roberta</Customer><Employee>Stanton Dahl</Employee><DateTime>26/09/2017 22:15</DateTime><Type>ForHere</Type><Items><Item><Name>Quarter Pounder</Name><Quantity>1</Quantity></Item><Item><Name>Chicken Nuggets</Name><Quantity>3</Quantity></Item><Item><Name>Chicken Tenders</Name><Quantity>4</Quantity></Item></Items></Order><Order><Customer>Leona</Customer><Employee>Felisa Frier</Employee><DateTime>06/02/2017 00:04</DateTime><Type>ForHere</Type><Items><Item><Name>Bowser</Name><Quantity>4</Quantity></Item></Items></Order><Order><Customer>Stacey</Customer><Employee>Avery Rush</Employee><DateTime>07/10/2017 06:00</DateTime><Type>ToGo</Type><Items><Item><Name>Cheeseburger</Name><Quantity>5</Quantity></Item><Item><Name>Double Cheeseburger</Name><Quantity>3</Quantity></Item><Item><Name>Bacon Deluxe</Name><Quantity>1</Quantity></Item><Item><Name>Luigi</Name><Quantity>5</Quantity></Item></Items></Order><Order><Customer>Enrique</Customer><Employee>Shirleen Vonruden</Employee><DateTime>19/07/2017 17:58</DateTime><Type>ToGo</Type><Items><Item><Name>BBQ Burger</Name><Quantity>1</Quantity></Item><Item><Name>Chicken Tenders</Name><Quantity>3</Quantity></Item><Item><Name>Ice Cream</Name><Quantity>4</Quantity></Item><Item><Name>Mario</Name><Quantity>4</Quantity></Item></Items></Order><Order><Customer>Guillermo</Customer><Employee>Iris Foushee</Employee><DateTime>23/08/2017 08:24</DateTime><Type>ForHere</Type><Items><Item><Name>Triple Cheeseburger</Name><Quantity>2</Quantity></Item></Items></Order><Order><Customer>Darryl</Customer><Employee>Classie Mettler</Employee><DateTime>25/01/2017 13:02</DateTime><Type>ToGo</Type><Items><Item><Name>Triple Cheeseburger</Name><Quantity>4</Quantity></Item><Item><Name>Grilled Chicken Deluxe</Name><Quantity>4</Quantity></Item><Item><Name>Fries</Name><Quantity>5</Quantity></Item><Item><Name>Purple Drink</Name><Quantity>1</Quantity></Item><Item><Name>Tuna Salad</Name><Quantity>3</Quantity></Item></Items></Order><Order><Customer>Daniel</Customer><Employee>Ariane Sloan</Employee><DateTime>24/05/2017 21:58</DateTime><Type>ForHere</Type><Items><Item><Name>Cheeseburger</Name><Quantity>3</Quantity></Item><Item><Name>Snack Wrap</Name><Quantity>2</Quantity></Item><Item><Name>Purple Drink</Name><Quantity>1</Quantity></Item><Item><Name>Minion</Name><Quantity>4</Quantity></Item></Items></Order><Order><Customer>Bobbie</Customer><Employee>Avery Rush</Employee><DateTime>08/04/2017 19:53</DateTime><Type>ToGo</Type><Items><Item><Name>Fries</Name><Quantity>2</Quantity></Item><Item><Name>Crispy Fries</Name><Quantity>5</Quantity></Item><Item><Name>Tuna Salad</Name><Quantity>2</Quantity></Item></Items></Order></Orders>";
            var sb = new StringBuilder();
            var listOfOrdersDto = new List<OrderDto>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<OrderDto>), new XmlRootAttribute("Orders"));
            using (TextReader reader = new StringReader(xmlString))
            {
                listOfOrdersDto = (List<OrderDto>)serializer.Deserialize(reader);
            }

            foreach (var order in listOfOrdersDto)
            {
                
                if (!context.Employees.Any(e => e.Name == order.Employee))
                {
                    continue;
                }
                var employeeId = context.Employees.FirstOrDefault(e => e.Name == order.Employee).Id;
                var orderItems = new List<OrderItem>();
                bool isItemFound = false;
                foreach (var item in order.Items)
                {
                    if (item.Quantity < 1)
                    {
                        isItemFound = true;
                        break;
                    }
                    if (!context.Items.Any(x=>x.Name == item.Name))
                    {
                        
                        isItemFound = true;
                        break;
                    }
                    var itemToOrder = new OrderItem();
                    var itemId = context.Items.FirstOrDefault(e => e.Name == item.Name).Id;
                    itemToOrder.ItemId = itemId;
                    itemToOrder.Quantity = item.Quantity;
                    orderItems.Add(itemToOrder);
                }
                if (isItemFound)
                {
                    continue;
                }
               

                if (!IsValid(order))
                {
                    continue;
                }

                var orderToadd = new Order();
                OrderType @enum;
                if (!Enum.TryParse<OrderType>(order.Type,out @enum))
                {
                    continue;
                }
                DateTime date;
                if (!DateTime.TryParseExact(order.DateTime, "dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
                {
                    continue;
                }

                orderToadd.EmployeeId = employeeId;
                orderToadd.DateTime = date;
                orderToadd.Customer = order.Customer;
                orderToadd.Type = @enum;
                sb.AppendLine($"Order for {order.Customer} on {date.ToString("dd/MM/yyyy HH:mm")} added");
                context.Orders.Add(orderToadd);
                context.SaveChanges();

                var orderId = context.Orders.FirstOrDefault(e => e.EmployeeId == employeeId  && e.DateTime ==date).Id;
                foreach (var item in orderItems)
                {
                    item.OrderId = orderId;
                }
                context.OrderItems.AddRange(orderItems);
                context.SaveChanges();

            }
            

            var result = sb.ToString().Trim();
            return result;
        }

        public static bool IsValid(object obj)
        {
            var validationContex = new System.ComponentModel.DataAnnotations.ValidationContext(obj,serviceProvider:null,items:null);

            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContex, results, true);
            return isValid;
        }
    }
}