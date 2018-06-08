using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashPoker_V2
{
    public enum WinState
    {
        PLAYER1,
        PLAYER2,
        TIE
    }

    public class WriteToDisk
    {
        public static string[] output = new string[1001];

        public static void WriteRoundToDisk()
        {
            System.IO.File.WriteAllLines(@"C:\Users\Game Developer\AppData\Local\PokerOpdracht\output.txt", output);
        }

        public static void AddOutput(int round, WinState state)
        {
            output[round] = "Round" + round + " " + state;
        }
    }

}
