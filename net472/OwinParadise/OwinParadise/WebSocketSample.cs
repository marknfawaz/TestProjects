using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortingParadise
{
    // http://owin.org/extensions/owin-WebSocket-Extension-v0.4.0.htm
    using WebSocketAccept = Action<IDictionary<string, object>, // options
        Func<IDictionary<string, object>, Task>>; // callback
    using WebSocketCloseAsync =
        Func<int /* closeStatus */,
            string /* closeDescription */,
            CancellationToken /* cancel */,
            Task>;
    using WebSocketReceiveAsync =
        Func<ArraySegment<byte> /* data */,
            CancellationToken /* cancel */,
            Task<Tuple<int /* messageType */,
                bool /* endOfMessage */,
                int /* count */>>>;
    using WebSocketSendAsync =
        Func<ArraySegment<byte> /* data */,
            int /* messageType */,
            bool /* endOfMessage */,
            CancellationToken /* cancel */,
            Task>;
    using WebSocketReceiveResult = Tuple<int, // type
        bool, // end of message?
        int>; // count
    class WebSocketSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                RunSample().Wait();
                Console.WriteLine("Finished");
                Console.ReadKey();
            }

            public static async Task RunSample()
            {
                ClientWebSocket websocket = new ClientWebSocket();

                string url = "ws://localhost:5000/";
                Console.WriteLine("Connecting to: " + url);
                await websocket.ConnectAsync(new Uri(url), CancellationToken.None);

                string message = "Hello World";
                Console.WriteLine("Sending message: " + message);
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                await websocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                byte[] incomingData = new byte[1024];
                System.Net.WebSockets.WebSocketReceiveResult result = await websocket.ReceiveAsync(new ArraySegment<byte>(incomingData), CancellationToken.None);

                if (result.CloseStatus.HasValue)
                {
                    Console.WriteLine("Closed; Status: " + result.CloseStatus + ", " + result.CloseStatusDescription);
                }
                else
                {
                    Console.WriteLine("Received message: " + Encoding.UTF8.GetString(incomingData, 0, result.Count));
                }
            }
        }

        static void Main(string[] args)
        {
            //using (WebApp.Start<Startup>("http://localhost:5000/"))
            //{
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            //}
        }

    /// <summary>
    /// This sample requires Windows 8, .NET 4.5, and Microsoft.Owin.Host.HttpListener.
    /// </summary>
    public class Startup
    {
        // Run at startup
        public void Configuration(IAppBuilder app)
        {
            app.Use(UpgradeToWebSockets);
            app.UseWelcomePage();
        }

        // Run once per request
        private Task UpgradeToWebSockets(IOwinContext context, Func<Task> next)
        {
            WebSocketAccept accept = null; //context.Get<WebSocketAccept>("websocket.Accept");
            if (accept == null)
            {
                // Not a websocket request
                return next();
            }

            accept(null, WebSocketEcho);

            return Task.FromResult<object>(null);
        }

        private async Task WebSocketEcho(IDictionary<string, object> websocketContext)
        {
            var sendAsync = (WebSocketSendAsync)websocketContext["websocket.SendAsync"];
            var receiveAsync = (WebSocketReceiveAsync)websocketContext["websocket.ReceiveAsync"];
            var closeAsync = (WebSocketCloseAsync)websocketContext["websocket.CloseAsync"];
            var callCancelled = (CancellationToken)websocketContext["websocket.CallCancelled"];

            byte[] buffer = new byte[1024];
            WebSocketReceiveResult received = await receiveAsync(new ArraySegment<byte>(buffer), callCancelled);

            object status;
            while (!websocketContext.TryGetValue("websocket.ClientCloseStatus", out status) || (int)status == 0)
            {
                // Echo anything we receive
                await sendAsync(new ArraySegment<byte>(buffer, 0, received.Item3), received.Item1, received.Item2, callCancelled);

                received = await receiveAsync(new ArraySegment<byte>(buffer), callCancelled);
            }

            await closeAsync((int)websocketContext["websocket.ClientCloseStatus"], (string)websocketContext["websocket.ClientCloseDescription"], callCancelled);
        }
    }
}
}
