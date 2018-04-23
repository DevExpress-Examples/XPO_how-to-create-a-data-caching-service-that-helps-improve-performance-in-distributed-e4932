Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.Xpo.DB
Imports DevExpress.Data.Filtering


Namespace ConsoleApplication1

	Friend Class Program

		Shared Sub Main(ByVal args() As String)

			XpoDefault.DataLayer = XpoDefault.GetDataLayer("http://localhost:55777/Service1.svc", AutoCreateOption.DatabaseAndSchema)

			XpoDefault.Session = Nothing

			Using uow As New UnitOfWork()
				If uow.FindObject(GetType(Customer), New BinaryOperator("ContactName", "Alex Smith", BinaryOperatorType.Equal)) Is Nothing Then
				Dim custAlex As New Customer(uow)
				custAlex.ContactName = "Alex Smith"
				custAlex.CompanyName = "DevExpress"
				custAlex.Save()

				Dim Tom As New Customer(uow)
				Tom.ContactName = "Tom Jensen"
				Tom.CompanyName = "ExpressIT"
				Tom.Save()
				uow.CommitChanges()
				End If

				Using customers As New XPCollection(Of Customer)(uow)

					For Each customer As Customer In customers

						Console.WriteLine("Company Name = {0}; ContactName = {1}", customer.CompanyName, customer.ContactName)
					Next customer
				End Using
			End Using

			Console.WriteLine("Press any key...")
			Console.ReadKey()
		End Sub
	End Class
End Namespace
