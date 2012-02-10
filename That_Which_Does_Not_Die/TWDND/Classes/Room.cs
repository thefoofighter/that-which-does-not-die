using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twdnd
{
    class Room
    {
        private string title;
        private string description;
        private string speak;

        private List<string> exits;
        private List<Item> items;

        #region properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Speak
        {
            get { return speak; }
            set { speak = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        #endregion

        public Room()
        {
            exits = new List<string>();
            items = new List<Item>();
        }

        #region public Methods
        public void Describe()
        {
            ///////////////
            //Debug
            TextBuffer.Add("Debug_Coordinates : "+this.GetCoordinates()+"\n");
            //////////////
            TextBuffer.Add(this.GetRoomDescText());
            TextBuffer.Add(this.description);
            TextBuffer.Add(this.GetPlayerText());
            TextBuffer.Add(this.speak);
            TextBuffer.Add(this.GetItemList());
            TextBuffer.Add(this.GetExitList());           
        }

        public void ShowTitle()
        {
            TextBuffer.Add(this.title);          
        }

        public Item GetItem(string itemName)
        {
            foreach (Item item in this.items)
            {
                if (item.Title.ToLower() == itemName.ToLower()) 
                    return item;
            }
            return null;
        }

        public void AddExits(string direction)
        {
            if (this.exits.IndexOf(direction) == -1)
                this.exits.Add(direction);
        }

        public void RemoveExit(string direction)
        {
            if (this.exits.IndexOf(direction) != -1)
                this.exits.Remove(direction);
        }

        public bool CanExit(string direction)
        {
            foreach (string validExit in this.exits)
            {
                if (direction == validExit)
                    return true;
            }
            return false;
        }
        #endregion

        #region private methods
        private string GetRoomDescText()
        {
            string message = "Room Description:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');
            return message + "\n" + underline;
        }
        private string GetPlayerText()
        {
            string message = "Player Text:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');
            return "\n" + message + "\n" + underline;
        }
        private string GetItemList()
        {
            string itemString = "";
            string message = "Items in Room:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.items.Count > 0)
            {
                foreach (Item item in this.items)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
            {
                itemString = "\n<none>";
            }
            return "\n" + message + "\n" + underline + itemString;
        }

        private string GetExitList()
        {
            string exitString = "";
            string message = "Possible Directions:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection + "]";
                }
            }
            else
            {
                exitString = "\n<none>";
            }
            return "\n" + message + "\n" + underline + exitString;
        }

        private string GetCoordinates()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                        return "[" + x.ToString() + "," + y.ToString() + "]";
                }
            }
            return "This room is not within the rooms grid";
        }
        #endregion

    }
}
