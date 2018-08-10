namespace Employees.Services
{
    using AutoMapper;

    using Employees.Data;
    using Employees.Models;
    using Employees.DtoModels;
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections.Generic;

    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int EmployeeId)
        {
            var employee = context.Employees.Find(EmployeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public List<ProjectionDto> TakeProjectionDto(int age)
        {
         
            var employees = context.Employees.Include(d=>d.Manager)   
                        .Where(e=>e.Birthday.HasValue )
                        .Where(x => x.Birthday.Value.AddYears(age) <= DateTime.Now)                        
                        .OrderByDescending(e => e.Salary)
                        .ThenBy(e=>e.FirstName)
                        .ThenBy(e=>e.LastName)
                        .ThenBy(e=>e.Manager.LastName);
            var projectionDto = Mapper.Map<List<ProjectionDto>>(employees);
            return projectionDto;
        }

        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public string SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees
                        .Find(employeeId);

            employee.Birthday = date;

            context.SaveChanges();
            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            employee.Address = address;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public EmployeePersonalDto PersonById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeeDto;
        }

        public string SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees.Find(employeeId);
            employee.ManagerId = managerId;
           
            context.SaveChanges();

            return $"Employe with id ({employeeId}) {employee.FirstName} {employee.FirstName}" +
                $" with salary:{employee.Salary} has manager with id ({managerId})";
        }

        public ManagerDto ManagerById(int managerId)
        {
            var employee = context.Employees
                      .Include(d => d.Employees)
                      .First(e => e.Id == managerId);

            var managerDto = Mapper.Map<ManagerDto>(employee);
            return managerDto;
        }            
    }
}

