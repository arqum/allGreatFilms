using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace AllGreatFilms.DataAcessLayer.Interfaces
{
    public interface IUserRepository<user> where user: class
    {

        //user Get(int id);
        //IEnumerable<user> GetAll();
        //IEnumerable<user> Find(Expression<Func<user, bool>> predicate);

        //// This method was not in the videos, but I thought it would be useful to add.
        //user SingleOrDefault(Expression<Func<user, bool>> predicate);

         void Add(user entity);
        //void AddRange(IEnumerable<user> entities);

        //void Remove(user entity);
        //void RemoveRange(IEnumerable<user> entities);
	
    }
}
