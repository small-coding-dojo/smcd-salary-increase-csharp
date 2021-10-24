using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace SCD_SalaryIncrease
{
    public class SimpleListEmployeeRepositoryTest
    {
        [Test]
        public void GettingAFilteredItemById()
        {
            Employee actual;
            SimpleListEmployeeRepository repository = new SimpleListEmployeeRepository();
            repository.Insert(new Employee()
            {
                CurrentSalary = 1000,
                Email = "higo@example.com",
                Id = 3
            });
            repository.Insert(new Employee()
            {
                CurrentSalary = 1000,
                Email = "higo@example.com",
                Id = 1
            });

            Expression<Func<Employee, bool>> filter = x => x.Id == 3 ;
            actual = repository.Get(filter).First();
            Assert.AreEqual(3, actual.Id);
        }
        
        [Test]
        public void GettingAFilteredItemByEmail()
        {
            Employee actual;
            SimpleListEmployeeRepository repository = new SimpleListEmployeeRepository();
            repository.Insert(new Employee()
            {
                CurrentSalary = 1000,
                Email = "ho@example.com",
                Id = 3
            });
            repository.Insert(new Employee()
            {
                CurrentSalary = 1000,
                Email = "higo@example.com",
                Id = 1
            });

            Expression<Func<Employee, bool>> filter = x => x.Email == "higo@example.com" ;
            actual = repository.Get(filter).First();
            Assert.AreEqual("higo@example.com", actual.Email);
        }
    }
}