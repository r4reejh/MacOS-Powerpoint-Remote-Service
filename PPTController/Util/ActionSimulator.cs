using System;
using AppKit;
using CoreGraphics;

namespace PPTController.Util
{
    public class ActionSimulator
    {
        public static void Simulate(KeySimulations combo)
        {
            switch (combo)
            {
                case KeySimulations.Left:
                    KeyPress(NSKey.LeftArrow);
                    break;
                case KeySimulations.Right:
                    KeyPress(NSKey.RightArrow);
                    break;
                case KeySimulations.StartSlideshow:
                    KeyPress(NSKey.F5);
                    break;
                case KeySimulations.EndSlideShow :
                    KeyPress(NSKey.Escape);
                    break;
            }
        }

        public static void KeyPress(NSKey key)
        {
            KeyDown(key);
            KeyUp(key);
        }

        public static void KeyDown(NSKey _key)
        {
            using (var eventSource = new CGEventSource(CGEventSourceStateID.HidSystem))
            {
                var key = (ushort)_key;
                using (var keyEvent = new CGEvent(eventSource, key, true))
                {
                    CGEvent.Post(keyEvent, CGEventTapLocation.HID);
                }
            }
        }
        
        public static void KeyUp(NSKey _key)
        {
            using (var eventSource = new CGEventSource(CGEventSourceStateID.HidSystem))
            {
                var key = (ushort)_key;
                using (var keyEvent = new CGEvent(eventSource, key, false))
                {
                    CGEvent.Post(keyEvent, CGEventTapLocation.HID);
                }
            }
        }
    }
}