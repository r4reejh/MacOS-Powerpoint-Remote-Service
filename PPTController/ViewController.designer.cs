// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in the XCode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PPTController
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField labelInfo { get; set; }

		[Outlet]
		AppKit.NSButton mainButton { get; set; }

		[Outlet]
		AppKit.NSImageView qrImage { get; set; }

		[Action ("createLabel:")]
		partial void createLabel (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (labelInfo != null) {
				labelInfo.Dispose ();
				labelInfo = null;
			}

			if (qrImage != null) {
				qrImage.Dispose ();
				qrImage = null;
			}

			if (mainButton != null) {
				mainButton.Dispose ();
				mainButton = null;
			}

		}
	}
}
