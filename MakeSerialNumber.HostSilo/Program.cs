using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime.Host;
using System.Data.Entity;
using MakeSerialNumber.Session;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;

namespace MakeSerialNumber.HostSilo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBContext())
            {
                Database.SetInitializer<DBContext>(null);
                var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
                db.Database.Log = Console.WriteLine;
                db.Database.Initialize(false);
            }

            using (var host = new SiloHost("Default"))
            {
                //host.ConfigFileName = "OrleansConfiguration.xml";
                host.LoadOrleansConfig();
                host.InitializeOrleansSilo();
                host.StartOrleansSilo();
                #region 正式环境
   
                #endregion
                Console.WriteLine("启动成功");
                Console.Read();
            }
        }
    }
}
