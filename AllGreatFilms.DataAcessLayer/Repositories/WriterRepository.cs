using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
   public class WriterRepository
    {
        private agf_context _context;

        public WriterRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<writer> GetALL()
        {
            return _context.writers.ToList();

        }
        public void Add(writer director)
        {
            _context.writers.Add(director);
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
