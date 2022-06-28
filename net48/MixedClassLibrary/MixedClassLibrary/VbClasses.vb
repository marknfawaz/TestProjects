Imports System.ComponentModel.Design
Imports System.Composition
Imports System.Data.Entity
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports System.Reflection
Imports System
Imports System.IO, System.Collections
Imports Newtonsoft.Json
Imports System.Web
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Infrastructure
Imports Org.BouncyCastle.Security


Namespace VbConsoleApp1

    <System.Serializable()>
    Public Class Person
        Public Property Name As String
        Public Property Age As Integer
        Private Property Hobby As String

        Public Shared _next As String = Nothing

        Public Sub New(hobby As String)
            hobby = hobby
            Console.WriteLine("This is a constructor")
        End Sub

        Public Sub SetName(newName As String)
            Name = newName
        End Sub

        Public Function GetName() As String
            Console.WriteLine("Step in a function")
            Dim _next As String = ""
            Return Name
        End Function

        Public Async Function GetNameAsync() As Task(Of String)
            Await Task.Delay(1)
            Console.WriteLine(Me.Name)
            Return "Boo"
        End Function

        Public Async Function Grade() As Task
            Await GetNameAsync() : End Function

        Protected Overridable Sub OnConfiguring(optionsBuilder As String)

        End Sub

        Function OwinSecurityInfrastructure(create As AuthenticationTokenCreateContext, receive As AuthenticationTokenReceiveContext) As String
            Dim serializedTicket As String = create.SerializeTicket()
            create.SetToken("")
            receive.DeserializeTicket(serializedTicket)

            Dim helper As SecurityHelper = New SecurityHelper()
            helper.LookupChallenge("Authentication_Type", AuthenticationMode.Active)
            Return ""
        End Function

    End Class

    Class Book

    End Class

    <Serializable()>
    Public Module BasicModule
    End Module


    Public Class Student : Inherits Person

        Public Sub New()
            MyBase.New("Studying")
            Console.WriteLine(1)
        End Sub

        Public Property Gpa As Decimal

        Protected Overrides Sub OnConfiguring(optionsBuilder As String)

        End Sub


    End Class

    Public Interface IPerson
        Sub Jump()
        Function GetId() As Integer
    End Interface

    Public Class Customer
        Implements IPerson

        Public Sub Jump() Implements IPerson.Jump
            Throw New NotImplementedException()
        End Sub

        Public Function GetId() As Integer Implements IPerson.GetId
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace