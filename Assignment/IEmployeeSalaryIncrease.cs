using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface IEmployeeSalaryIncrease
	{
		void IncreaseSalaryByEmail(string email, decimal? salaryIncrease = null);
	}
}
