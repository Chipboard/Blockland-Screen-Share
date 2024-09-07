using BLSS;
using System.Text;
using BLSS.Mathematics;

namespace BLSS
{
    internal class Commands
    {
        public static void Eval(string code) => EncodeAndSend(code);

        public static void CreateBrick(Vector3 pos, string dataBlock = "brick1x1Data", int colorID = 0, int colorFXID = 0, int shapeFXID = 0, int angleID = 0, int BLID = 888888)
        {
            string rotation;
            switch (angleID)
            {
                case 0:
                    rotation = "1 0 0 0";
                    break;

                case 1:
                    rotation = "0 0 1 90";
                    break;

                case 2:
                    rotation = "0 0 1 180";
                    break;

                case 3:
                    rotation = "0 0 -1 90";
                    break;

                default:
                    rotation = "0 0 0 0";
                    break;
            }

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

            Eval(command);
        }

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
