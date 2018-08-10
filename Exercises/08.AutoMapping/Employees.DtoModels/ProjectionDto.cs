namespace Employees.DtoModels
{
    using System;
    public class ProjectionDto
    {
        public ProjectionDto()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerLastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
