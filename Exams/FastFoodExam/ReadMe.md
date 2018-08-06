# Entity Framework Core: Exam

Exam problems for the [Databases Advanced - Entity Framework course @ SoftUni](https://softuni.bg/courses/databases-advanced-entity-framework). Submit your solutions in the SoftUni judge system (delete all &quot;bin&quot;/&quot;obj&quot; folders alongside with the &quot;packages&quot; folder).

Your task is to create a database application using **Entity Framework Core** using the **Code First** approach. Design the **domain models** and **methods** for manipulating the data, as described below.

# Fast Food

Create an application which models a **fast food point of sale system**. Employees process orders for customers. Orders have items inside them. Each category has zero or more items. For more details about the **models** and their **relations** read further.

 ![](data:image/*;base64,iVBORw0KGgoAAAANSUhEUgAAA3AAAAKWCAMAAAFIWbtYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAEyUExURf///2RkZPDw8PCgUAAAAAAoeMjw8Mh4KABQoMigeFAoKAAoKFB4oAAAUKDw8PDwyHgoAAAoUKDI8KBQACh4yMigUCgAAPDIoFAoAHh4UKB4UHigyCgoAAAAKCgoeFCg8Mh4UFCgyKB4KFB4yChQoPDIeHjI8ChQUPDwoMjwyFAAACh4oHhQeCgoUKBQKFCgoPCgeMjI8CgoKChQeHhQKKCgoKpVAABVqtSAK///AAArgKqAK9T///+qVf//qlUAK4DU///UgCsAVar//wAAVSsAK///1IArAFWq/ysrKyuA1FUAAAAAKyuAqisAAFWqqv+qgCsrVYBVgKrUgCuAgNSAVYCAK9SqVVWq1Kr/qtT/1ICqgMjIoPDIyKBQUMjIyFBQKKDIyMjIeFVVAICq/wAAAFp5CcwAAABmdFJOU///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////ADWOqLcAAAAJcEhZcwAADsQAAA7EAZUrDhsAAD0FSURBVHhe7Z17d9tGlu3LcEFSkpbFWAqVcaJ24kRuj53k5mVS8iIl0pRpLeqPmXWnV2du9525r/n+n+GeU3VAgiRAkAAIVAH7Z4soAIXH4eZGFYBCQYFGEGyJZBdkYiaSfYFMz0SyCzIxE8m+4DI4vdSEzE9FsgtBwIucXwRfUkJyJCHZFwT6lBfddXM6OKRFDvR5cLHT5rYk34IrS11fX2+5oniufEvtRL4FXdncUIZplLq5wWSqVTiTsSQSFux9vNKSTCPfThKlRpdNqZsbDlm7gR1JJGnBq+FNhuRuRJdNuZsbzGadzvFxKKPrxBZ8q+UHeTWe9aY2mUKB6LR+RMjollT8Zeam3M3pniTS8Do6AFqO1D8zkexFofqw+f+rrDYNyV6UV8Ep19n1hT7VvN00JHtFlLY5XtEx/R1dmdEUVjYnIWci2WPwpDsqz/sbK42lbW47Vjenjx4/OTnUB73PZcXJSPadKSU6ruSYSfej/kbpVje3JWVEF3h2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)

## Project Skeleton Overview

You are given a **project skeleton** , which includes the following items:

- **FastFood.App** – contains the **Startup** class, which is the **entry point of the application**. Also contains an **AutoMapper** profile, which you can configure if you choose to use **AutoMapper** in your app.
- **FastFood.Data** – contains the **FastFoodDbContext** class and the **connection string**
- **FastFood.Models** – contains the **entity classes**
- **FastFood.DataProcessor** – contains the **Serializer** and **Deserializer** classes, which are used for **importing** and **exporting** data

## Problem 1. Model Definition (50 pts)

Every employee has a **position** and **orders** , which they need to process. Every **order** has a **customer** , **order date** and a **list of items**. Every item has a **category** , a **name** and a **price**. **Categories** have a **list of items**.

**Note: Foreign key navigation properties are required!**

The application needs to store the following data:

### Employee

- **Id** – integer, **Primary Key**
- **Name** – text with **min length**** 3 **and** max length 30**(**required**)
- **Age** – integer **in the**** range****[15, 80]** ( **required** )
- **PositionId** ­– integer, **foreign key**
- **Position** – the employee&#39;s **position** ( **required** )
- **Orders** – the **orders** the employee has processed

### Position

- **Id** – integer, **Primary Key**
- **Name** – text with **min length**** 3 **and** max length 30**(**required, unique**)
- **Employees** – Collection of type **Employee**

### Category

- **Id** – integer, **Primary Key**
- **Name –** text with **min length 3** and **max length 30** ( **required** )
- **Items** – collection of type **Item**

### Item

- **Id** – integer, **Primary Key**
- **Name** – text with **min length 3** and **max length 30** ( **required, unique** )
- **CategoryId**  **– integer, foreign key**
- **Category** – the item&#39;s **category** ( **required** )
- **Price** – decimal ( **non-negative, minimum value: 0.01** , **required** )
- **OrderItems** – collection of type **OrderItem**

### Order

- **Id** – integer, **Primary Key**
- **Customer** – **text (****required****)**
- **DateTime** – **date and time of the order (****required****)**
- **Type**  **–**  **OrderType**** enumeration with possible values: &quot; ****ForHere**** , **** ToGo **** (default: **** ForHere****)&quot; (****required****)**
- **TotalPrice** – decimal value (calculated property, **(not mapped to database)**, **required** )
- **EmployeeId** – integer, **foreign key**
- **Employee** – The employee who will process the order ( **required** )
- **OrderItems** – collection of type **OrderItem**

### OrderItem

- **OrderId** – integer, **Primary Key**
- **Order** – the item&#39;s **order** ( **required** )
- **ItemId**  **– integer,**  **Primary Key**
- **Item**  **– the order&#39;s**  **item** **(****required****)**
- **Quantity** – the quantity of the **item** in the **order** ( **required** , **non-negative** and **non-zero** )

## Problem 2. Data Import (30pts)

For the functionality of the application, you need to create several methods that manipulate the database. The **project skeleton** already provides you with these methods, inside the **FastFood.DataProcessor** project inside your solution. Use **Data Transfer Objects** as needed.

Use the provided **JSON** and **XML** files to populate the database with data. Import all the information from those files into the database.

You are **not allowed** to modify the provided JSON and XML files.

**If a record does not meet the requirements from the first section, print an error message:**

| **Error message** |
| --- |
| Invalid data format. |

### JSON Import (20 pts)

#### Import Employees

Using the file **employees.json** , import the data from that file into the database. Print information about each imported object in the format described below.

##### Constraints

- If any validation errors occur (such as if their **name**** or position are too long/short **or their** age** is out of range) proceed as described above
- If a position **doesn&#39;t exist yet** (and the position and rest of employee data is **valid** ), **create it**.
- If an employee is **invalid** , **do not** import their **position**.

##### Example

| **employees.json** |
| --- |
| [  {    &quot;Name&quot;: &quot;N&quot;,    &quot;Age&quot;: 20,    &quot;Position&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Too Young&quot;,    &quot;Age&quot;: 14,    &quot;Position&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Too Old&quot;,    &quot;Age&quot;: 81,    &quot;Position&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Invalid Position&quot;,    &quot;Age&quot;: 20,    &quot;Position&quot;: &quot;&quot;  },  {    &quot;Name&quot;: &quot;InvalidPosition&quot;,    &quot;Age&quot;: 20,    &quot;Position&quot;: &quot;Invaliddddddddddddddddddddddddd&quot;  },  {    &quot;Name&quot;: &quot;Magda Bjork&quot;,    &quot;Age&quot;: 44,    &quot;Position&quot;: &quot;CEO&quot;  },… |
| **Output** |
| Invalid data format.Invalid data format.Invalid data format.Invalid data format.Invalid data format.Record Magda Bjork successfully imported.… |

#### Import Items

Using the file **items.json** , import the data from that file into the database. Print information about each imported object in the format described below.

##### Constraints

- If any validation errors occur (such as invalid item name or invalid category name), **ignore** the entity and **print an error message**.
- If an item with the same name **already exists** , **ignore** the entity and **do not import it**.
- If an item&#39;s category **doesn&#39;t exist** , **create it** along with the item.

##### Example

| **items.json** |
| --- |
| [  {    &quot;Name&quot;: &quot;Hamburger&quot;,    &quot;Price&quot;: 0.00,    &quot;Category&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Hamburger&quot;,    &quot;Price&quot;: -5.00,    &quot;Category&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;x&quot;,    &quot;Price&quot;: 1.00,    &quot;Category&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Invaliddddddddddddddddddddddddd&quot;,    &quot;Price&quot;: 1.00,    &quot;Category&quot;: &quot;Invalid&quot;  },  {    &quot;Name&quot;: &quot;Invalid&quot;,    &quot;Price&quot;: 1.00,    &quot;Category&quot;: &quot;x&quot;  },  {    &quot;Name&quot;: &quot;Invalid&quot;,    &quot;Price&quot;: 1.00,    &quot;Category&quot;: &quot;Invaliddddddddddddddddddddddddd&quot;  },  {    &quot;Name&quot;: &quot;Hamburger&quot;,    &quot;Price&quot;: 5.00,    &quot;Category&quot;: &quot;Beef&quot;  },  {    &quot;Name&quot;: &quot;Hamburger&quot;,    &quot;Price&quot;: 1.00,    &quot;Category&quot;: &quot;Beef&quot;  },  {    &quot;Name&quot;: &quot;Cheeseburger&quot;,    &quot;Price&quot;: 6.00,    &quot;Category&quot;: &quot;Beef&quot;  },… |
| **Output** |
| Invalid data format.Invalid data format.Invalid data format.Invalid data format.Invalid data format.Invalid data format.Record Hamburger successfully imported.Invalid data format.Record Cheeseburger successfully imported. |

### XML Import (10 pts)

#### Import Orders

Using the file **orders.xml** , import the data from the file into the database. Print information about each imported object in the format described below.

If any of the model requirements is violated continue with the next entity.

##### Constraints

- The order dates will be in the format &quot; **dd/MM/yyyy HH:mm**&quot;. Make sure you use **CultureInfo.InvariantCulture**.
- If the order&#39;s **employee** doesn&#39;t exist, **do not** import the order.
- If **any** of the **order&#39;s**** items **do not exist,** do not** import the order.
- If there are any other validation errors (such as **negative** or **non-zero price** ), proceed as described above.
- Every employee will have a **unique name**

##### Example

| **orders****.xml** |
| --- |
| \&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?\&gt;\&lt;Orders\&gt;  \&lt;Order\&gt;    \&lt;Customer\&gt;Garry\&lt;/Customer\&gt;    \&lt;Employee\&gt;Maxwell Shanahan\&lt;/Employee\&gt;    \&lt;DateTime\&gt;21/08/2017 13:22\&lt;/DateTime\&gt;    \&lt;Type\&gt;ForHere\&lt;/Type\&gt;    \&lt;Items\&gt;      \&lt;Item\&gt;        \&lt;Name\&gt;Quarter Pounder\&lt;/Name\&gt;        \&lt;Quantity\&gt;2\&lt;/Quantity\&gt;      \&lt;/Item\&gt;      \&lt;Item\&gt;        \&lt;Name\&gt;Premium chicken sandwich\&lt;/Name\&gt;        \&lt;Quantity\&gt;2\&lt;/Quantity\&gt;      \&lt;/Item\&gt;      \&lt;Item\&gt;        \&lt;Name\&gt;Chicken Tenders\&lt;/Name\&gt;        \&lt;Quantity\&gt;4\&lt;/Quantity\&gt;      \&lt;/Item\&gt;      \&lt;Item\&gt;        \&lt;Name\&gt;Just Lettuce\&lt;/Name\&gt;        \&lt;Quantity\&gt;4\&lt;/Quantity\&gt;      \&lt;/Item\&gt;    \&lt;/Items\&gt;  \&lt;/Order\&gt;...\&lt;/Orders\&gt; |
| **Output** |
| Order for Garry on 21/08/2017 13:22 added |

## Problem 3. Data Export (20 pts)

**Use the provided methods in the**  **FastFood.DataProcessor**** project. **Usage of** Data Transfer Objects **is** optional**.

### JSON Export (10 pts)

#### Export All Orders by Employee

The given method in the project skeleton receives an **employee name** and an **order type** as **strings**. Export all **orders** that were processed by the **employee** with that **name** , which have **that order type**. For each order, get the customer&#39;s **name** and the **order&#39;s**** items **with their** name **,** price **and** quantity **. Apart from that, for every order, also list the** total price **of the order. Sort the orders by their** total price**(**descending**), then by the**number of items**in the order (**descending**). Finally, also export the**total money made** from all the orders.

##### Example

| **Serializer.ExportOrdersByEmployee(context, &quot;Avery Rush&quot;, &quot;ToGo&quot;)** |
| --- |
| {  &quot;Name&quot;: &quot;Avery Rush&quot;,  &quot;Orders&quot;: [    {      &quot;Customer&quot;: &quot;Stacey&quot;,      &quot;Items&quot;: [        {          &quot;Name&quot;: &quot;Cheeseburger&quot;,          &quot;Price&quot;: 6.00,          &quot;Quantity&quot;: 5        },        {          &quot;Name&quot;: &quot;Double Cheeseburger&quot;,          &quot;Price&quot;: 6.50,          &quot;Quantity&quot;: 3        },        {          &quot;Name&quot;: &quot;Luigi&quot;,          &quot;Price&quot;: 2.10,          &quot;Quantity&quot;: 5        },        {          &quot;Name&quot;: &quot;Bacon Deluxe&quot;,          &quot;Price&quot;: 9.00,          &quot;Quantity&quot;: 1        }     ],      &quot;TotalPrice&quot;: 69.00    },    {      &quot;Customer&quot;: &quot;Pablo&quot;,      &quot;Items&quot;: [        {          &quot;Name&quot;: &quot;Double Cheeseburger&quot;,          &quot;Price&quot;: 6.50,          &quot;Quantity&quot;: 3        },        {          &quot;Name&quot;: &quot;Bacon Deluxe&quot;,          &quot;Price&quot;: 9.00,          &quot;Quantity&quot;: 5        }     ],      &quot;TotalPrice&quot;: 64.50    },    {      &quot;Customer&quot;: &quot;Bobbie&quot;,      &quot;Items&quot;: [        {          &quot;Name&quot;: &quot;Tuna Salad&quot;,          &quot;Price&quot;: 3.00,          &quot;Quantity&quot;: 2        },        {          &quot;Name&quot;: &quot;Crispy Fries&quot;,          &quot;Price&quot;: 2.00,          &quot;Quantity&quot;: 5        },        {          &quot;Name&quot;: &quot;Fries&quot;,          &quot;Price&quot;: 1.50,          &quot;Quantity&quot;: 2        }     ],      &quot;TotalPrice&quot;: 19.00    },    {      &quot;Customer&quot;: &quot;Joann&quot;,      &quot;Items&quot;: [        {          &quot;Name&quot;: &quot;Minion&quot;,          &quot;Price&quot;: 2.20,          &quot;Quantity&quot;: 2        },        {          &quot;Name&quot;: &quot;Bacon Deluxe&quot;,          &quot;Price&quot;: 9.00,          &quot;Quantity&quot;: 1        }     ],      &quot;TotalPrice&quot;: 13.40    }  ],  &quot;TotalMade&quot;: 165.90} |

### XML Export (10 pts)

#### ExportCategories with their Most Popular Item

Use the method provided in the project skeleton, which receives a string of **comma-separated category names**. Export the **categories** : for each **category** , export its **most popular item**. The most popular item is the item from the category, which made the **most money** in **orders**. **Sort** the categories by **the amount of money the most popular item made (descending)**, then by **the times the item was sold** ( **descending** ).

##### Example

| **Serializer.ExportCategoryStatistics(context, &quot;****Chicken,Drinks,Toys****&quot;)** |
| --- |
| \&lt;Categories\&gt;  \&lt;Category\&gt;    \&lt;Name\&gt;Chicken\&lt;/Name\&gt;    \&lt;MostPopularItem\&gt;      \&lt;Name\&gt;Chicken Tenders\&lt;/Name\&gt;      \&lt;TotalMade\&gt;44.00\&lt;/TotalMade\&gt;      \&lt;TimesSold\&gt;11\&lt;/TimesSold\&gt;    \&lt;/MostPopularItem\&gt;  \&lt;/Category\&gt;  \&lt;Category\&gt;    \&lt;Name\&gt;Toys\&lt;/Name\&gt;    \&lt;MostPopularItem\&gt;      \&lt;Name\&gt;Minion\&lt;/Name\&gt;      \&lt;TotalMade\&gt;24.20\&lt;/TotalMade\&gt;      \&lt;TimesSold\&gt;11\&lt;/TimesSold\&gt;    \&lt;/MostPopularItem\&gt;  \&lt;/Category\&gt;  \&lt;Category\&gt;    \&lt;Name\&gt;Drinks\&lt;/Name\&gt;    \&lt;MostPopularItem\&gt;      \&lt;Name\&gt;Purple Drink\&lt;/Name\&gt;      \&lt;TotalMade\&gt;9.10\&lt;/TotalMade\&gt;      \&lt;TimesSold\&gt;7\&lt;/TimesSold\&gt;    \&lt;/MostPopularItem\&gt;  \&lt;/Category\&gt;\&lt;/Categories\&gt; |

## Problem 4. Bonus Task (10 pts)

**Implement the bonus method in the**  **FastFood.DataProcessor**** project for an **** additional amount **** of points**.

### Update Item Price

Implement the method **DataProcessor.Bonus.UpdateItemPrice** , which receives an item&#39;s **name** and a **new**** price **. Your task is to** find the item **by that name and** update its price**.

After the price is updated, return the message &quot; **{item.Name} Price updated from ${oldPrice:F2} to ${newPrice:F2}**&quot;.

If the item is not found, return &quot; **Item {item.Name} not found!**&quot;

#### Examples

| **DataProcessor.Bonus.UpdateItemPrice(context, &quot;Cheeseburger&quot;, 6.50m)** |
| --- |
| Cheeseburger Price updated from $6.00 to $6.50 |

| **DataProcessor.Bonus.UpdateItemPrice(context, &quot;Ribs&quot;, 8.00m)** |
| --- |
| Item Ribs not found! |