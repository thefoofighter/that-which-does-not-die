using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Twdnd -> That, which does not die
namespace Twdnd
{
    class Program
    {
        public static bool quit = false;

        static void Main(string[] args)
        {
            GameManager.showTitleScreen();
            Level.Initialize();
            GameManager.StartGame();

            while (!quit)
            {
                CommandProcessor.ProcessCommand(Console.ReadLine());
            }
        }
    }
}
