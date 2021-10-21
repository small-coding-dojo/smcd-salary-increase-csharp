using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using Moq;
using FluentAssertions;

namespace SCD_SalaryIncrease
{
    public class EmployeeSalaryIncreaseTests
    {
        private Mock<INotify> _notifyMock;

        [SetUp]
        public void setup()
        {
            _notifyMock = new Mock<INotify>();
        }

        [Test]
        public void HasAppropriateInterface()
        {
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
            Assert.IsInstanceOf<IEmployeeSalaryIncrease>(actual);
        }


        [Test]
        public void EmailIsNull_ThrowsArgumentException()
        {
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
            Assert.Throws<ArgumentException>(() => actual.IncreaseSalaryByEmail(null, null));
        }

        [Test]
        public void GetSuccessNotificationOnManualSalaryIncrease()
        {
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
            const string expected = "someone@example.com salary is manually increased 45 successfully.";

            actual.IncreaseSalaryByEmail("someone@example.com", 45);

            _notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
        }

        [Test]
        public void ManualSalaryIncreaseInvokesRepositoryInsert()
        {
            Employee captured = null;
            var employeeRepositoryMock = new Mock<IRepository<Employee>>();
            employeeRepositoryMock.Setup(m => m.Update(It.IsAny<Employee>())).Callback<Employee>(emp => captured = emp);

            // given an employee with a salary of 1000 and the email address hugo@example.com

            // when calling increaseSalaryByEmail on that employee with an increase of 45
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object, employeeRepositoryMock.Object);
            actual.IncreaseSalaryByEmail("hugo@example.com", 45);

            // then the salary of the employee is updated to 1450

            employeeRepositoryMock.Verify(m => m.Update(It.IsAny<Employee>()), Times.Once);
            captured.CurrentSalary.Should().Be(1450);
        }

        [Test]
        public void ManualSalaryIncreaseInvokesRepositoryInsert_Duplicated()
        {
            Employee captured = null;
            var employeeRepositoryMock = new Mock<IRepository<Employee>>();
            employeeRepositoryMock.Setup(m => m.Update(It.IsAny<Employee>())).Callback<Employee>(emp => captured = emp);

            // given an employee with a salary of 1000 and the email address hugo@example.com
            var employee = new Employee
            {
                CurrentSalary = 1000,
                Email = "hugo@example.com"
            };
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>()))
                .Returns(new List<Employee> { employee });

            // when calling increaseSalaryByEmail on that employee with an increase of 30
            var actual = new EmployeeSalaryIncrease(_notifyMock.Object, employeeRepositoryMock.Object);
            actual.IncreaseSalaryByEmail("hugo@example.com", 30);

            // then the salary of the employee is updated to 1300

            employeeRepositoryMock.Verify(m => m.Update(It.IsAny<Employee>()), Times.Once);
            captured.CurrentSalary.Should().Be(1300);
        }
    }
}
