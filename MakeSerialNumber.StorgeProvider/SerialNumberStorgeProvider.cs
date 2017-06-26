using Orleans.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using MakeSerialNumber.Session;

namespace MakeSerialNumber.StorgeProvider
{

    public class SerialNumberStorgeProvider : IStorageProvider
    {
        public Logger Log { get; set; }

        public string Name { get; set; }

        public Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            return TaskDone.Done;
        }

        public Task Close()
        {
            return TaskDone.Done;
        }

        public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            this.Name = nameof(SerialNumberStorgeProvider);
            this.Log = providerRuntime.GetLogger(this.Name);

            return TaskDone.Done;
        }

        public Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            Console.WriteLine("获取种子信息");
            var SerialNumber = grainReference.GetPrimaryKeyString();
            using (var db = new DBContext())
            {
                var query = db.SerialNumbers.AsNoTracking().FirstOrDefault(o => o.Name.Equals(SerialNumber));
                if (query != null)
                    grainState.State = query;
                else
                {
                    db.SerialNumbers.Add(new SerialNumberInfo
                    {
                        Name = grainReference.GetPrimaryKeyString(),
                        Number = 1
                    });
                    db.SaveChanges();
                    grainState.State = new SerialNumberInfo
                    {
                        Name = grainReference.GetPrimaryKeyString(),
                        Number = 1
                    };
                }
            }
            return TaskDone.Done;
        }

        public async Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
        {
            var model = grainState.State as SerialNumberInfo;
            using (var db = new DBContext())
            {
                var query = db.SerialNumbers.FirstOrDefault(o => o.Name.Equals(model.Name));
                query.Number = model.Number;
                await db.SaveChangesAsync();
            }
        }
    }
}
