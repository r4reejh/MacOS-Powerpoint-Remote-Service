using System;
using AppKit;
using Foundation;
using PPTController.Util;
using QRCoder;

namespace PPTController
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
            PPTEntry.updateUi += DataHandler;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            var networkIp = CustomNetworkManager.GetAllIps();
            qrImage.Image = new NSImage(QrGenerator.GenerateQR(networkIp));
        }
        
        partial void createLabel(NSObject sender)
        {
            labelInfo.StringValue = "Your Phone is Paired, you may now use the app";
            qrImage.Image = null;
        }

        private void DataHandler(object sender, DataEventArgs args)
        {
            NSApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                labelInfo.StringValue = args.data;
                qrImage.Image = args.qrImage;
            });
        }
    }
}