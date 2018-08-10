namespace Employees.App.Command
{
    using System.Collections.Generic;
    using System.Text;
    using Services;
    class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Excecute(params string[] args)
        {
            int age = int.Parse(args[0]);

            var projectionDto = employeeService.TakeProjectionDto(age);

            var result = new StringBuilder();

            for (int i = 0; i < projectionDto.Count; i++)
            {
                var manager = projectionDto[i].ManagerLastName;
                if (manager== null)
                {
                    manager = "[no manager]";
                }
                result.AppendLine($"{projectionDto[i].FirstName} {projectionDto[i].LastName}" +
                    $" - ${projectionDto[i].Salary:f2} - Manager: {manager}");

            }

            return result.ToString().TrimEnd();
        }
    }
}
