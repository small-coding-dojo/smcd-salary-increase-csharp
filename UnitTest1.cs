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
		public void Test2()
		{
			IEmployeeSalaryIncrease actual = new EmployeeSalaryIncrease();
			actual.IncreaseSalaryByEmail(null, null);

			Assert.Pass();			
		}
	}
}