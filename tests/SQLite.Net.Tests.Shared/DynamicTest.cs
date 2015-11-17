using NUnit.Framework;
using System.Linq;
using System.Dynamic;
using System.Collections.Generic;
using System;

namespace SQLite.Net.Tests
{
    [TestFixture]
    public class DynamicTest
    {
        TestDb _db;

        [SetUp]
        public void SetUp()
        {
            _db = new TestDb();
            _db.CreateTable<Product>();

            var p1 = new Product { Name = "One", };
            var p2 = new Product { Name = "Two", };
            var p3 = new Product { Name = "Three", };
            _db.InsertAll(new[] { p1, p2, p3 });
        }

        [Test]
        public void DynamicSelect()
        {
#if __IOS__ || __DROID__
			Assert.Ignore("The 'dynamic' keyword is not supported in iOS or Android");
#else
            var result = _db.Query("SELECT * FROM Product");
            Assert.AreEqual(3, result.Count);

            var first = result.First();
            var name = first.Name;
            Assert.AreEqual("One", name);

            var names = result.Select(r => r.Name);
            var isTwo = names.Contains("Two");
            Assert.IsTrue(isTwo);
#endif
        }

        [Test]
        public void CheckExpandoObject()
        {

#if __IOS__ || __DROID__
			Assert.Ignore("The 'dynamic' keyword is not supported in iOS or Android");
#else
            dynamic obj = new ExpandoObject();
//            obj.AddProperty("Name", "potato");
            obj.Name = "potato";
            var name = obj.Name;
            Assert.AreEqual("potato", name);
#endif
        }
    }
}
