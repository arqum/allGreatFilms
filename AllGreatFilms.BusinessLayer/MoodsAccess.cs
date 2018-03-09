using AllGreatFilms.BusinessLayer.ViewModels;
using AllGreatFilms.BusinessObjectLayer;
using AllGreatFilms.DataAcessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGreatFilms.BusinessLayer
{
   public class MoodsAccess
    {
         private MoodsRepository _moodsRepository;

         public MoodsAccess()
        {
            _moodsRepository = new MoodsRepository();

        }

         public List<homeList_vm> GetALL()
        {
            List<homeList_vm> vm = new List<homeList_vm>();

            var res = _moodsRepository.GetALL();

            foreach (var mood in res)
            {
                homeList_vm VM = new homeList_vm();
                VM.Moods = new List<string>();

                VM.Moods.Add(mood.name);
                vm.Add(VM);
            }

            return vm.ToList();
        }

        public void AddMood(mood mood)
        {

            _moodsRepository.Add(mood);

        }
    }
}
