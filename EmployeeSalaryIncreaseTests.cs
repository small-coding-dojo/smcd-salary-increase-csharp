using System;
using NUnit.Framework;
using Moq;

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
            // given an emplyee with a salary of 1000 and the email address hugo@example.com

            // when calling TncreaseSalaryByEmail on that employee with an increate of 45

            // then the salary of the employee is updated to 1450
            

            var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
            const string expected = "someone@example.com salary is manually increased 45 successfully.";

            actual.IncreaseSalaryByEmail("someone@example.com", 45);

            _notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
        }
    }
}