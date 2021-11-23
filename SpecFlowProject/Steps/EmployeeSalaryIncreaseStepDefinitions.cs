using NUnit.Framework;
using SCD_SalaryIncrease;
using System;
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
        }
        [Given(@"there is an employee with email ""(.*)"" and id ""(.*)"" and salary (.*),")]
        public void GivenThereIsAnEmployeeWithEmailAndIdAndSalary(string p0, string p1, int p2)
        {
            _scenarioContext.Pending();
        }

        [When(@"I Increase the Salary for ""(.*)"" by ""(.*)"" percent")]
        public void WhenIIncreaseTheSalaryForByPercent(string p0, string p1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"""(.*)"" salary is (.*)")]
        public void ThenSalaryIs(string p0, int p1)
        {
            // will be called 2 times
            _employeeRepository.Get(p=>p.Email == p0);


        }
    }
}

