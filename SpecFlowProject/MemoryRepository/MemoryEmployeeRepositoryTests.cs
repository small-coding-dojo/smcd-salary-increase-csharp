using System.Linq;
using NUnit.Framework;
using SCD_SalaryIncrease;
using SpecFlowProject.Steps;

namespace SpecFlowProject.MemoryRepository
{
    internal class MemoryEmployeeRepositoryTests
    {
        private MemoryEmployeeRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new MemoryEmployeeRepository();
        }

        [Test]
        public void InsertTest() // Michael doesn't like this name
        {
            _repository.Insert(new Employee() { });

            Assert.AreEqual(1, _repository._list.Count());
        }

        [Test]
        public void Get_RepositoryContainsOneEmployee_ReturnsThatEmployee() // Michael doesn't like this name
        {


            var expectedEmployee = new Employee { Id = 1, Email = "lorem@ipsum.com", CurrentSalary = 1 };

            // Given Repository Contains One Employee
             _repository.Insert(expectedEmployee);
//WhenGetThenReturnsThatEmployee
            var actualEmployee = _repository.Get(p => true).First();
            
            Assert.AreSame(expectedEmployee, actualEmployee);
        }
    }
}
