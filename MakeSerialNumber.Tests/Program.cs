using MakeSerialNumber.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSerialNumber.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            for (int i = 0; i <= 1000; i++)
            {
                num += i;
            }
            Console.WriteLine(num);

            //using (var db = new DBContext())
            //{
            //    var query = db.SerialNumbers.AsNoTracking().FirstOrDefault(o => o.Name.Equals("测试"));
            //    //if (query != null)
            //    //    grainState.State = query;
            //    //else
            //    //{
            //    //    db.SerialNumbers.Add(new SerialNumberInfo
            //    //    {
            //    //        Name = grainReference.GetPrimaryKeyString(),
            //    //        Number = 1
            //    //    });
            //    //    db.SaveChanges();
            //    //    grainState.State = new SerialNumberInfo
            //    //    {
            //    //        Name = grainReference.GetPrimaryKeyString(),
            //    //        Number = 1
            //    //    };
            //    //}
            //}
        }
    }
}
