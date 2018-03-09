using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
    public class DirectorRepository
    {
            private agf_context _context;

            public DirectorRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<director> GetALL()
        {
            return _context.directors.ToList();

        }
        public void Add(director director)
        {
            _context.directors.Add(director);
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
