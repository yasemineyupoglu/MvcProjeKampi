using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IYöneticiService
    {
        List<Admin> GetList();
        void YöneticiAdd(Admin admin);
        Admin GetById(int id);
        void YöneticiDelete(Admin admin);
        void YöneticiUpdate(Admin admin);
    }
}
