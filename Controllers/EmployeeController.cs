using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private  IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            return Ok(emp);
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employeeList = _employeeRepository.Get();
            return Ok(employeeList);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            var emp = _employeeRepository.AddEmployee(employee);

            if (emp == null)
                return BadRequest();

            return Ok(emp);
        }

        [HttpPut]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var emp = _employeeRepository.UpdateEmployee(employee);

            if (emp == null)
                return BadRequest();

            return Ok(emp);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            bool isDeleted = _employeeRepository.DeleteEmployee(id);

            if (!isDeleted)
                return BadRequest();

            return Ok("Success!");
        }
    }
}
