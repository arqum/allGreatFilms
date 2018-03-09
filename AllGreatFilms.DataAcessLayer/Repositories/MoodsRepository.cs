using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer.Repositories
{
    public class MoodsRepository
    {

         private agf_context _context;

         public MoodsRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<mood> GetALL()
        {
            return _context.moods.ToList();

        }
        public void Add(mood mood)
        {
            _context.moods.Add(mood);
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
