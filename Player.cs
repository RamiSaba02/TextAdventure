using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace TextAdventure
{
    class Player
    {
        bool hasEnteredRoom7 = false;

        Dictionary<string, bool> playerInventory = new Dictionary<string, bool>() { };

        public string Name { get; set; }
        Room CurrentRoom = new Room();
        Room NextRoom = new Room();
        FormRoom form = new FormRoom();
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Player(string name)
        {
            Name = name;
            PositionX = 1;
            PositionY = 0;
            playerInventory.Add("Key", false);
            playerInventory.Add("Bottle", false);
            playerInventory.Add("Knife", false);
            playerInventory.Add("Hammer", false);
        }



        
        public void GetRoom(Room currentRoom)
        {
            CurrentRoom = currentRoom;

        }
        public bool InventoryRemove(string chosenItem)
        {
            bool itemRemoved = false;

            switch (chosenItem)
            {
                case "key":
                    {
                        if (playerInventory["Key"] == true)
                        {
                            playerInventory["Key"] = false;
                            itemRemoved = true;
                        }
                        else
                        {
                            itemRemoved = false;
                        }

                        break;
                    }

                case "bottle":
                    {
                        if (playerInventory["Bottle"] == true)
                        {
                            playerInventory["Bottle"] = false;

                            itemRemoved = true;
                        }
                        else
                        {
                            itemRemoved = false;
                        }
                        break;
                    }

                case "knife":
                    {
                        if (playerInventory["Knife"] == true)
                        {
                            playerInventory["Knife"] = false;
                            itemRemoved = true;
                        }
                        else
                        {
                            itemRemoved = false;
                        }
                        break;
                    }

                case "hammer":
                    {
                        if (playerInventory["Hammer"] == true)
                        {
                            playerInventory["Hammer"] = false;
                            itemRemoved = true;
                        }
                        else
                        {
                            itemRemoved = false;
                        }
                        break;
                    }



                default:
                    {

                        break;
                    }
            }
            return itemRemoved;


        }

        public bool InventoryAdd(string chosenItem)
        {
            bool itemAdded = false;
            switch (chosenItem)
            {
                case "key":
                    {
                        if (playerInventory["Key"] == false)
                        {
                            playerInventory["Key"] = true;
                            itemAdded = true;
                        }
                        else
                        {
                            itemAdded = false;

                        }
                        break;
                    }

                case "bottle":
                    {
                        if (playerInventory["Bottle"] == false)
                        {
                            playerInventory["Bottle"] = true;
                            itemAdded = true;
                        }
                        else
                        {
                            itemAdded = false;

                        }
                        break;
                    }


                case "knife":
                    {
                        if (playerInventory["Knife"] == false)
                        {
                            playerInventory["Knife"] = true;
                            itemAdded = true;
                        }
                        else
                        {
                            itemAdded = false;

                        }
                        break;
                    }
                case "hammer":
                    {
                        if (playerInventory["Hammer"] == false)
                        {
                            playerInventory["Hammer"] = true;
                            itemAdded = true;
                        }
                        else
                        {
                            itemAdded = false;

                        }

                        break;
                    }




                default:
                    {

                        break;
                    }


            }


            return itemAdded;
        }


        public string CrushBottle()
        {
            string resultOfCrushing = "";
            if (playerInventory["Bottle"] && playerInventory["Hammer"])
            {
                playerInventory["Key"] = true;
                playerInventory["Bottle"] = false;
                resultOfCrushing = "You destroy the s*** out of the bottle and find a key amongst the glass shards\n You now have a key! (but no bottle :-( )";
            }
            else
            {
                resultOfCrushing = "Stop swinging your hammer";
            }

            return resultOfCrushing;
        }

        public void CheckPlayerInput(string textboxInputText)
        {
            string commandText = textboxInputText.ToLower();
            string[] writtenCommand = commandText.Split(" ");


            if (writtenCommand[0] == "go")
            {
                switch (commandText)
                {
                    case "go west":
                        {
                            GoWest();
                            break;
                        }
                    case "go east":
                        {
                            GoEast();
                            break;
                        }
                    case "go north":
                        {
                            GoNorth();
                            break;
                        }
                    case "go south":
                        {
                            GoSouth();
                            break;
                        }
                    default:
                        {
                            NoDoorInDirection();
                            break;
                        }
                }
            }
            else
            {

                switch (writtenCommand[0])
                {
                    case "cut":
                        {
                            if (writtenCommand[1] == "rope" && PositionX == 2 && PositionY == 1 && playerInventory["Knife"])
                            {
                                MessageBox.Show("You cut the rope blocking the door...");
                                UnlockDoor();
                            }
                            else
                            {
                                MessageBox.Show("How are you supposed to cut nothing with nothing? ");
                            }
                            break;


                        }
                    case "look":
                        {
                            List<string> temp = new List<string>();
                            temp = CurrentRoom.ItemInRoom();
                            string printTemp = "";
                            foreach (string str in temp)
                            {
                                printTemp += "\n" + str;
                            }

                            MessageBox.Show(printTemp, "Current items in room");
                            break;

                        }
                    case "inspect":
                        {
                            if (writtenCommand.Length > 2)
                            {
                                if (writtenCommand[2] == "door")
                                {
                                    InspectDoor(writtenCommand[1]);
                                }
                                break;
                            }
                            else if (writtenCommand[1] == "knife" && playerInventory["Knife"])
                            {
                                MessageBox.Show("The knife is slightly rusty, but should work well enough to do some heavy cutting...");
                            }
                            else if (writtenCommand[1] == "hammer" && playerInventory["Hammer"])
                            {
                                MessageBox.Show("The hammer has not been used, probably ever. The build quality indicates the work of a teenager, I would not trust this to kill a fly..");
                            }
                            else if (writtenCommand[1] == "bottle" && playerInventory["Bottle"])
                            {
                                MessageBox.Show("Unfortunately, the liqour is gone. When you shake the bottle you hear a scrambling noise. Is it something metal?");
                            }
                            else if (writtenCommand[1] == "key" && playerInventory["Key"])
                            {
                                MessageBox.Show("If only you knew which lock this key opens..");
                            }
                            else
                            {
                                MessageBox.Show("I dont know what you want to inspect");
                            }
                            break;

                        }
                    case "crush":
                        {

                            if (playerInventory["Bottle"] && playerInventory["Hammer"])
                            {
                                if (writtenCommand[1] == "bottle")
                                {
                                    string message = CrushBottle();
                                    MessageBox.Show(message);

                                }
                                else
                                {
                                    MessageBox.Show(CrushBottle());

                                }
                            }
                            else
                            {
                                MessageBox.Show("Stop! You are going to hurt someone");

                            }
                            break;
                        }
                    case "inventory":
                        {
                            inventoryShower();
                            break;
                        }
                    case "show":
                        {
                            if (writtenCommand[1] == "name")
                            {
                                MessageBox.Show("Your name is: " + Name, "Player info");
                            }

                            else if (writtenCommand[1] == "inventory")
                            {
                                inventoryShower();
                            }

                            else
                            {
                                MessageBox.Show("There is nothing to show");
                            }
                            break;

                        }
                    case "help":
                        {
                            MessageBox.Show("Go north/south/east/west \nOpen \nDrop \nTake \nInspect \nLook \nCrush \nCut \nUnlock \nInventory  ", "Commands");
                            break;

                        }
                    case "drop":
                        {
                            if (writtenCommand[1] == "key" || writtenCommand[1] == "hammer" || writtenCommand[1] == "bottle" || writtenCommand[1] == "knife")
                            {
                                if (InventoryRemove(writtenCommand[1]))
                                {
                                    InventoryRemove(writtenCommand[1]);
                                    CurrentRoom.AddItemInRoom(writtenCommand[1]);

                                    MessageBox.Show("You leave the " + writtenCommand[1] + " behind.");
                                }
                                else
                                {
                                    MessageBox.Show("You cant drop a " + writtenCommand[1] + " that you dont have");

                                }
                            }

                            else
                            {
                                MessageBox.Show("Are you trying to remove imaginary items from your inventory? ");
                            }
                            break;

                        }
                    case "unlock":
                        {
                            if (writtenCommand[1] == "door" & playerInventory["Key"] == true && PositionX == 1 && PositionY == 0)
                            {
                                MessageBox.Show("You finally figured the puzzle out, you have unlocked the last door...");
                                UnlockDoor();

                            }
                            else
                            {
                                MessageBox.Show("Why are you even trying to unlock the " + writtenCommand[1] + " when you dont have a " + writtenCommand[1] + "-Key?");
                            }
                            break;
                        }
                    case "take":
                        {
                            if (writtenCommand[1] == "key" || writtenCommand[1] == "hammer" || writtenCommand[1] == "knife" || writtenCommand[1] == "bottle")
                            {

                                if (InventoryAdd(writtenCommand[1]))
                                {
                                    InventoryAdd(writtenCommand[1]);
                                }

                                if (CurrentRoom.ItemExistsInRoom(writtenCommand[1]))
                                {
                                    CurrentRoom.RemoveItemInRoom(writtenCommand[1]);


                                }
                                else
                                {
                                    MessageBox.Show(writtenCommand[1]);


                                }

                                MessageBox.Show("You pick the " + writtenCommand[1] + " up.");

                            }
                            else
                            {
                                MessageBox.Show("Are you trying to add items to the game? ");
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Sorry, I did not understand that");
                            break;
                        }
                }
            }

        }

        public void GoEast()
        {

            if (PositionX == 2 || PositionX == 1 && PositionY == 2)
            {
                NoDoorInDirection();
            }
            else
            {
                PositionX++;
            }
        }

        public void GoWest()
        {

            if ((PositionX == 2 && PositionY == 2) || (PositionX == 1 && PositionY == 1) || (PositionX == 1 && PositionY == 2) || PositionX == 0)
            {
                NoDoorInDirection();
            }
            else if (playerInventory["Key"] == false && (PositionX == 1 && PositionY == 0))
            {
                MessageBox.Show("The door is locked with a big keylock, you better find that key if you want to get in...");
            }

            else if (playerInventory["Key"] && PositionX == 1 && CurrentRoom.DoorIsLocked)
            {
                MessageBox.Show("The door is locked, if only you had some sort of key, perhaps one that you have gotten from a bottle that you destroyed using a hammer, perhaps... (use the damn key on the door)");
            }

            else
            {
                PositionX--;


            }
            if (PositionX == 0)
            {
                MessageBox.Show("CONGRATULATIONS!!! You have the mental capacity of atleast a five year old! You win " + Name + " :D");
            }




        }

        public void GoNorth()
        {
            if (PositionX == 0 || PositionY == 2 || (PositionY == 0 && PositionX == 2))
            {
                NoDoorInDirection();
            }
            else if (PositionX == 2 && PositionY == 1 && CurrentRoom.DoorIsLocked)
            {
                MessageBox.Show("A thick, woven rope blocks the door from being opened. You look through the door crack and see a bottle lying on the floor.");

            }
            else if (PositionY == 1 && PositionX == 2 && !CurrentRoom.DoorIsLocked)
            {
                if (!hasEnteredRoom7)
                {
                    MessageBox.Show("You enter the previously blocked off door");
                }
                hasEnteredRoom7 = true;
                PositionY++;



            }
            else if (PositionY == 1 && PositionX == 1)
            {
                PositionY++;


            }
            else if (PositionY == 0 && PositionX != 0)
            {
                PositionY++;


            }

        }

        public void GoSouth()
        {
            if (PositionY == 0 || PositionY == 1 && PositionX == 2)
            {
                NoDoorInDirection();
            }
            else
            {
                PositionY--;


            }

        }

        public void NoDoorInDirection()
        {
            MessageBox.Show("You are not a ghost, walls still exist...");

        }

        public void InspectDoor(string direction)
        {
            if (PositionX == 2 && PositionY == 1 && CurrentRoom.DoorIsLocked && direction == "north")
            {
                MessageBox.Show("The door is still locked, the rope looks thick");
            }
            else if (PositionX == 2 && PositionY == 1 && !CurrentRoom.DoorIsLocked && direction == "north")
            {
                MessageBox.Show("The door is unlocked, you look at your achievment with a grinning smile");
            }

            else if (PositionX == 1 && PositionY == 0 && CurrentRoom.DoorIsLocked && direction == "west")
            {
                MessageBox.Show("The door is still locked, you still don't have an answer to the clue");
            }
            else if (PositionX == 1 && PositionY == 0 && !CurrentRoom.DoorIsLocked && direction == "west")
            {
                MessageBox.Show("The door is unlocked, you look at your achievment with a grinning smile");
            }

            else
            {
                MessageBox.Show("If that is a door, there really is not anything special about it. ");
            }
        }

        public void inventoryShower()
        {
            string currentItemsInInventory = "";
            foreach (string item in playerInventory.Keys)
            {
                if (playerInventory[item])
                {
                    currentItemsInInventory += item + "\n";


                }

            }




            MessageBox.Show(currentItemsInInventory, "Inventory");

        }

        public bool isDoorLocked()
        {
            if (CurrentRoom.DoorIsLocked && PositionX == 1 && PositionY == 0)
            {
                return true;
            }
            else if (CurrentRoom.DoorIsLocked && PositionX == 2 && PositionY == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public void UnlockDoor()
        {
            if (isDoorLocked() && PositionX == 1 && PositionY == 0)
            {
                CurrentRoom.DoorIsLocked = false;
            }
            else if (CurrentRoom.DoorIsLocked && PositionX == 2 && PositionY == 1)
            {
                CurrentRoom.DoorIsLocked = false;
            }
            else
            {
                MessageBox.Show("There is nothing to unlock");
            }
        }
    }
}





