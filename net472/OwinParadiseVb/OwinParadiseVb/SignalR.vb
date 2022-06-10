Imports Microsoft.Owin.Hosting
Imports Owin

Namespace PortingParadise
    Public Class SignalR
        public class Startup
            public Sub Configuration(app As IAppBuilder)
                app.MapSignalR()
            End Sub

            public Sub Main(args  As String())
                Dim uri As String = "http://localhost:9999/"
                Using (WebApp.Start(Of Startup)(uri))
                    Console.WriteLine("Started")
                    Process.Start(uri + "signalr/negotiate")
                    Console.ReadKey()
                End Using
            End Sub
        End Class
    End Class
End Namespace