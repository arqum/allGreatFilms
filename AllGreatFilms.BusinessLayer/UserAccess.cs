using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using AllGreatFilms.DataAcessLayer.Repositories;
using AllGreatFilms.BusinessObjectLayer;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Web.Security;
using AllGreatFilms.DataAcessLayer;
using System.Data.Entity;

namespace AllGreatFilms.BusinessLayer
{
    public class UserAccess 
    {
        private UserRepository _userRepo;
        private agf_context _db;

        public UserAccess()
        {
            _userRepo = new UserRepository();
           _db = new agf_context();

        }

     
        public void AddUser(user user)
        {
            if (_db.users.Any(e => e.email == user.email))
            {
                Debug.WriteLine("exisstsssssssssss");

            }
            else
            {

                user.id = Guid.NewGuid();
                user.last_login = DateTime.Now;
                user.date_created = DateTime.Now;
                user.status = true;
                user.role = "user";
                //hash password
                byte[] data = Encoding.UTF8.GetBytes(user.password);
                using (SHA512 sha = new SHA512Managed())
                {
                    byte[] hash = sha.ComputeHash(data);
                    var converted = Convert.ToBase64String(hash);
                    user.password = converted;
                }
                try
                {
                    _userRepo.Add(user);

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }

            }
}

        public void AddAdmin(user user)
        {
            if (_db.users.Any(e => e.email == user.email))
            {
                Debug.WriteLine("exisstsssssssssss");

            }
            else
            {

                user.id = Guid.NewGuid();
                user.last_login = DateTime.Now;
                user.date_created = DateTime.Now;
                user.status = true;
                user.role = "admin";
                //hash password
                byte[] data = Encoding.UTF8.GetBytes(user.password);
                using (SHA512 sha = new SHA512Managed())
                {
                    byte[] hash = sha.ComputeHash(data);
                    var converted = Convert.ToBase64String(hash);
                    user.password = converted;
                }
                try
                {
                    _userRepo.Add(user);

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }

            }
        }


        // USER ACTIONS

        public bool AddToWatchlist(int movie_id, Guid? user_id)
        {
            //var query = _db.users.Include(u => u.user_watched_movies.Where(w=>w.movie_id == movie_id)).Where(u=>u.id == user_id).ToList(); //already watched so can't be added to ToWatchlist
            var query = _db.movies.Include(u => u.users).Include(a=>a.user_watched_movies).Where(i=>i.movie_id == movie_id).ToList();
          //  var isAvailableInFav = query.Find(u => u.users.Any(i => i.id == user_id)); //value will be Null if it's NOT in Favs
            var isAvailableInWatched = query.Find(u => u.user_watched_movies.Any(i => i.user_id == user_id)); //value will be Null if it's NOT in Watched

            
                if (isAvailableInWatched == null)
                {
                    _userRepo.AddToWatchlist(movie_id, user_id);
                    return (true);
                }

                return (false);

            }



        public bool User_AddToFav(int movie_id, Guid? user_id)
        {

            var query = _db.movies.Include(u=>u.users1).Where(a=>a.movie_id == movie_id).ToList();
           var isAvailableInWatchlist =  query.Find(y=>y.users1.Any(g=>g.id == user_id)); //value will be Null if it's NOT in Watchlist

            var query2 = _db.movies.Include(u => u.user_watched_movies).Where(a => a.movie_id == movie_id).ToList();
            var isAvailableInWatched = query2.Find(a => a.user_watched_movies.Any(b => b.user_id == user_id));// value will be Null if NOT already Watched


            if (isAvailableInWatchlist != null) //if it's in to-watch, upon adding to FAV, remove it from To-watch and add it to Watched automatically.
            {
                _userRepo.RemoveFromWatchlist(movie_id, user_id);
                _userRepo.AddToWatched(movie_id, user_id);
                _userRepo.AddToFav(movie_id, user_id); //just add to Fav
                return (true);

 

            }
            else if (isAvailableInWatched != null) // means it's watched already
            {
                
                    _userRepo.AddToFav(movie_id, user_id); //just add to Fav
                    return (true);


                }
                else 
                {
                    _userRepo.AddToFav(movie_id, user_id); // if it is not in Watched, add to both Watched and Fav 
                    _userRepo.AddToWatched(movie_id, user_id);
                    return (true);


                }

            }

          

        public bool User_AddtoWatched(int movie_id, Guid? user_id)
        {
            var query = _db.movies.Include(u => u.users1).Where(a => a.movie_id == movie_id).ToList();
            var isAvailableInWatchlist = query.Find(y => y.users1.Any(g => g.id == user_id)); //value will be Null if it's NOT in Watchlist

            if (isAvailableInWatchlist != null) //if it's in to-watch, upon adding to FAV, remove it from To-watch and add it to Watched automatically.
            {

                _userRepo.RemoveFromWatchlist(movie_id, user_id);
                _userRepo.AddToWatched(movie_id, user_id);
                return (true);



            }
            else
            {

             _userRepo.AddToWatched(movie_id, user_id);
             return (true);
            }

        


        }

   

        }

    }


