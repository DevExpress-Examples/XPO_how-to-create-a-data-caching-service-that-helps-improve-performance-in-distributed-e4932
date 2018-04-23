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
			Dim dataStore As IDataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema)
			Dim dataCacheRoot As New DataCacheRoot(dataStore)
			dataCacheRoot.Configure(New DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer"))
			MainDataStore = dataCacheRoot
		End Sub

		Public Sub New()
			MyBase.New(MainDataStore)
		End Sub

	End Class

End Namespace
