using System;
using NUnit.Framework;
using Moq;

namespace SCD_SalaryIncrease
{
    public class Tests
    {
        [Test]
        public void HasAppropriateInterface()
        {
            var actual = new EmployeeSalaryIncrease(Mock.Of<INotify>());
            Assert.IsInstanceOf<IEmployeeSalaryIncrease>(actual);
        }


        [Test]
        public void EmailIsNull_ThrowsArgumentException()
        {
            var actual = new EmployeeSalaryIncrease(Mock.Of<INotify>());
            Assert.Throws<ArgumentException>(() => actual.IncreaseSalaryByEmail(null, null));
        }

        [Test]
        public void GetSuccessNotificationOnManualSalaryIncrease()
        {
            var notifyMock = new Mock<INotify>();
            var actual = new EmployeeSalaryIncrease(notifyMock.Object);
            const string expected = "someone@example.com salary is manually increased 45 successfully.";

            actual.IncreaseSalaryByEmail("someone@example.com", 45);

            notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
        }
    }
}