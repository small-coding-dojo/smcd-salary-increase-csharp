using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public class Employee : IDbEntity
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public decimal CurrentSalary { get; set; }
		//... more
	}
}
