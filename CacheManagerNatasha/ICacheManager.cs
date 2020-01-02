using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagerNatasha
{
    interface ICacheManager
    {
        void put(string key, object valueToPut);
        Object get(string key);
        object remove(string key);
        void invalidate();
    }
}
