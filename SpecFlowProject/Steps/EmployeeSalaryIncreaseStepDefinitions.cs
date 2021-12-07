using SCD_SalaryIncrease;
using System.Linq;
using FluentAssertions;
using SpecFlowProject.MemoryRepository;
using TechTalk.SpecFlow;
using Moq;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class EmployeeSalaryIncreaseStepDefinitions
    {
        private IRepository<Employee> _employeeRepository;

        public EmployeeSalaryIncreaseStepDefinitions(ScenarioContext scenarioContext)
        {
            _employeeRepository = new MemoryEmployeeRepository();
        }

        [Given(@"there is an employee with email ""(.*)"" and id ""(.*)"" and salary (.*),")]
        public void GivenThereIsAnEmployeeWithEmailAndIdAndSalary(string email, int id, int salary)
        
        
        {
            var employee = new Employee { Email= email, Id=id, CurrentSalary=salary};
            _employeeRepository.Insert(employee);
        }

        [When(@"I Increase the Salary for ""(.*)"" by ""(.*)"" percent")]
        public void WhenIIncreaseTheSalaryForByPercent(string email, decimal percent)
        {
            var notifyStub = new Mock<INotify>();
            var increase = new EmployeeSalaryIncrease(notifyStub.Object, _employeeRepository);
            increase.IncreaseSalaryByEmail(email, percent);
        }

        [Then(@"""(.*)"" salary is (.*)")]
        public void ThenSalaryIs(string email, int salary)
        {
            // will be called 2 times
            var employees = _employeeRepository.Get(p => p.Email == email);
            employees.Count().Should().Be(1);
            employees.First().CurrentSalary.Should().Be(salary);
        }
    }
}
