using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twdnd
{
    static class GameManager
    {
        // Public Methods
        public static void showTitleScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextUtils.WordWrap("**** The Hyperion Project ****\n\n\n",Console.WindowWidth));

            Console.WriteLine("\nNote: You may type 'help' at any point to see a list of useable commands");
            Console.WriteLine("\nPress a key to begin.");

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();

        }

        //StartGame()
        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }
        //EndGame()
        public static void EndGame(string endingText)
        {
            Program.quit = true;

            Console.Clear();
            Console.WriteLine(TextUtils.WordWrap(endingText,Console.WindowWidth));
            Console.WriteLine("\nYou may now close this Window");
            Console.CursorVisible = false;

            while (true)
                Console.ReadKey(true);
        }

        //ApplyRules()
        public static void applyRules()
        {
            if (Level.Rooms[0,0].GetItem("Red Ball") != null &&
                Level.Rooms[1,0].GetItem("Blue Ball") != null &&
                Level.Rooms[1,1].GetItem("Yellow Ball") != null &&
                Level.Rooms[0,1].GetItem("Green Ball") != null)
            {
                EndGame("Good Job! Youve placed all the ball's in the right rooms");
            }
            if (Player.GetInventoryItem("Key") != null)
            {
                Level.Rooms[0, 0].AddExits(Direction.South);// red room
                Level.Rooms[0, 0].Description = "You have entered the red room";

                Level.Rooms[0, 1].AddExits(Direction.North);// green room
                Level.Rooms[0, 1].Description = "You have entered the green room";
            }

            if (Player.Moves > 10)
            {
                EndGame("you died, you took too many moves to complete the game");
            }
        }
    }
}
