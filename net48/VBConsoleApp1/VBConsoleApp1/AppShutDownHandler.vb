Imports System.Web
Imports System.Web.Mvc

Public Class AppShutDownHandler
    Implements IHttpHandler

    Sub New(isReusable As Boolean)
        Me.IsReusable = isReusable
    End Sub

    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim response As String = GenerateResponse(context)
        context.Response.Write($"<h1 style='Color:blue; font-size:15px;'>Our website is under maintainace. {response}</h1>")
    End Sub

    Public ReadOnly Property IsReusable As Boolean Implements IHttpHandler.IsReusable

    Private Function GenerateResponse(context As HttpContext)
        Return "This is a test handler"
    End Function

End Class
