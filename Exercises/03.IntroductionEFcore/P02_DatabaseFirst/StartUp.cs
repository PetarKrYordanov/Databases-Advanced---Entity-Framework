using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                EmployeesFullInformation(db);
                EmployeesWithSalaryOver50000(db);
                EmployeesFromResearchAndDevelopment(db);
                AddingNewAddressUpdatingEmployee(db);
                EmployeesAndProjects(db);
                AddressesByTown(db);
                Employee147(db);
                DepartmentsWithMoreThan5Employees(db);
                FindLatest10Projects(db);
                IncreaseSalaries(db);
                indEmployeesFirstNameStartingWithSa(db);
                DeleteProjectById(db);
            }
        }

        private static void DeleteProjectById(SoftUniContext db)
        {
            var employeeProjects = db.EmployeesProjects.Where(e => e.ProjectId == 2);

            foreach (var ep in employeeProjects)
            {
                db.EmployeesProjects.Remove(ep);
            }
            var project = db.Projects.Find(2);
            db.Projects.Remove(project);
            db.SaveChanges();
            var projects = db.Projects.Take(10);

            foreach (var p in projects)
            {
                Console.WriteLine(p.Name);
            }
        }

        private static void indEmployeesFirstNameStartingWithSa(SoftUniContext db)
        {
            var empployees = db.Employees.Where(e => e.FirstName.StartsWith("Sa"))
                   .OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            foreach (var e in empployees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
        }

        private static void IncreaseSalaries(SoftUniContext db)
        {
            var departmentNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = db.Employees
            .Where(d => departmentNames.Contains(d.Department.Name)).ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }
            db.SaveChanges();

            foreach (var e in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
        }

        private static void FindLatest10Projects(SoftUniContext db)
        {
            var projects = db.Projects.OrderByDescending(d => d.StartDate.Ticks)
               .Take(10)
               .OrderBy(d => d.Name).ThenBy(d => d.Description).ThenBy(d => d.StartDate);

            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
                Console.WriteLine(project.Description);
                Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }

        private static void DepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var departments = db.Departments.Where(d => d.Employees.Count > 5).Select(d => new
            {
                departmentName = d.Name,
                managerName = d.Manager.FirstName + ' ' + d.Manager.LastName,
                count = d.Employees.Count,
                employees = d.Employees.Select(e => new
                {
                    employeeName = e.FirstName + ' ' + e.LastName,
                    e.JobTitle

                })
            }).OrderBy(d => d.count).ThenBy(d => d.departmentName);

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.departmentName} - {department.managerName}");

                foreach (var employee in department.employees.OrderBy(x => x.employeeName))
                {
                    Console.WriteLine($"{employee.employeeName} - {employee.JobTitle}");
                }
                Console.WriteLine(new string('-', 10));
            }
        }

        private static void Employee147(SoftUniContext db)
        {
            var employee147 = db.Employees.Where(e => e.EmployeeId == 147)
                                    .Select(e => new
                                    {
                                        Name = e.FirstName + ' ' + e.LastName,
                                        e.JobTitle,
                                        Projects = e.EmployeesProjects.Select(ep => new
                                        {
                                            ep.Project.Name
                                        })
                                    });

            foreach (var employee in employee147)
            {
                Console.WriteLine($"{employee.Name} - {employee.JobTitle}");

                foreach (var project in employee.Projects.OrderBy(x => x.Name))
                {
                    Console.WriteLine(project.Name);
                }
            }
        }

        private static void AddressesByTown(SoftUniContext db)
        {
            var addresses = db.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).ThenBy(a => a.AddressText).Select(at => new
            {
                at.AddressText,
                Count = at.Employees.Count(),
                at.Town.Name
            }).Take(10);

            foreach (var item in addresses)
            {
                Console.WriteLine($"{item.AddressText}, {item.Name} - {item.Count} employees");
            }
        }

        private static void EmployeesAndProjects(SoftUniContext db)
        {
            var employee = db.Employees.Where(e => e.EmployeesProjects
                                              .Any(ep => ep.Project.StartDate.Year >= 2001
                                                   && ep.Project.StartDate.Year <= 2003))
                     .Take(30).Select(e => new
                     {
                         Name = e.FirstName + ' ' + e.LastName,
                         ManagerName = e.Manager.FirstName + ' ' + e.Manager.LastName,
                         Projects = e.EmployeesProjects.Select(ep => new
                         {
                             ep.Project.Name,
                             ep.Project.StartDate,
                             ep.Project.EndDate
                         })
                     }).ToList();

            foreach (var em in employee)
            {
                Console.WriteLine($"{em.Name} - Manager: {em.ManagerName}");
                var endDate = "";
                foreach (var project in em.Projects)
                {
                    if (project.EndDate == null)
                    {
                        endDate = "not finished";
                    }
                    else
                    {
                        endDate = project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    Console.WriteLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }
        }

        private static void AddingNewAddressUpdatingEmployee(SoftUniContext db)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = db.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;
            db.SaveChanges();

            var result = db.Employees.Include(d => d.Address).OrderByDescending(d => d.Address.AddressId).Take(10).Select(e => e.Address.AddressText);

            foreach (var addressText in result)
            {
                Console.WriteLine(addressText);
            }
        }

        private static void EmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            var selectedEmployee = db.Employees.Where(d => d.Department.Name == "Research and Development").OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                   .Select(e => new
                   {
                       e.FirstName,
                       e.LastName,
                       e.Department.Name,
                       e.Salary
                   });

            foreach (var employee in selectedEmployee)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }
        }

        private static void EmployeesWithSalaryOver50000(SoftUniContext db)
        {
            var employeeSalary = db.Employees.Select(e => new
            {
                e.FirstName,
                e.Salary
            }).Where(e => e.Salary > 50000).OrderBy(e => e.FirstName);

            foreach (var emplSalary in employeeSalary)
            {
                Console.WriteLine($"{emplSalary.FirstName}");
            }
        }

        private static void EmployeesFullInformation(SoftUniContext db)
        {
            var employeesInformation = db.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).OrderBy(e => e.EmployeeId);

            foreach (var employee in employeesInformation)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
        }
    }
}
