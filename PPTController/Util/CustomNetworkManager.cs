using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace PPTController.Util
{
    public class CustomNetworkManager
    {
        public static string GetAllIps()
        {
            var address = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                            i.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                .SelectMany(i => i.GetIPProperties().UnicastAddresses)
                .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.Address.ToString())
                .ToArray();

            return string.Join(",", address);
        }
    }
}