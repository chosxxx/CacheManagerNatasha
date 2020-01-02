using System;
using System.Collections.Generic;
using CacheManagerNatasha;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CacheManagerNatashaTest
{
    [TestClass]
    public class CacheManagerTest
    {
        [TestMethod]
        public void TestPutDoesInsert()
        {
            var cacheList = new Dictionary<string, object>();
            var cacheManager = new CacheManager(cacheList);

            string key = "natasha";
            var age = 22;

            cacheManager.put(key, age);

            Assert.IsTrue(cacheList.Count == 1);
            Assert.AreEqual(cacheList[key], age);
        }

        [TestMethod]
        public void TestPutDoesNotAllowNullOnKey()
        {
            var cacheList = new Dictionary<string, object>();
            var cacheManager = new CacheManager(cacheList);

            string key = null;
            var age = 22;

            cacheManager.put(key, age);

            Assert.IsTrue(cacheList.Count == 0);
        }

        [TestMethod]
        public void TestPutDoesNotAllowNullOnObject()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            string key = "natasha";
            object age = null;

            cacheManager.put(key, age);

            Assert.IsTrue(cacheList.Count == 0);
        }

        [TestMethod]
        public void TestPutModifiesExisting()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            string key = "natasha";
            var age = 22;

            cacheManager.put(key, age);

            Assert.IsTrue(cacheList.Count == 1);
            Assert.AreEqual(cacheList[key], 22);

            age = 23;
            cacheManager.put(key, age);
            Assert.AreEqual(cacheList[key], age);
        }

        [TestMethod]
        public void TestGetObjectByKey()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            string key = "natasha";
            var age = 22;
            cacheList.Add(key, age);

            Assert.AreEqual(cacheManager.get(key), age);

        }

        [TestMethod]
        public void TestGetObjectDoesNotAllowNull()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            String key = null;

            Assert.IsNull(cacheManager.get(key));
        }

        [TestMethod]
        public void TestGetReturnsNullIfObjectDoesntExist()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            String key = "natasha";
            var age = 22;
            cacheList.Add(key, age);

            Assert.AreEqual(cacheManager.get(key), age);

            Assert.IsNull(cacheManager.get("invalidKey"));
        }

        [TestMethod]
        public void TestRemoveDeletesFromCache()
        {
            var cacheList = new Dictionary<String, object>();
            var cacheManager = new CacheManager(cacheList);

            String key = "natasha";
            var age = 22;
            cacheList.Add(key, age);


            var removedValue = cacheManager.get(key);
            Assert.AreEqual(removedValue, age);

            Assert.AreSame(cacheManager.remove(key), removedValue);

            Assert.IsNull(cacheManager.get(key));
        }

        [TestMethod]
        public void TestRemoveReturnsNullIfDoesntExist()
        {
            var cacheList = new Dictionary<string, object>();
            var cacheManager = new CacheManager(cacheList);

            String key = "natasha";
            var age = 22;

            cacheList.Add(key, age);

            Assert.AreEqual(cacheManager.get(key), 22);

            Assert.IsNull(cacheManager.remove("invalido"));
        }

        [TestMethod]
        public void TestInvalidateClearsCache()
        {
            var cacheList = new Dictionary<string, object>();
            var cacheManager = new CacheManager(cacheList);

            String key = "natasha";
            for (int age = 22; age < 30; age++)
                cacheList.Add($"{key}{age}", age);

            cacheManager.invalidate();

            Assert.AreEqual(cacheList.Count, 0);
        }
    }
}
