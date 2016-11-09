using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.UpDown_Meter {
    static class NetworkInterfaces {
        public static IEnumerable<NetworkInterface> FetchAll() {
            return NetworkInterface.GetAllNetworkInterfaces();
        }

        public static IEnumerable<NetworkInterface> FetchOperational() {
            return FetchAll().Where(nic => nic.OperationalStatus == OperationalStatus.Up);
        }

        public static NetworkInterface Fetch(string id) {
            return FetchAll().Where(nic => nic.Id == id).FirstOrDefault();
        }
    }
}
