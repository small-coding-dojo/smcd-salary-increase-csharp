using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SCD_SalaryIncrease
{
    public class SimpleListEmployeeRepository : IRepository<Employee>
    {
        private List<Employee> _ourEmployees = new List<Employee>();

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get(Expression<Func<Employee, bool>> filter)
        {
            List<Employee> newList = new List<Employee>();
            if (filter == null)
            {
                foreach (var employee in _ourEmployees)
                {
                    newList.Add(cloneEmployee(employee));
                }
                return newList;
            }

            Func<Employee, bool> func = filter.Compile();
            foreach (var employee in _ourEmployees.FindAll(func.Invoke))
            {
                newList.Add(cloneEmployee(employee));
            }
            return newList;
        }

        public Employee Update(Employee theEmployee)
        {
            var toUpdate = _ourEmployees.Find(x => x.Id == theEmployee.Id);
            _ourEmployees.Remove(toUpdate);
            _ourEmployees.Add(cloneEmployee(theEmployee));
            return cloneEmployee(_ourEmployees.First());
        }

        private Employee cloneEmployee(Employee jangoFat)
        {
            return new Employee()
            {
                CurrentSalary = jangoFat.CurrentSalary,
                Email = jangoFat.Email,
                Id = jangoFat.Id
            };
        }

        public Employee Insert(Employee newEmployee)
        {
            _ourEmployees.Add(cloneEmployee(newEmployee));
            return cloneEmployee(newEmployee);
        }

        public void Insert(int id)
        {
            throw new NotImplementedException();
        }
    }
}