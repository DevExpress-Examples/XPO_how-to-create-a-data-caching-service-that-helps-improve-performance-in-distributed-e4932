Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.Text

Namespace WcfService2
	' NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	<ServiceContract> _
	Public Interface IService1

		<OperationContract> _
		Function GetData(ByVal value As Integer) As String

		<OperationContract> _
		Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

		' TODO: Add your service operations here
	End Interface


	' Use a data contract as illustrated in the sample below to add composite types to service operations.
	<DataContract> _
	Public Class CompositeType
		Private boolValue_Renamed As Boolean = True
		Private stringValue_Renamed As String = "Hello "

		<DataMember> _
		Public Property BoolValue() As Boolean
			Get
				Return boolValue_Renamed
			End Get
			Set(ByVal value As Boolean)
				boolValue_Renamed = value
			End Set
		End Property

		<DataMember> _
		Public Property StringValue() As String
			Get
				Return stringValue_Renamed
			End Get
			Set(ByVal value As String)
				stringValue_Renamed = value
			End Set
		End Property
	End Class
End Namespace
