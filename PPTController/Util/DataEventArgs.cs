using System;
using AppKit;
using Foundation;

namespace PPTController.Util
{
    public class DataEventArgs : EventArgs
    {
        public string data { get; }
        public NSImage qrImage;

        public DataEventArgs(string _data, NSImage _qrImage)
        {
            data = _data;
            qrImage = _qrImage;
        }
    }
}