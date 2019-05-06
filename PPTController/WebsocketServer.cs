using System;
using System.Net;
using PPTController.Util;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PPTController
{
    public class PPTServer
    {
        private const int DefaultPort = 2005;
        private static WebSocketServer _server;
        private static bool Running;
        public static void Start()
        {
            if (Running) return;
            _server = new WebSocketServer(IPAddress.Any, DefaultPort);
            _server.AddWebSocketService<PPTServlet>("/");
            _server.Start();
            Running = true;
        }
    }

    public class PPTServlet : WebSocketBehavior
    {
        private InputHandler module = new InputHandler();
        public PPTServlet()
        {
            module.SendStream += OnData;
            Console.WriteLine("connected");
        }
        
        private void OnData(object sender, DataEventArgs data)
        {
            Send(data.data);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
            InputHandler.Handle(module, e.Data);
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            Console.WriteLine("Connected");
        }

        protected override void OnClose(CloseEventArgs e)
        {
            PPTEntry.updateUi?.Invoke(module, new DataEventArgs("Scan to reconnect", QrGenerator.cacheQR));
            module = null;
            Console.WriteLine("Closed");
            base.OnClose(e);
        }
    }
}