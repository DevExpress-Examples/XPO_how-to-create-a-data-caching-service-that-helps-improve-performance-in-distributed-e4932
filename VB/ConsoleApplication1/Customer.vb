Imports System
Imports DevExpress.Xpo


Namespace ConsoleApplication1

	Public Class Customer
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _CompanyName As String
		Public Property CompanyName() As String
			Get
				Return _CompanyName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CompanyName", _CompanyName, value)
			End Set
		End Property
		Private _CompanyAddress As String
		Public Property CompanyAddress() As String
			Get
				Return _CompanyAddress
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CompanyAddress", _CompanyAddress, value)
			End Set
		End Property
		Private _ContactName As String
		Public Property ContactName() As String
			Get
				Return _ContactName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("ContactName", _ContactName, value)
			End Set
		End Property
		Private _Country As String
		Public Property Country() As String
			Get
				Return _Country
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Country", _Country, value)
			End Set
		End Property
		Private _Phone As String
		Public Property Phone() As String
			Get
				Return _Phone
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Phone", _Phone, value)
			End Set
		End Property
	End Class

End Namespace
