using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SCD_SalaryIncrease;

namespace SpecFlowProject.MemoryRepository
{
    internal class MemoryEmployeeRepository : IRepository<Employee>
    {
        internal List<Employee> _list = new List<Employee>();

        public Employee GetById(int id) 
        {
            return null;
        }
        public IEnumerable<Employee> Get(Expression<Func<Employee, bool>> filter)
        {
            return new List<Employee>();
        }
        public Employee Update(Employee entity)
        {
            return null;
        }
        public Employee Insert(Employee employee)
        {
            _list.Add(employee);
            return employee;
        }
        public void Insert(int id)
        {

        }
    }
}