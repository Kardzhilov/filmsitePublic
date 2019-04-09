using DAL;
using Model;
using Model.BLL;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interface;
using DAL;
using DAL.Repositories;
using System.Linq;

namespace BLL
{
    public class FAQLogic
    {
        //Will not create a ceperate model for the BLL FAQ 
        //as they would be nearly identical in this instance
        private FAQDAL FaqDal;

        public FAQLogic() {
            FaqDal = new FAQDAL();
        }

        public bool Create(FAQModelDAL Question)
        {
            var result = FaqDal.Create(Question);
            return result;
        }

        public List<FAQModelDAL> GetNonUser()
        {
            var list = FaqDal.GetAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Answer != "")
                {
                    list.Remove(list[i]);
                }
            }
            return list;
        }

        public List<FAQModelDAL> GetUser()
        {
            var list = FaqDal.GetAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Answer == "")
                {
                    list.Remove(list[i]);
                }
            }
            return list;
        }

        public List<FAQModelDAL> GetAll() {
            var list = FaqDal.GetAll();
            return list;
        }

        public List<FAQModelDAL> GetSorted()
        {
            var list = GetAll();
            list = list.OrderBy(item => item.Score).Reverse().ToList();
            return list;
        }

        public bool UpVote(int ID) {
            var result = FaqDal.UpVote(ID);
            return result;
        }
        public bool DownVote(int ID)
        {
            var result = FaqDal.DownVote(ID);
            return result;
        }

    }
}
