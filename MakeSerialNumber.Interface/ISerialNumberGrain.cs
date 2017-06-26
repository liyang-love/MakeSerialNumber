using MakeSerialNumber.Session;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSerialNumber.Interface
{
    public interface ISerialNumberGrain : IGrainWithStringKey
    {
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<List<long>> GetMutilSerialNumber(int number);


        /// <summary>
        /// 获取一个流水号
        /// </summary>
        /// <returns></returns>
        Task<long> GetSerialNumber();
    }
}
