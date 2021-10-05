using System;

namespace SCD_SalaryIncrease
{
	internal class EmployeeSalaryIncrease : IEmployeeSalaryIncrease
	{
		public EmployeeSalaryIncrease()
		{
		}

		public void IncreaseSalaryByEmail(string email, decimal? salaryIncrease = null)
		{
			if (string.IsNullOrEmpty(email))
			{
				throw new ArgumentException(nameof(email));
			}
		}
	}
}
