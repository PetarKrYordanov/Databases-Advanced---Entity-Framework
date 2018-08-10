namespace Employees.App.Command
{
    using System;
    using System.Linq;
    using System.Text;

    using Services;
    class ManagerInfoCommand : ICommand
    {
        public readonly EmployeeService employeeService;
        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var mangerDto = employeeService.ManagerById(employeeId);

            var result = new StringBuilder();
            result.AppendLine($"{mangerDto.FirstName} {mangerDto.LastName}" +
                $" | Employees: {mangerDto.Employees.Count()}");
            foreach (var employee in mangerDto.Employees.OrderBy(x=>x.LastName).ThenBy(x=>x.LastName))
            {
                result.AppendLine($"\t-{employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }

            return result.ToString();
        }
    }
}
