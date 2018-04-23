Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.DB.Helpers


Namespace WcfService1
	Public Class Service1
		Inherits CachedDataStoreService
		Public Shared MainDataStore As ICachedDataStore
		Shared Sub New()
			Dim connectionString As String = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB")
			Dim dataStore As MSSqlConnectionProvider = CType(XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema), MSSqlConnectionProvider)
			Dim objectsToDispose() As IDisposable
			MainDataStore = CType(MSSql2005SqlDependencyCacheRoot.CreateSqlDependencyCacheRoot(dataStore, New DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer"), objectsToDispose), ICachedDataStore)
		End Sub
		Public Sub New()
			MyBase.New(MainDataStore)
		End Sub
	End Class
End Namespace
