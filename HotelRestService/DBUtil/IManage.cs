using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRestService.DBUtil
{
    interface IManage<T>
    {

        IEnumerable<T> Get();
        T Get(int id);
        bool Post(T elem);
        bool Put(int id, T elem);
        bool Delete(int id);

    }
}
