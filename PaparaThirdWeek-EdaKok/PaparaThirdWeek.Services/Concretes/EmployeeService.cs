using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.Concretes
{
  public  class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Add(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.Get().ToList();
        }
        public void Remove(Employee employee)
        {
            _employeeRepository.Remove(employee);
        }
      public  IEnumerable<Employee> Get(Employee employee)
        {
            return _employeeRepository.Get().ToList();
            
        }
        public void HardRemove(Employee employee)
        {
            _employeeRepository.HardRemove(employee);
        }
        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

      
    }

   
}
