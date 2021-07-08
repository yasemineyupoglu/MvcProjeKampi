using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class YöneticiManager:IYöneticiService
    {
        IYöneticiDal _yöneticiDal;

        public YöneticiManager(IYöneticiDal yöneticiDal)
        {
            _yöneticiDal = yöneticiDal;
        }

        public Admin GetById(int id)
        {
            return _yöneticiDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _yöneticiDal.List();
        }

        public void YöneticiAdd(Admin admin)
        {
            _yöneticiDal.Insert(admin);
        }

        public void YöneticiDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void YöneticiUpdate(Admin admin)
        {
            _yöneticiDal.Update(admin);
        }
    }
}
