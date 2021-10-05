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
			object actual = new EmployeeSalaryIncrease();
			Assert.IsInstanceOf<IEmployeeSalaryIncrease>(actual);			
		}
		
		[Test]
		public void EmailIsNull_ThrowsArgumentException()
		{
			IEmployeeSalaryIncrease actual = new EmployeeSalaryIncrease();
			Assert.Throws<ArgumentException>(() => actual.IncreaseSalaryByEmail(null, null));
		}

        [Test]
        public void GetSuccessNotificationOnManualSalaryIncrease()
        {
            IEmployeeSalaryIncrease actual = new EmployeeSalaryIncrease();
            var notifyMock = new Mock<INotify>();
			notifyMock.Verify(x => x.NotifySuccess("{email} salary is manually increased {percent} successfully."));
        }
	}
}
