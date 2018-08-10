namespace Employees.App.Command
{
    using System;  
    using System.Linq;

    using Employees.Services;
    class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;
        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Excecute(params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            string address = string.Join(" ", args.Skip(1));

            var employeeName = employeeService.SetAddress(employeeId, address);

            return $"{employeeName}`s address was set to {address}";
        }
    }
}
