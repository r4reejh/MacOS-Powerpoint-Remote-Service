using System;
using AppKit;
using PPTController.Util;

namespace PPTController
{
    static class PPTEntry
    {
        internal static bool isConnected;
        public static EventHandler<DataEventArgs> updateUi;

        static void Main(string[] args)
        {
            PPTServer.Start();
            Console.WriteLine("Started");
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}