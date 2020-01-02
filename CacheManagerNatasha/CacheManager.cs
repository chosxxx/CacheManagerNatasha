using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagerNatasha
{
    public class CacheManager : ICacheManager
    {
        private IDictionary<string, object> cacheList;
        public CacheManager(IDictionary<string, object> _cacheList = null)
        {
            if (_cacheList == null) _cacheList = new Dictionary<string, object>();

            cacheList = _cacheList;
        }

        public object get(string key)
        {
            if (key != null && cacheList.ContainsKey(key))
                return cacheList[key];
            else
                return null;
        }

        public void invalidate()
        {
            while (cacheList.Count > 0)
                cacheList.Remove(cacheList.Keys.ElementAt(0));
        }

        public void put(string key, object valueToPut)
        {
            if(key != null && valueToPut != null)
            {
                if(cacheList.ContainsKey(key))
                {
                    cacheList[key] = valueToPut;
                }
                else
                {
                    cacheList.Add(key, valueToPut);
                }
            }
        }

        public object remove(string key)
        {
            if (key == null)
                return null;
            else
            if (!cacheList.ContainsKey(key))
                return null;
            else
            {
                var result = cacheList[key];
                cacheList.Remove(key);
                return result;
            }
        }
    }
}
