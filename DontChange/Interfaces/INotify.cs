using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface INotify
	{
		void NotifySuccess(string message);
		void NotifyWarning(string message);
		void NotifyError(string message);
	}
}
