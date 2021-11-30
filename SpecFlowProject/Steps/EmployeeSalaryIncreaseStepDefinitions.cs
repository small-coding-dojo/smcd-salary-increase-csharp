using SCD_SalaryIncrease;
using System.Linq;
using FluentAssertions;
using SpecFlowProject.MemoryRepository;
using TechTalk.SpecFlow;


namespace SpecFlowProject.Steps
{
    [Binding]
    public class EmployeeSalaryIncreaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IRepository<Employee> _employeeRepository;

        public EmployeeSalaryIncreaseStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _employeeRepository = new MemoryEmployeeRepository();
        }
        [Given(@"there is an employee with email ""(.*)"" and id ""(.*)"" and salary (.*),")]
        public void GivenThereIsAnEmployeeWithEmailAndIdAndSalary(string p0, string p1, int p2)
        {
            //_scenarioContext.Pending();
        }

        [When(@"I Increase the Salary for ""(.*)"" by ""(.*)"" percent")]
        public void WhenIIncreaseTheSalaryForByPercent(string p0, string p1)
        {
            //_scenarioContext.Pending();
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
