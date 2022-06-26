Imports System.Configuration
Imports System.Runtime.Caching
Imports System.Web.Configuration 
Imports System.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Title") = "Home Page"
        dim cache as MemoryCache = new MemoryCache("MemoryCache")

        GetConfigurationValues()

        Return View()
    End Function

    Private Sub GetConfigurationValues() 
        dim constConnectionString As String = "FirstConnectionString"
        Dim constAppSetting as String = "ClientValidationEnabled"

        dim conn = ConfigurationManager.ConnectionStrings("FirstConnectionString")
        dim conn2 = ConfigurationManager.ConnectionStrings("SecondConnectionString").ConnectionString
        dim conn3 = ConfigurationManager.ConnectionStrings(constConnectionString).ConnectionString

        dim webConn1 = WebConfigurationManager.ConnectionStrings("FirstConnectionString")
        dim webConn2 = WebConfigurationManager.ConnectionStrings("SecondConnectionString").ConnectionString
        dim webConn3 = WebConfigurationManager.ConnectionStrings(constConnectionString).ConnectionString

        dim appSetting = ConfigurationManager.AppSettings("ClientValidationEnabled")
        dim appSetting3 = WebConfigurationManager.AppSettings(constAppSetting)

    End Sub

End Class
