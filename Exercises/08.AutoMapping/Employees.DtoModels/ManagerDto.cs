namespace Employees.DtoModels
{
    using System.Collections.Generic;
  public  class ManagerDto
    {
        public ManagerDto()
        {

        }
        public ManagerDto(string firstName, string lastName, List<EmployeeDto> employees)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Employees = employees;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new HashSet<EmployeeDto>();
    }
}
