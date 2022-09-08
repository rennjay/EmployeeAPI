using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static List<Employee> EmployeeList = new List<Employee>();
        public bool DeleteEmployee(int id)
        {
            var emp = EmployeeList.First(e => e.Id == id);
            bool isEmployeeFound = emp != null;

            if (isEmployeeFound)
                EmployeeList.Remove(emp);

            return isEmployeeFound;
        }

        public Employee GetEmployee(int id)
        {
            var employee = EmployeeList.FirstOrDefault(emp => emp.Id == id);

            return employee;
        }

        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>
            {
                new Employee() {Id = 1, FirstName = "John", LastName = "Doe", MiddleName = "Washington" },
                new Employee() {Id = 2, FirstName = "Donald", LastName = "Trump", MiddleName = "Jj" },
                new Employee() {Id = 3, FirstName = "Barack", LastName = "Obama", MiddleName = "UnknownMiddleName" },
            };

            if (EmployeeList.Count == 0)
                EmployeeList = employees;

            return EmployeeList;
        }

        public Employee UpdateEmployee(Employee emp)
        {

            var isValid = !String.IsNullOrEmpty(emp.FirstName) && !String.IsNullOrEmpty(emp.FirstName) && !String.IsNullOrEmpty(emp.MiddleName);

            if (isValid)
            {
                var updatedEmployee = EmployeeList.First(e => e.Id == emp.Id);

                // Save
                updatedEmployee.FirstName = emp.FirstName;
                updatedEmployee.LastName = emp.LastName;
                updatedEmployee.MiddleName = emp.MiddleName;

                return updatedEmployee;
            }
            else
            {
                return null;
            }
        }

        public Employee AddEmployee(Employee emp)
        {
            var isValid = !String.IsNullOrEmpty(emp.FirstName) && !String.IsNullOrEmpty(emp.FirstName) && !String.IsNullOrEmpty(emp.MiddleName);
            
            if (isValid)
            {
                emp.Id = EmployeeList.Count + 1;
                EmployeeList.Add(emp);
                return emp;
            }
            else
            {
                return null;
            }
        }
    }
}
