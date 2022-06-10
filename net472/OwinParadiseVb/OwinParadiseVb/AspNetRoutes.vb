Imports System.Threading.Tasks
Imports Microsoft.Owin
Imports Owin
Imports Microsoft.Owin.Infrastructure
Imports Microsoft.Owin.Logging
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.DataProtection
Imports System.Security.Claims

Namespace AspNetRoutes
    Public Class AspNetRoutes
        Public Sub Configuration(app As IAppBuilder)
            app.Run(AddressOf Invoke)
        End Sub

        Public Function Invoke(context As IOwinContext) As Task
            Dim cookies As ResponseCookieCollection = context.Response.Cookies
            cookies.Append("OwinCookieKey", "OwinCookieValue")

            Dim uriValue as Uri
            Uri.TryCreate("C:\\Users", UriKind.Absolute, uriValue)
            Dim path As PathString = PathString.FromUriComponent(uriValue)
            Dim check As Boolean = path.Equals(new PathString("//C://Users"))

            context.Response.ContentType = "text/plain"
            return context.Response.WriteAsync("Hello World " + check)

        End Function

        Public Function InvokeRequest(context As IOwinContext) As Task
            Dim cookies As RequestCookieCollection  = context.Request.Cookies
            Dim owinCookieValue As String = cookies("OwinCookieKey")

            Dim stringquery As IReadableStringCollection = context.Request.Query
            Dim owinquery As String = stringquery("owin")

            context.Response.ContentType = "text/plain"
            return context.Response.WriteAsync("Hello World 2")
        
        End Function
        
        Public Async Function SignUpUser(authenticationManager as IAuthenticationManager, df As ISecureDataFormat(Of AuthenticationTicket), at As AuthenticationTicket) As Task(Of Boolean)

            Dim claims As New List(Of ClaimsIdentity)({ New ClaimsIdentity() })
            dim authProp As New AuthenticationProperties()
            dim authResult = await authenticationManager.AuthenticateAsync("")
            authenticationManager.Challenge(New String({""}))
            authResult = await authenticationManager.AuthenticateAsync(New String({"", ""}))
            authenticationManager.Challenge(authProp, new String({""}))
            authenticationManager.SignOut(authProp, new String({""}))

            Dim prot as String = df.Protect(at)
            Dim unProtectedAt As AuthenticationTicket = df.Unprotect(prot)
            Return at.Equals(unProtectedAt)

        End Function

        Public Sub Protector(protector As IDataProtectionProvider)
            Dim purposes As New String({ "", "" })
            Dim prot1 As IDataProtector  = protector.Create(purposes)
        End Sub

        Public Sub UtilitiesLogger(logger As ILogger , app As IAppBuilder)
            WebUtilities.AddQueryString("uri", new Dictionary(Of string, string)())
            WebUtilities.AddQueryString("uri", "name", "value")
            logger.WriteInformation("message")
        End Sub

    End Class
End Namespace
