using System.Net.Sockets;
using BLSS.Core;

namespace BLSS.Networking
{
    internal static class TCP
    {
        static TcpClient tcpClient;
        public static NetworkStream stream;
        static int lastConnectionTime;
        const string ip = "127.0.0.1";
        const int port = 8727;

        public static void EnsureConnection()
        {
            if ((tcpClient == null || !tcpClient.Connected) && DateTime.Now.Second - lastConnectionTime > 4)
            {
                lastConnectionTime = DateTime.Now.Second;
                if (Connect())
                {
                    Debug.Log("Connected.");
                }
            }
        }

        static bool Connect()
        {
            try
            {
                Debug.Log($"Attempting to connect to: {ip}{port}");

                tcpClient ??= new(ip, port);

                stream = tcpClient.GetStream();
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                return false;
            }

            return true;
        }
    }
}