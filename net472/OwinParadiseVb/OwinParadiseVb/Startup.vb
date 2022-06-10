Imports Owin
Imports Microsoft.Owin
Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks

Namespace PortingParadise
    ' Note: By default all requests go through this OWIN pipeline. Alternatively you can turn this off by adding an appSetting owin:AutomaticAppStartup with value “false”. 
    ' With this turned off you can still have OWIN apps listening on specific routes by adding routes in global.asax file Imports MapOwinPath or MapOwinRoute extensions on RouteTable.Routes
    public class Startup
        
        ' Invoked once at startup to configure your application.
        public Sub Configuration(app As IAppBuilder)
            app.Run(AddressOf Invoke)
        End Sub


        ' Invoked once per request.
        public Function Invoke(context As IOwinContext) As Task
            context.Response.ContentType = "text/plain"
            return context.Response.WriteAsync("Hello World")
        End Function

    End class
    
End Namespace

    
    
    