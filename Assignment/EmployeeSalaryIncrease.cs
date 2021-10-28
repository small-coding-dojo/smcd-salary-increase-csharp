using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Moq;

namespace SCD_SalaryIncrease
{
	internal class EmployeeSalaryIncrease : IEmployeeSalaryIncrease
	{
		private readonly INotify _notify;
		private readonly IRepository<Employee> _employeeRepository;

		public EmployeeSalaryIncrease(INotify notify)
		{
			_notify = notify;
			_employeeRepository = null;
		}


		public EmployeeSalaryIncrease(INotify notify, IRepository<Employee> employeeRepository)
		{
			_notify = notify;
			_employeeRepository = employeeRepository;
		}

		public void IncreaseSalaryByEmail(string email, decimal? percent = null)
		{
			if (string.IsNullOrEmpty(email))
			{
				throw new ArgumentException(nameof(email));
			}

			Expression<Func<Employee, bool>> filter = employee => employee.Email == email; 
			var employees = _employeeRepository.Get(null);
			var employee = employees.First();
			
			if(!percent.HasValue)
			{
				throw new NotImplementedException("Basing raises based on historical data not yet implemented");
			}

			var increase = employee.CurrentSalary * (percent.Value / 100);
			employee.CurrentSalary += increase;

			_employeeRepository?.Update(employee);

			_notify.NotifySuccess($"{email} salary is manually increased {percent} successfully.");
		}
	}
}
