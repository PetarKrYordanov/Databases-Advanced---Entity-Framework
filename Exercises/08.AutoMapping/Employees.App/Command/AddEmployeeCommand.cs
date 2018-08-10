namespace Employees.App.Command
{
    using Employees.DtoModels;
    using Employees.Services;

    class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Excecute(params string[] args)
        {
            string FirstName = args[0];
            string LastName = args[1];
            decimal Salary =decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto(FirstName, LastName, Salary);

            employeeService.AddEmployee(employeeDto);
            return $"Employee {FirstName} {LastName} succesfully added";
        }
    }
}
