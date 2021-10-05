using System;
using NUnit.Framework;

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
	}
}
