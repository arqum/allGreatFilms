using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
   public class GenresRepository
    {
        private agf_context _context;

        public GenresRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<genre> GetALL()
        {
            return _context.genres.ToList();

        }
        public void Add(genre genre)
        {
            _context.genres.Add(genre);
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
