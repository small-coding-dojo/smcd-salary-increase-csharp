using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface IEmployeeSalary : IDbEntity
	{
		string Email { get; set; }
		decimal CurrentSalary { get; set; }
	}
}
