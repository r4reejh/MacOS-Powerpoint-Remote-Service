using AppKit;
using Foundation;
using QRCoder;

namespace PPTController.Util
{
    public class QrGenerator
    {
        public static NSImage cacheQR;
        public static NSData GenerateQR(string data)
        {
            QRCodeGenerator _generator = new QRCodeGenerator();
            QRCodeData _data = _generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.L);
            PngByteQRCode _qr = new PngByteQRCode(_data);
            byte[] imgArr = _qr.GetGraphic(20);
            cacheQR = new NSImage(NSData.FromArray(imgArr));
            return NSData.FromArray(imgArr);
        }
    }
}