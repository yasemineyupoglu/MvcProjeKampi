using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        //CRYD
        //Type Name();
        List<Category> List();

        void Insert(Category p);

        void Update(Category p);

        void Delete(Category p);

        List<Category> List(Expression<Func<Category, bool>> filter);
    }
}
