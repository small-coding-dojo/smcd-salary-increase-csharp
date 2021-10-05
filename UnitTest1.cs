using NUnit.Framework;

namespace SCD_SalaryIncrease
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void HasAppropriateInterface()
		{
			object actual = new EmployeeSalaryIncrease();
			Assert.IsInstanceOf<IEmployeeSalaryIncrease>(actual);			
		}
	}
}