Imports System.Runtime.Serialization
Imports System.ServiceModel

Namespace WcfService2

    ' NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    <ServiceContract>
    Public Interface IService1

        <OperationContract>
        Function GetData(ByVal value As Integer) As String

        <OperationContract>
        Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

    ' TODO: Add your service operations here
    End Interface

    ' Use a data contract as illustrated in the sample below to add composite types to service operations.
    <DataContract>
    Public Class CompositeType

        Private boolValueField As Boolean = True

        Private stringValueField As String = "Hello "

        <DataMember>
        Public Property BoolValue As Boolean
            Get
                Return boolValueField
            End Get

            Set(ByVal value As Boolean)
                boolValueField = value
            End Set
        End Property

        <DataMember>
        Public Property StringValue As String
            Get
                Return stringValueField
            End Get

            Set(ByVal value As String)
                stringValueField = value
            End Set
        End Property
    End Class
End Namespace
