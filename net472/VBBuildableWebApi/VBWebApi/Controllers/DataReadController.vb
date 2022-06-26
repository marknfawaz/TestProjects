Imports System.Web.Http
Imports System.Web.Http.Odata

Namespace Controllers
    Public Class DataReadController
        Inherits ApiController
    
        <HttpGet>
        <Route("")>
        Public Function [Get]() As IHttpActionResult

            Return TryCast(Ok(), IHttpActionResult)

        End Function
    End Class


End NameSpace