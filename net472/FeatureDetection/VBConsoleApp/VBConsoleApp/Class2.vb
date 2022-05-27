Imports System
Imports System.Diagnostics

Namespace VBConsoleApp
    Public Class Class2
        Private ReadOnly _someInt As Integer
        Private ReadOnly _someStr As String
        Private ReadOnly _grade As Grade

        Public Sub New(ByVal someInt As Integer, ByVal someStr As String)
            _someInt = someInt
            _someStr = someStr
            _grade = Grade.A
        End Sub

        Public Sub TestMethod()
            FirstMethod().ChainedMethod()
        End Sub

        Private Function FirstMethod() As Class2
            Return New Class2(0, "")
        End Function

        Private Function ChainedMethod() As Class2
            Return New Class2(0, "")
        End Function

        <Conditional("DEBUG")>
        Public Shared Sub Message(ByVal msg As String)
            Console.WriteLine(msg)
        End Sub

        Public Class NestedClass
        End Class

        Public Enum Grade
            A
            B
            C
        End Enum
    End Class
End Namespace

