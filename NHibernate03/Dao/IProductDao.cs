using System.Collections.Generic;
using Domain;

namespace Dao
{
    public interface IProductDao
    {
        object Save(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

        Product Get(object id);

        Product Load(object id);

        IList<Product> LoadAll();
    }
}