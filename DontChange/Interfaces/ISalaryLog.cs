using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface ISalaryLog : IDbEntity
	{
		int EmployeeId { get; set; }
		int Year { get; set; }
		decimal Salary { get; set; }
	}
}
