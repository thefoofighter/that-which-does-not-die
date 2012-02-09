using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twdnd
{
    static class CommandProcessor
    {

        public static void ProcessCommand(string line)
        {
            string command = TextUtils.ExtractCommand(line.Trim()).Trim().ToLower();
            string argument = TextUtils.ExtractArguments(line.Trim()).Trim().ToLower();

            if (Direction.IsValidDirection(command))
            {
                Player.Move(command);
            }
            else
            {
                switch (command)
                {
                    case "exit":
                        Program.quit = true;
                        break;
                    case "help":
                        ShowHelp();
                        break;
                    case "move":
                        Player.Move(argument);
                        break;
                    case "look":
                        Player.GetCurrentRoom().Describe();
                        break;
                    case "pickup":
                        Player.PickupItem(argument);
                        break;
                    case "drop":
                        Player.DropItem(argument);
                        break;
                    case "inventory":
                        Player.DisplayInventory();
                        break;
                    case "whereami":
                        Player.GetCurrentRoom().ShowTitle();
                        break;
                    default:
                        TextBuffer.Add("Input not understood");
                        break;
                }
            }
            GameManager.applyRules();
            TextBuffer.Display();
        }

        public static void ShowHelp()
        {
            TextBuffer.Add("Available Commands");
            TextBuffer.Add("------------------");
            TextBuffer.Add("help");
            TextBuffer.Add("exit");
            TextBuffer.Add("move [North,East,South,West]");
            TextBuffer.Add("look");
            TextBuffer.Add("pickup");
            TextBuffer.Add("drop");
            TextBuffer.Add("inventory");
            TextBuffer.Add("whereami");
        }
    }
}
