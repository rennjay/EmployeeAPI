using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();

        Employee GetEmployee(int id);

        Employee AddEmployee(Employee emp);

        Employee UpdateEmployee(Employee emp);

        bool DeleteEmployee(int id);
    }
}
