using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Domain;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.Concretes;
using PaparaThirdWeek.Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        
       
        [HttpPost]
        public IActionResult Post(EmployeeDTO employee)            //post employee
        {
            var employeeDto = new Employee
            {
                Name = employee.Name,
                Adress = employee.Adress,
                City = employee.City,
                CreatedBy = "Eda",
                CreatedDate = System.DateTime.Now,
                Email = employee.Email,
                IsDeleted = false,
                TaxNumber = employee.TaxNumber
            }
            ;
            employeeService.Add(employeeDto);
            return Ok();
        }

        [HttpGet("Employees")]                                        //get all employees
        public IActionResult Get()
        {
            var result = employeeService.GetAll();
            return Ok(result);
        }

       [HttpDelete("{id:int}")]                               //delete by id

       public IActionResult DeleteById(int id )
        {
            var List = employeeService.GetAll();
            var emp = List.FirstOrDefault(x => x.Id == id);

            if (emp.Id == id)
            {
                employeeService.Remove(emp);
                return Ok();
            }
            else
                return BadRequest();
         

        }

        [HttpGet("/Employee")]                     //get by Id

        public IActionResult GetById(int id)
        {
            var List = employeeService.GetAll();
            var emp = List.FirstOrDefault(x => x.Id == id);
            {
                if (emp.Id == id)
                {
                    employeeService.Get(emp);
                    return Ok(emp);
                }
                else
                    return BadRequest();
            }

        }


        [HttpPut]
        [Route("updated")]

       
        public IActionResult UpdateEmp(int id, Employee employee)
        {


          
            if (employee.Id == id)
            {
                var List = employeeService.GetAll();
                var emp = List.FirstOrDefault(x => x.Id == id);

                emp.Name = employee.Name;
                emp.Adress = employee.Adress;
                emp.City = employee.City;
                emp.Email = employee.Email;
                emp.TaxNumber = emp.TaxNumber;

                employeeService.Update(emp);
                return Ok(emp);
            }
            else
            {
                return NotFound("try again");
            }


            }
        }

    }


      
