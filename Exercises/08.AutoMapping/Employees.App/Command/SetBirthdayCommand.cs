namespace Employees.App.Command
{
    using System;
    using Employees.Services;

    class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        //•	SetBirthday<employeeId> <date: "dd-MM-yyyy"> – sets the birthday of the employee to the given date
        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

           var employeeName= employeeService.SetBirthday(employeeId, date);

            return $"{employeeName}`s birthday was set to {args[1]}";
        }
    }
}
