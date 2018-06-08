using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashPoker_V2
{
    class Program
    {
        private static int Player1Wins;
        private static int Player2Wins;
        private static int Draws;

        static void Main(string[] args)
        {
            

            for (int i = 0; i < 1000; i++)
            {
                Hand[] hands = PlayedHands.GetNextHands();

                int victor = CalculateVictor.GetVictor(hands);


                if(victor == 0)
                {
                    Draws++;
                    WriteToDisk.AddOutput(PlayedHands.currentHand, WinState.TIE);
                }
                else if(victor == 1)
                {
                    Player1Wins++;
                    WriteToDisk.AddOutput(PlayedHands.currentHand, WinState.PLAYER1);
                }
                else
                {
                    Player2Wins++;
                    WriteToDisk.AddOutput(PlayedHands.currentHand, WinState.PLAYER2);
                }

                Console.WriteLine(victor);
            }

            WriteToDisk.WriteRoundToDisk();

            Console.WriteLine(Player1Wins);
            Console.WriteLine(Player2Wins);
            Console.WriteLine(Draws);


            do
            {

            }
            while (Console.ReadLine() == "q");
        }
    }
}
