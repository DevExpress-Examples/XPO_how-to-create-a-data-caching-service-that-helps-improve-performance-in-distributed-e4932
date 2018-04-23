using DevExpress.Xpo;

using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;


namespace WcfService1 {

    public class Service1 : CachedDataStoreService {

        public static ICachedDataStore MainDataStore;

        static Service1() {
            string connectionString = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB");
            IDataStore dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);
            DataCacheRoot dataCacheRoot = new DataCacheRoot(dataStore);
            dataCacheRoot.Configure(new DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer"));
            MainDataStore = dataCacheRoot;
        }

        public Service1() : base(MainDataStore) { }

    }

}
