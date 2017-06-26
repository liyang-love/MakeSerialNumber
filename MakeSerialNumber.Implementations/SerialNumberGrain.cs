using MakeSerialNumber.Interface;
using MakeSerialNumber.Session;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSerialNumber.Implementations
{
    [StorageProvider(ProviderName = "SerialNumberStorgeProvider")]
    public class SerialNumberGrain : Grain<SerialNumberInfo>, ISerialNumberGrain
    {
        /// <summary>
        /// 获取多个流水号
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Task<List<long>> GetMutilSerialNumber(int number)
        {
            if (number == 0) { number = 1; }

            Console.WriteLine("获取流水号--" + this.State.Name + "    " + number + "个");
            List<long> list = new List<long>();
            for (int i = 1; i <= number; i++)
            {
                this.State.Number += 1;
                list.Add(this.State.Number);
            }
            this.WriteStateAsync();
            return Task.FromResult(list);
        }

        /// <summary>
        /// 获取单个流水号
        /// </summary>
        /// <returns></returns>
        public Task<long> GetSerialNumber()
        {

            Console.WriteLine("获取流水号--" + this.State.Name + "    1个");
            this.WriteStateAsync();
            return Task.FromResult(1L);
        }
    }
}
