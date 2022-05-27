Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace VBConsoleApp
    Class TestClass
        Implements ITest
        Public Function SayHello(ByVal hi As String) As String Implements ITest.SayHello

            Return "Saying hello to " & hi
        End Function

    End Class
End Namespace