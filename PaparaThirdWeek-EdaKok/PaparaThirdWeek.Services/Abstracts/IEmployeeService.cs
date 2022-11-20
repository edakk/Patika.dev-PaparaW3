using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.DTOS;
using System.Collections.Generic;
using System.Linq;

namespace PaparaThirdWeek.Services.Abstracts
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAll();
        public void Add(Employee employee);

        public void Update(Employee employee);

        public IEnumerable<Employee> Get(Employee employee);
        void Remove(Employee employee);
        void HardRemove(Employee employee);

    }
}
