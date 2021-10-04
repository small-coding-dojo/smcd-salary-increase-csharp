﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface IUnitOfWork : IDisposable
	{
		IDbConnection Connection { get; }
		IDbTransaction Transaction { get; }
		void Begin();
		void Commit();
		void Rollback();
	}
}
