using System;
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

            if ( _employeeRepository != null ) {
                _employeeRepository.Update(new Employee{CurrentSalary=1450, Email="hugo@example.com"});
            }

            _notify.NotifySuccess($"{email} salary is manually increased {percent} successfully.");
        }
    }
}