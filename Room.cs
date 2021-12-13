using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class Room
    {
        public Room()
        {
        }
        List<string> Items = new List<string>();

        public string Name { get; set; }
        public List<string> ItemInRoom()
        {


            return Items;
        }
        public void AddItemInRoom(string itemToAdd)
        {
            Items.Add(itemToAdd);

        }
        public void RemoveItemInRoom(string itemToRemove)
        {

            Items.Remove(itemToRemove);
        }

        public bool ItemExistsInRoom(string itemToRemove)
        {
            bool Item = false;

            foreach (string str in Items)
            {

                if (str == itemToRemove)
                {
                    Item = true;
                }

            }
            return Item;
        }


        public bool DoorIsLocked { get; set; }

       
    }
}
