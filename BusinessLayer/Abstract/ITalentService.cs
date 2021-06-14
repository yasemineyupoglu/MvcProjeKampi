using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetList();
        void TalentAddBL(Talent talent);
        Talent GetById(int id);
        void TalentDelete(Talent talent);
        void TalentUpdate(Talent talent);
    }
}
