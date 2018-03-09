using AllGreatFilms.BusinessLayer.ViewModels;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AllGreatFilms.DataAcessLayer;

namespace AllGreatFilms.BusinessLayer
{
    public class MovieAccess
    {
        private MovieRepository _movieRepository;
        private agf_context _context;
        private movie _mov = new movie();


        public MovieAccess()
        {
            _movieRepository = new MovieRepository();
            _context = new agf_context();


        }

        public IEnumerable<movie> GetALL()
        {

            return _movieRepository.GetALL();
        }

        public List<random_VM> GetRandom()
        {
            List<random_VM> vm = new List<random_VM>();
            var query = from movies in _context.movies select movies;

            foreach (var result in query)
            {
                random_VM VM = new random_VM();
                VM.title = result.title;
                VM.year = result.year;
                VM.poster = result.poster;
                VM.synopses = result.synopsis;
                VM.Movie_id = result.movie_id;
                VM.Director_name = result.director1.name;
                VM.GreatnessRating = 0;
                VM.GRating = "";
                vm.Add(VM);


                foreach (var rating in result.ratings)
                {
                    int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                    VM.GRating = ratin + "%";

                }
            }
            return vm.ToList();

        }

        public List<random_VM> GetRandom(Guid? userId)
        {
            List<random_VM> vm = new List<random_VM>();
            var query = from movies in _context.movies select movies;

            foreach (var result in query)
            {
                random_VM VM = new random_VM();
                VM.title = result.title;
                VM.year = result.year;
                VM.poster = result.poster;
                VM.synopses = result.synopsis;
                VM.Movie_id = result.movie_id;
                VM.Director_name = result.director1.name;
                VM.GreatnessRating = 0;
                VM.GRating = "";
                vm.Add(VM);


                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {
                        // VM.Fav_movies.Add(result.movie_id);
                        VM.isFav = true;
                    }
                }

                foreach (var toWatch in result.users1)
                {
                    if (toWatch != null && toWatch.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isToWatch = true;

                    }

                }

                foreach (var watched in result.user_watched_movies)
                {
                    if (watched != null && watched.user_id == userId)
                    {
                        //  VM.Watched_movies.Add(watched.movie_id);
                        VM.isWatched = true;
                    }
                }

                foreach (var rating in result.ratings)
                {
                    int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                    VM.GRating = ratin + "%";

                }

            }
            return vm.ToList();

        }



