using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
    public class CountryRepository
    {
         private agf_context _context;

         public CountryRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<country> GetALL()
        {
            return _context.countries.ToList();

        }
        public void Add(country country)
        {
            _context.countries.Add(country);
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
