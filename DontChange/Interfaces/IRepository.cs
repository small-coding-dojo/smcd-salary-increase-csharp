using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCD_SalaryIncrease
{
	public interface IRepository<Entity> where Entity : IDbEntity
	{
		Entity GetById(int id);
		IEnumerable<Entity> Get(Expression<Func<Entity, bool>> filter);
		Entity Update(Entity entity);
		Entity Insert(Entity entity);
		void Insert(int id);
	}
}
