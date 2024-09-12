using System.Text;
using BLSS.Mathematics;
using BLSS.Networking;

namespace BLSS.Core
{
    internal static class Commands
    {
        public static void CreateBrick(Vectors pos, string dataBlock = "brick1x1Data", int colorID = 0, int colorFXID = 0, int shapeFXID = 0, int angleID = 0, int BLID = 888888)
        {
            string rotation = angleID switch
            {
                0 => "1 0 0 0",
                1 => "0 0 1 90",
                2 => "0 0 1 180",
                3 => "0 0 -1 90",
                _ => "0 0 0 0",
            };

            string command =
                "%brick = new fxDtsBrick(){ " +
                $"colorFxID = {colorFXID}; " +
                $"colorID = {colorID}; " +
                $"datablock = \"{dataBlock}\"; " +
                $"isPlanted = 1; " +
                $"position = \"{pos}\"; " +
                $"rotation = \"{rotation}\"; " +
                $"shapeFxID = {shapeFXID}; " +
                $"stackBL_ID = {BLID}; " +
                $"angleID = {angleID}; " +
                "}; " +
                "%brick.plant(); %brick.setTrusted(1); missionCleanup.add(%brick); mainBrickGroup.add(%brick);";

            EncodeAndSend(command);
        }

        public static void Eval(string code) => EncodeAndSend(code);

        static void EncodeAndSend(string code)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(code + "\r\n");
                TCP.stream.Write(data);
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
        }
    }
}
