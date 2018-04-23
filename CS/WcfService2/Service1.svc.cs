using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;


namespace WcfService1 {

    public class Service1 : CachedDataStoreService {

        public static ICachedDataStore MainDataStore;

        static Service1() {
            string connectionString = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB");
            MSSqlConnectionProvider dataStore = (MSSqlConnectionProvider)XpoDefault.GetConnectionProvider(
                        connectionString,
                        AutoCreateOption.DatabaseAndSchema
                        );

            IDisposable[] objectsToDispose;
            MainDataStore = (ICachedDataStore)MSSql2005SqlDependencyCacheRoot.CreateSqlDependencyCacheRoot(
                       dataStore,
                       new DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer"),
                       out objectsToDispose
                       );
        }

        public Service1() : base(MainDataStore) { }

    }

}
