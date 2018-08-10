# 1.Exercises: C# Auto Mapping Objects

This document defines the **exercise assignments** for the [&quot;Databases Advanced – EF Core&quot; course @ Software University](https://softuni.bg/trainings/1741/databases-advanced-entity-framework-october-2017).

1. 1.Employees Mapping

Create a simple database with one table – Employees. Each employee should have properties: **first name** , **last name** , **salary** , **birthday** and **address**. Only **first**** name **,** last ****name** and **salary** are **required**.

Create **EmployeeDto** class that will keep synthesized information about instances of Employee class (only **id** , **first name** , **last name** and **salary** ).

Create a console app for your database, which uses the **Automapper** package and the **EmployeeDto** class to **transfer**** data** from and back to the database. You should have the following commands:

- **AddEmployee** &lt; **firstName** &gt; &lt; **lastName** &gt; &lt; **salary** &gt; –  adds a new Employee to the database
- **SetBirthday &lt;employeeId&gt; &lt;date:**&quot;dd-MM-yyyy&quot; **&gt;** – sets the birthday of the employee to the given date
- **SetAddress** &lt; **employeeId** &gt; &lt; **address** &gt; –  sets the address of the employee to the given string
- **EmployeeInfo** &lt; **employeeId** &gt; – prints on the console the information for an employee in the format &quot;ID: {employeeId} - {firstName} {lastName} -  ${salary:f2}&quot;
- **EmployeePersonalInfo &lt;employeeId&gt;** – prints all the information for an employee in the following format:

| ID: 1 - Pesho Ivanov - $1000:00Birthday: 15-04-1976Address: Sofia, ul. Vitosha 15 |
| --- |

- **Exit** – closes the application

#### Bonus

Only use **DTOs** in your application. Use a **service** to connect to the **database**.

1. 2.Manager Mapping

Add to the **Employee** model information about their **manager** and a list of **employees** that they **manage**. It is **possible** for an employee to have **no**** manager**. Create another data transfer object, which treats employees as managers:

- **ManagerDto** – first name, last name, list of EmployeeDtos that he/she is in charge of and their count

Add the following commands to your console application:

- **SetManager** &lt; **employeeId** &gt; &lt; **managerId** &gt; – sets the second employee to be a manager of the first employee
- **ManagerInfo** &lt; **employeeId** &gt; – prints on the console information about a manager in the following format:

### Example

| **Sample output** |
| --- |
| Steve Jobbsen | Employees: 2    - Stephen Bjorn - $4300.00    - Kirilyc Lefi - $4400.00 |
| Carl Kormac | Employees: 14    - Jurgen Straus - $1000.45    - Moni Kozinac - $2030.99    - Kopp Spidok - $2000.21    - … |

1. 3.Projection

Add a few employees to your database with their birthdays. Create a command &quot; **ListEmployeesOlderThan** &lt; **age** &gt;&quot; which lists all employees older than given age and their managers. Order them **by salary descending.** Add the necessary DTOs and commands to your application.

### Example

| **Sample output** |
| --- |
| Steve Jobbsen - $6000.20 - Manager: [no manager]Kirilyc Lefi - $4400.00 - Manager: JobbsenStephen Bjorn - $4300.00 - Manager: Jobbsen |