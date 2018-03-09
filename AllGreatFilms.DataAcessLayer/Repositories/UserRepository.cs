using AllGreatFilms.DataAcessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllGreatFilms.BusinessObjectLayer;
using System.Data.Entity.Validation;
using System.Net.Http;
using System.Web;
using System.Data.Entity;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
    public class UserRepository : IUserRepository<user>
    {
        private agf_context _context;

        public UserRepository()
        {
            _context = new agf_context();
        }

        //List all the users
        public IEnumerable<user> GetALL()
        {
            return _context.users.ToList();

        }

      

        public Guid? GetUserIdByEmail(string email)
        {
            var id = (Guid)(from a in _context.users
                            where a.email == email

                            select a.id).FirstOrDefault();

    
            return id;
             
        }

        public void AddToWatched(int movie_id, Guid? user_id)
        {
            user_watched_movies uwm = new user_watched_movies();
            uwm.movie_id = movie_id;
            uwm.user_id = (Guid)user_id;


            _context.user_watched_movies.Add(uwm);
            Save();

        }

        public void AddToFav(int movie_id, Guid? user_id)
        {
            movie movi = _context.movies.FirstOrDefault(c => c.movie_id == movie_id);
            _context.users.FirstOrDefault(c => c.id == user_id).movies.Add(movi);

            Save();

        }
            
 
        public void AddToWatchlist(int movie_id, Guid? user_id)
        {
            movie movi = _context.movies.FirstOrDefault(c => c.movie_id == movie_id);
            _context.users.FirstOrDefault(a => a.id == user_id).movie.Add(movi);

            Save();


        }

        public void RemoveFromWatchlist(int movie_id, Guid? user_id)
        {
            movie movi = _context.movies.FirstOrDefault(c => c.movie_id == movie_id);
            _context.users.FirstOrDefault(a => a.id == user_id).movie.Remove(movi);

            Save();


        }

        //Registers a new user
        public void Add(user user)
        {
            _context.users.Add(user);
            Save();
        }

        private void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                       Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

        }
    }
}

