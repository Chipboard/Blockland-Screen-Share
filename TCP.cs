using System.Net.Sockets;
using BLSS.Mathematics;

namespace BLSS
{
    internal class TCP
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

                    /*for (int x = 0; x < 100; x++)
                    {
                        for (int y = 0; y < 33; y++)
                        {
                            Commands.CreateBrick(new Vector3(x * 0.25f, 0, (y * 0.6f) + 0.3f));
                        }
                    }*/
                }
            }
        }

        static bool Connect()
        {
            try
            {
                Debug.Log($"Attempting to connect to: {ip}{port}");

                if (tcpClient == null)
                    tcpClient = new(ip, port);

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