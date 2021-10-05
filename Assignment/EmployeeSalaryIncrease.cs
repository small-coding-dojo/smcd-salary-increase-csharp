using System;
using Microsoft.VisualBasic;
using Moq;

namespace SCD_SalaryIncrease
{
    internal class EmployeeSalaryIncrease : IEmployeeSalaryIncrease
    {
        private readonly INotify _notify;

        public EmployeeSalaryIncrease(INotify notify)
        {
            _notify = notify;
        }

        public void IncreaseSalaryByEmail(string email, decimal? percent = null)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException(nameof(email));
            }

            _notify.NotifySuccess($"{email} salary is manually increased {percent} successfully.");
        }
    }
}