        public List<homeList_vm> GetHomeList()
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(w => w.writer1).ToList();

            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();

                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.Movie_id = result.movie_id;
                VM.Synopsis = result.synopsis;



                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var rating in result.ratings)
                {
                    int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                    VM.GRating = ratin + "%";
                }



                vm.Add(VM);
            }



            #region LINQ QUERY!!!!!!!!!!!!!
            //    var query = (from movies in _context.movies
            //                 from actors in _context.actors

            //                 join directors in _context.directors on movies.director equals directors.director_id
            //                 join writers in _context.writers on movies.writer equals writers.writer_id
            //                 join ratings in _context.ratings on movies.movie_id equals ratings.movie_id

            //                 select new
            //                 {

            //                     Actor = actors.name,
            //                     Director = directors.name,
            //                     Writer = writers.name,
            //                     AgfRating = ratings.agf_rating,
            //                     movies.poster,
            //                     movies.title,
            //                     Year = movies.year,
            //                     ImdbRating = ratings.imdbR,
            //                     RTRating = ratings.rottenR,
            //                     MTRating = ratings.metaR,
            //                     UserR = ratings.user_rating

            //                 }

            //                 ).ToList().AsQueryable();

            //foreach (var item in query) //retrieve each item and assign to model
            //    {

            //        vm.Add(new homeList_vm()
            //        {
            //            Poster = item.poster,
            //            Movie_name = item.title,
            //            Director_name = item.Director,
            //            Actor_name = item.Actor,
            //            Writer_name = item.Writer,
            //            Year = item.Year,
            //            GreatnessRating = item.ImdbRating + item.MTRating + item.RTRating + item.UserR / 4,



            //        });



            //        }
            #endregion

            return vm.ToList();
        }

        public List<homeList_vm> GetHomeList(Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).ToList();


            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();

                VM.Movie_id = result.movie_id;
                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Genres = new List<string>();
                VM.Fav_movies = new List<int>();
                VM.To_watch_movies = new List<int>();
                VM.Watched_movies = new List<int>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.GRating = "";
                VM.Movie_id = result.movie_id;
                VM.Synopsis = result.synopsis;





                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var genre in result.genres)
                {
                    VM.Genres.Add(genre.name);
                }

                foreach (var rating in result.ratings)
                {
                    int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                   
                    VM.GRating = ratin + "%";
                    
                }

                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {
                        // VM.Fav_movies.Add(result.movie_id);
                        VM.isFav = true;
                    }
                }

                foreach (var toWatch in result.users1)
                {
                    if (toWatch != null && toWatch.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isToWatch = true;

                    }

                }

                foreach (var watched in result.user_watched_movies)
                {
                    if (watched != null && watched.user_id == userId)
                    {
                        //  VM.Watched_movies.Add(watched.movie_id);
                        VM.isWatched = true;
                    }
                }


                vm.Add(VM);
            }


            return vm;

        }

        public List<homeList_vm> GetHomeListForUserSelectedGenres(List<int> UserSelectedGenres, Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).Include(g => g.genres).ToList();
            var query2 = _context.genres.Where(t => UserSelectedGenres.Contains(t.genre_id)).ToList();



            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();

                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Fav_movies = new List<int>();
                VM.To_watch_movies = new List<int>();
                VM.Watched_movies = new List<int>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.Movie_id = result.movie_id;




                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var rating in result.ratings)
                {
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                }

                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {
                        // VM.Fav_movies.Add(result.movie_id);
                        VM.isFav = true;
                    }
                }

                foreach (var toWatch in result.users1)
                {
                    if (toWatch != null && toWatch.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isToWatch = true;

                    }

                }

                foreach (var watched in result.user_watched_movies)
                {
                    if (watched != null && watched.user_id == userId)
                    {
                        //  VM.Watched_movies.Add(watched.movie_id);
                        VM.isWatched = true;
                    }
                }

                foreach (var movi in query2)
                {
                    foreach (var mov in movi.movies)
                    {
                        if (mov.movie_id == result.movie_id)
                        {
                            vm.Add(VM);


                        }

                    }

                }




            }


            return vm;

        }


        public List<homeList_vm> GetHomeListForUserSelectedGenres(List<int> UserSelectedGenres)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).Include(g => g.genres).ToList();
            var query2 = _context.genres.Where(t => UserSelectedGenres.Contains(t.genre_id)).ToList();

            foreach (var result in query)
            {


                homeList_vm VM = new homeList_vm();

                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.Movie_id = result.movie_id;




                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var rating in result.ratings)
                {
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                }

                foreach (var movi in query2)
                {
                    foreach (var mov in movi.movies)
                    {
                        if (mov.movie_id == result.movie_id)
                        {
                            vm.Add(VM);


                        }

                    }

                }

            }




            return vm.ToList();
        }

        //public List<homeList_vm> GetHomeListForUserSelectedGenres(List<int> UserSelectedGenres, Guid? userId)
        //{

        //    List<homeList_vm> vm = new List<homeList_vm>();

        //    var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).Include(g => g.genres).ToList();
        //    var query2 = _context.genres.Where(t => UserSelectedGenres.Contains(t.genre_id)).ToList();

        //    foreach (var result in query)
        //    {


        //        homeList_vm VM = new homeList_vm();

        //        VM.Movie_name = result.title;
        //        VM.Actor_name = new List<string>();
        //        VM.Director_name = result.director1.name;
        //        VM.Writer_name = result.writer1.name;
        //        VM.GreatnessRating = 0;
        //        VM.Movie_id = result.movie_id;




        //        foreach (var actor in result.actors)
        //        {
        //            VM.Actor_name.Add(actor.name);
        //        }

        //        foreach (var rating in result.ratings)
        //        {
        //            VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
        //        }

        //        foreach (var movi in query2)
        //        {
        //            foreach (var mov in movi.movies)
        //            {
        //                if (mov.movie_id == result.movie_id)
        //                {
        //                    vm.Add(VM);


        //                }

        //            }

        //        }

        //    }




        //    return vm.ToList();
        //}


        public List<homeList_vm> GetHomeListForUserSelectedMoods(List<int> UserSelectedMoods, Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).Include(g => g.genres).ToList();
            var query2 = _context.genres.Where(t => UserSelectedMoods.Contains(t.genre_id)).ToList();

            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();

                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Fav_movies = new List<int>();
                VM.To_watch_movies = new List<int>();
                VM.Watched_movies = new List<int>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.Movie_id = result.movie_id;




                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var rating in result.ratings)
                {
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                }

                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {
                        // VM.Fav_movies.Add(result.movie_id);
                        VM.isFav = true;
                    }
                }

                foreach (var toWatch in result.users1)
                {
                    if (toWatch != null && toWatch.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isToWatch = true;

                    }

                }

                foreach (var watched in result.user_watched_movies)
                {
                    if (watched != null && watched.user_id == userId)
                    {
                        //  VM.Watched_movies.Add(watched.movie_id);
                        VM.isWatched = true;
                    }
                }

                foreach (var movi in query2)
                {
                    foreach (var mov in movi.movies)
                    {
                        if (mov.movie_id == result.movie_id)
                        {
                            vm.Add(VM);


                        }

                    }

                }


            }


            return vm;

        }


        public List<homeList_vm> GetHomeListForUserSelectedMoods(List<int> UserSelectedMoods)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.actors).Include(s => s.director1).Include(s => s.ratings).Include(s => s.users).Include(s => s.users1).Include(w => w.writer1).Include(g => g.genres).ToList();
            var query2 = _context.genres.Where(t => UserSelectedMoods.Contains(t.genre_id)).ToList();

            foreach (var result in query)
            {


                homeList_vm VM = new homeList_vm();

                VM.Movie_name = result.title;
                VM.Actor_name = new List<string>();
                VM.Director_name = result.director1.name;
                VM.Writer_name = result.writer1.name;
                VM.GreatnessRating = 0;
                VM.GRating = "";
                VM.Movie_id = result.movie_id;




                foreach (var actor in result.actors)
                {
                    VM.Actor_name.Add(actor.name);
                }

                foreach (var rating in result.ratings)
                {
                    VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                    VM.GRating += "%";
                    VM.GRating = VM.GreatnessRating + "%";
                }

                foreach (var movi in query2)
                {
                    foreach (var mov in movi.movies)
                    {
                        if (mov.movie_id == result.movie_id)
                        {
                            vm.Add(VM);


                        }

                    }

                }

            }




            return vm.ToList();
        }

        public void AddMovie(movie movie)
        {

            _movieRepository.Add(movie);

        }



        public List<movie_main_vm> GetMovieDetails(int movie_id, Guid? userId)
        {

            List<movie_main_vm> vm = new List<movie_main_vm>();

            var query = _context.movies.Include(s => s.actors)
                .Include(s => s.director1)
                .Include(r => r.ratings)
                .Include(s => s.users)
                .Include(s => s.users1)
                .Include(w => w.writer1)
                .Include(aw => aw.awards)
                .Include(q => q.movie_quotes)
                .Include(m => m.moods)
                .Include(g => g.genres)
                .Include(l=>l.language1)
                .Include(c=>c.country1)
                .ToList();

            foreach (var result in query)
            {
                movie_main_vm VM = new movie_main_vm();

                if (result.movie_id == movie_id)
                {


                    VM.Movie_id = result.movie_id;
                    VM.Movie_name = result.title;
                    VM.Actor_name = new List<string>();
                    VM.quotes = new List<string>();
                    VM.awards = new List<string>();
                    VM.moods = new List<string>();
                    VM.Genres = new List<string>();
                    VM.Director_name = result.director1.name;
                    VM.Writer_name = result.writer1.name;
                    VM.GreatnessRating = 0;
                    VM.Movie_id = result.movie_id;
                    VM.Synopsis = result.synopsis;
                    VM.Year = result.year;
                    VM.Poster = result.poster;
                    VM.imdbRating = 0;
                    VM.agfRating = 0;
                    VM.mcRating = 0;
                    VM.rtRating = 0;
                    VM.imdbRatingLink = result.imdb;
                    VM.rtRatingLink = result.rottenTomatoes;
                    // VM.mcRatingLink = result.
                    VM.lang = result.language;
                    VM.country = result.country;
                    VM.agfReview = result.agfReview;



                    foreach (var mood in result.moods)
                    {
                        VM.moods.Add(mood.name);
                    }

                    foreach (var genre in result.genres)
                    {
                        VM.Genres.Add(genre.name);
                       
                    }

                    foreach (var award in result.awards)
                    {
                        VM.awards.Add(award.name);
                    }


                    foreach (var actor in result.actors)
                    {
                        VM.Actor_name.Add(actor.name);
                    }

                    foreach (var quote in result.movie_quotes)
                    {
                        VM.Actor_name.Add(quote.quote);
                    }

                    foreach (var rating in result.ratings)
                    {
                        VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                        VM.mcRating = rating.metaR;
                        VM.imdbRating = rating.imdbR;
                        VM.rtRating = rating.rottenR;


                    }

                    foreach (var fav in result.users)
                    {
                        if (fav != null && fav.id == userId)
                        {
                            // VM.Fav_movies.Add(result.movie_id);
                            VM.isFav = true;
                        }
                    }

                    foreach (var toWatch in result.users1)
                    {
                        if (toWatch != null && toWatch.id == userId)
                        {

                            //  VM.To_watch_movies.Add(result.movie_id);
                            VM.isToWatch = true;

                        }

                    }

                    foreach (var watched in result.user_watched_movies)
                    {
                        if (watched != null && watched.user_id == userId)
                        {
                            //  VM.Watched_movies.Add(watched.movie_id);
                            VM.isWatched = true;
                        }
                    }

                    vm.Add(VM);


                    // _movieRepository.Add(movie_id);

                }
            }
            return vm;
        }


        public List<movie_main_vm> GetMovieDetails(int movie_id)
        {

            List<movie_main_vm> vm = new List<movie_main_vm>();

            var query = _context.movies.Include(s => s.actors)
                .Include(s => s.director1)
                .Include(r => r.ratings)
                .Include(s => s.users)
                .Include(s => s.users1)
                .Include(w => w.writer1)
                .Include(aw => aw.awards)
                .Include(q => q.movie_quotes)
                .Include(m => m.moods)
                .Include(g => g.genres)
                .Include(l => l.language1)
                .Include(c => c.country1)
                .ToList();

            foreach (var result in query)
            {
                movie_main_vm VM = new movie_main_vm();

                if (result.movie_id == movie_id)
                {


                    VM.Movie_id = result.movie_id;
                    VM.Movie_name = result.title;
                    VM.Actor_name = new List<string>();
                    VM.quotes = new List<string>();
                    VM.awards = new List<string>();
                    VM.moods = new List<string>();
                    VM.Genres = new List<string>();
                    VM.Director_name = result.director1.name;
                    VM.Writer_name = result.writer1.name;
                    VM.GreatnessRating = 0;
                    VM.Movie_id = result.movie_id;
                    VM.Synopsis = result.synopsis;
                    VM.Year = result.year;
                    VM.Poster = result.poster;
                    VM.imdbRating = 0;
                    VM.agfRating = 0;
                    VM.mcRating = 0;
                    VM.rtRating = 0;
                    VM.imdbRatingLink = result.imdb;
                    VM.rtRatingLink = result.rottenTomatoes;
                    // VM.mcRatingLink = result.
                    VM.lang = result.language;
                    VM.country = result.country;
                    VM.agfReview = result.agfReview;



                    foreach (var mood in result.moods)
                    {
                        VM.moods.Add(mood.name);
                    }

                    foreach (var genre in result.genres)
                    {
                        VM.Genres.Add(genre.name);

                    }

                    foreach (var award in result.awards)
                    {
                        VM.awards.Add(award.name);
                    }


                    foreach (var actor in result.actors)
                    {
                        VM.Actor_name.Add(actor.name);
                    }

                    foreach (var quote in result.movie_quotes)
                    {
                        VM.Actor_name.Add(quote.quote);
                    }

                    foreach (var rating in result.ratings)
                    {
                        VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                        VM.mcRating = rating.metaR;
                        VM.imdbRating = rating.imdbR;
                        VM.rtRating = rating.rottenR;


                    }

               

                    vm.Add(VM);


                    // _movieRepository.Add(movie_id);

                }
            }
            return vm;
        }







        public List<homeList_vm> GetUserToWatchMovies(Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.users).Include(s => s.users1).ToList();


            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();



                foreach (var toWatch in result.users1)
                {
                    if (toWatch != null && toWatch.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isToWatch = true;
                        VM.Movie_id = result.movie_id;
                        VM.Movie_name = result.title;
                        VM.To_watch_movies = new List<int>();
                        VM.Director_name = result.director1.name;
                        VM.GreatnessRating = 0;
                        VM.GRating = "";



                        foreach (var rating in result.ratings)
                        {
                            int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                            VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                            VM.GRating = ratin + "%";

                        }

                        vm.Add(VM);

                    }

                }

    
            }


            return vm;

        }



        public List<homeList_vm> GetUserWatchedMovies(Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.users).Include(s => s.users1).Include(t=>t.user_watched_movies).ToList();


            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();



                foreach ( var watched in result.user_watched_movies)
                {
                    if (watched != null && watched.user_id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isWatched = true;
                        VM.Movie_id = result.movie_id;
                        VM.Movie_name = result.title;
                        VM.To_watch_movies = new List<int>();
                        VM.Director_name = result.director1.name;



                        foreach (var rating in result.ratings)
                        {
                            int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                            VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                            VM.GRating = ratin + "%";

                        }

                        vm.Add(VM);

                    }

                }


            }


            return vm;

        }

        public List<homeList_vm> GetUserFavMovies(Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.users).Include(s => s.users1).ToList();


            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();



                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isFav = true;
                        VM.Movie_id = result.movie_id;
                        VM.Movie_name = result.title;
                        VM.To_watch_movies = new List<int>();
                        VM.Director_name = result.director1.name;



                        foreach (var rating in result.ratings)
                        {
                            int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                            VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                            VM.GRating = ratin + "%";

                        }

                        vm.Add(VM);

                    }

                }


            }


            return vm;

        }


        public List<homeList_vm> GetUserReviews(Guid? userId)
        {

            List<homeList_vm> vm = new List<homeList_vm>();

            var query = _context.movies.Include(s => s.users).Include(s => s.users1).ToList();


            foreach (var result in query)
            {
                homeList_vm VM = new homeList_vm();



                foreach (var fav in result.users)
                {
                    if (fav != null && fav.id == userId)
                    {

                        //  VM.To_watch_movies.Add(result.movie_id);
                        VM.isFav = true;
                        VM.Movie_id = result.movie_id;
                        VM.Movie_name = result.title;
                        VM.To_watch_movies = new List<int>();
                        VM.Director_name = result.director1.name;



                        foreach (var rating in result.ratings)
                        {
                            int ratin = Convert.ToInt32((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;
                            VM.GreatnessRating = Convert.ToDecimal((rating.imdbR + rating.metaR + rating.user_rating + rating.rottenR) / 4) * 10;

                            VM.GRating = ratin + "%";

                        }

                        vm.Add(VM);

                    }

                }


            }


            return vm;

        }


        }

    }
