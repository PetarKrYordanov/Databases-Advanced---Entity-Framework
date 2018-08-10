namespace Employees.App.Command
{
    using Services;
    class SetManagerCommand:ICommand
    {
        private readonly EmployeeService employeeService;
        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            return employeeService.SetManager(employeeId, managerId);
        }
    }
}
