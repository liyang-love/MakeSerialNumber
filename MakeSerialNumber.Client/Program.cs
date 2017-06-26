using MakeSerialNumber.Interface;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeSerialNumber.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GrainClient.Initialize();

            Console.WriteLine("按任意键开始:");
            Console.ReadKey();

            for (int i = 0; i < 100; i++)
            {
                // 并发启动多线程
                Thread thread = new Thread(new ThreadStart(Test1));
                thread.Start();
                // 并发启动多线程
                Thread thread1 = new Thread(new ThreadStart(Test2));
                thread1.Start();
                // 并发启动多线程
                Thread thread2 = new Thread(new ThreadStart(Test3));
                thread2.Start();
            }
            Console.ReadLine();
        }

        public async static void Test1()
        {
            var grain1 = GrainClient.GrainFactory.GetGrain<ISerialNumberGrain>("测试流水号14");
            for (int i = 0; i <= 1000; i++)
            {
                var result = await grain1.GetMutilSerialNumber(i);
            }
            Console.WriteLine("队列一执行完毕:" + Thread.CurrentThread.ManagedThreadId);
        }

        public async static void Test2()
        {
            var grain2 = GrainClient.GrainFactory.GetGrain<ISerialNumberGrain>("测试流水号15");
            for (int i = 0; i <= 1000; i++)
            {
                var goodsList = await grain2.GetMutilSerialNumber(i);
            }
            Console.WriteLine("队列二执行完毕:" + Thread.CurrentThread.ManagedThreadId);
        }

        public async static void Test3()
        {
            var grain3 = GrainClient.GrainFactory.GetGrain<ISerialNumberGrain>("测试流水号16");
            for (int i = 0; i <= 1000; i++)
            {
                var goodsList = await grain3.GetMutilSerialNumber(i);
            }
            Console.WriteLine("队列二执行完毕:" + Thread.CurrentThread.ManagedThreadId);
        }

    }
}
