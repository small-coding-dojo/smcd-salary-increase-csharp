using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface IEmployeeSalaryIncrease
	{
		(decimal oldSalary, decimal newSalary) IncreaseSalaryByEmail(string email, int? increasePercent = null);
	}
}
