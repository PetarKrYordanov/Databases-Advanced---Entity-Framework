namespace Employees.App.Command
{
    using System;
    using System.Linq;

    using Employees.Services;
    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = employeeService.PersonById(employeeId);
            var birthday = employee.Birthday.Value.ToString("dd-MM-yyyy") ?? "[no birthday specified]";
            var address = employee.Address ?? "[no address specified]";

            string result = $"ID: {employeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}"+$"{Environment.NewLine}\t"+
                            $"Birthday: {birthday}"+$"{ Environment.NewLine}\t"+
                            $"Address: {address}";

            return result;
        }
    }
}
