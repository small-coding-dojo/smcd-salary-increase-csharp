using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public class SalaryLog : IDbEntity
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public int Year { get; set; }
		public decimal Salary { get; set; }
		//... more
	}
}
