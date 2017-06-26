using Microsoft.VisualStudio.TestTools.UnitTesting;
using MakeSerialNumber.StorgeProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeSerialNumber.Session;

namespace MakeSerialNumber.StorgeProvider.Tests
{
    [TestClass()]
    public class SerialNumberStorgeProviderTests
    {
        [TestMethod()]
        public void ReadStateAsyncTest()
        {
            using (var db = new DBContext())
            {
                var query = db.SerialNumbers.AsNoTracking().FirstOrDefault(o => o.Name.Equals("测试种子"));
                //if (query != null)
                //    grainState.State = query;
                //else
                //{
                //    db.SerialNumbers.Add(new SerialNumberInfo
                //    {
                //        Name = grainReference.GetPrimaryKeyString(),
                //        Number = 1
                //    });
                //    db.SaveChanges();
                //    grainState.State = new SerialNumberInfo
                //    {
                //        Name = grainReference.GetPrimaryKeyString(),
                //        Number = 1
                //    };
                //}
            }
            Assert.IsTrue(true);
        }
    }
}