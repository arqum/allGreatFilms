using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
    public class MovieRepository
    {

        private agf_context _context;

        public MovieRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<movie> GetALL()
        {
            return _context.movies.ToList().OrderBy(x => x.dateAdded);

        }

        public IEnumerable<movie> GetHomeList()
        {

            return _context.movies.ToList().OrderBy(x => x.dateAdded);

        }

        public void Add(movie movie)
        {
            _context.movies.Add(movie);
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
