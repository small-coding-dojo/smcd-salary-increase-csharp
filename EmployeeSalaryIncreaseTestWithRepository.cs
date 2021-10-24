using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SCD_SalaryIncrease
{
    public class EmployeeSalaryIncreaseTestWithRepository
    {
        private Mock<INotify> _notifyMock;
        private SimpleListEmployeeRepository _simpleListEmployeeRepository;

        [SetUp]
        public void Setup()
        {
            _notifyMock = new Mock<INotify>();
            _simpleListEmployeeRepository = new SimpleListEmployeeRepository();
            _simpleListEmployeeRepository.Insert(new Employee()
            {
                CurrentSalary = 1000, 
                Email = "hugo@example.com",
                Id = 1
            });
            _simpleListEmployeeRepository.Insert(new Employee()
			{
				CurrentSalary = 2000, 
				Email = "emil@example.com",
				Id = 2
			});
        }

        [Test]
        public void GetSuccessNotificationOnManualSalaryIncrease()
        {
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
            const string expected = "hugo@example.com salary is manually increased 45 successfully.";

            actual.IncreaseSalaryByEmail("hugo@example.com", 45);

            _notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
        }
		
        [Test]
        public void ManualSalaryIncreaseBy45PercentInvokesRepositoryUpdate()
        {
            
            // given an employee with a salary of 1000 and the email address hugo@example.com
            _simpleListEmployeeRepository.GetByEmail("hugo@example.com")
                .CurrentSalary.Should().Be(1000);
   
            // when calling increaseSalaryByEmail on that employee with an increase of 45
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
            actual.IncreaseSalaryByEmail("hugo@example.com", 45);

            // then the salary of the employee is updated to 1450
            _simpleListEmployeeRepository.GetByEmail("hugo@example.com")
                .CurrentSalary.Should().Be(1450);
            
        }
        
        [Test]
        public void ManualSalaryIncreaseBy35PercentInvokesRepositoryUpdate()
        {
            _simpleListEmployeeRepository = new SimpleListEmployeeRepository();
            _simpleListEmployeeRepository.Insert(new Employee()
            {
                CurrentSalary = 2000, 
                Email = "emil@example.com",
                Id = 5
            });
            
            // given an employee with a salary of 1000 and the email address emil@example.com
            _simpleListEmployeeRepository.GetByEmail("emil@example.com")
                .CurrentSalary.Should().Be(2000);
            
            // when calling increaseSalaryByEmail on that employee with an increase of 45
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
            actual.IncreaseSalaryByEmail("emil@example.com", 35);

            // then the salary of the employee is updated to 2700
            _simpleListEmployeeRepository.GetByEmail("emil@example.com")
                .CurrentSalary.Should().Be(2700);
        }
    }
}