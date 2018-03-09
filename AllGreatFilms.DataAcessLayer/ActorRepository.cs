using AllGreatFilms.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.DataAcessLayer
{
    public class ActorRepository
    {
         private agf_context _context;

            public ActorRepository()
        {
            _context = new agf_context();
        }

        public IEnumerable<actor> GetALL()
        {
            return _context.actors.ToList();

        }
        public void Add(actor actor)
        {
            _context.actors.Add(actor);
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
