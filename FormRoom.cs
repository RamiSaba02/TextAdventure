/*
 * Inlämmingsuppgift -TextAdventure- i grupp 
 *Rami Saba & Oz Albayark
 *CMS21 - Programmering med C#
 *Nackademin
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextAdventure
{

    public partial class FormRoom : Form
    {

        public FormRoom()
        {
            InitializeComponent();
            goEast.Hide();
            goWest.Hide();
            goNorth.Hide();
            goSouth.Hide();
            textBoxInput.Hide();
            RoomCreator();
        }
        string playerName;
        private Player player;
        List<Room> Rooms = new List<Room>();
        Room room = new Room();


        public void RoomCreator()
        {
            room = new Room();
            Rooms.Add(room);

            room = new Room();
            room.DoorIsLocked = true;
            Rooms.Add(room);

            room = new Room();
            room.AddItemInRoom("knife");
            Rooms.Add(room);

            room = new Room();
            Rooms.Add(room);

            room = new Room();
            Rooms.Add(room);

            room = new Room();
            room.AddItemInRoom("hammer");
            room.DoorIsLocked = true;
            Rooms.Add(room);

            room = new Room();
            room.AddItemInRoom("bottle");
            Rooms.Add(room);
        }

 

        public void DisplayNextRoom()
        {
            int x = player.PositionX;
            int y = player.PositionY;

            switch (x, y)
            {
                case (0, 0):
                    {
                        HideAllPictures();
                        pbxRoom2.Show();
                        player.GetRoom(Rooms[0]);
                        break;
                    }
                case (1, 0):
                    {
                        HideAllPictures();
                        pbxRoom1.Show();
                        player.GetRoom(Rooms[1]);
                        break;
                    }
                case (2, 0):
                    {
                        HideAllPictures();
                        pbxRoom3.Show();
                        player.GetRoom(Rooms[2]);
                        break;
                    }
                case (1, 1):
                    {
                        HideAllPictures();
                        pbxRoom4.Show();
                        player.GetRoom(Rooms[3]);
                        break;
                    }
                case (1, 2):
                    {
                        HideAllPictures();
                        pbxRoom5.Show();
                        player.GetRoom(Rooms[4]);
                        break;
                    }
                case (2, 1):
                    {
                        HideAllPictures();
                        pbxRoom6.Show();
                        player.GetRoom(Rooms[5]);
                        break;
                    }
                case (2, 2):
                    {
                        HideAllPictures();
                        pbxRoom7.Show();
                        player.GetRoom(Rooms[6]);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void HideAllPictures()
        {
            pbxRoom1.Hide();
            pbxRoom2.Hide();
            pbxRoom3.Hide();
            pbxRoom4.Hide();
            pbxRoom5.Hide();
            pbxRoom6.Hide();
            pbxRoom7.Hide();
        }

        private void goNorth_Click(object sender, EventArgs e)
        {
            player.GoNorth();
            DisplayNextRoom();
        }

        private void goEast_Click(object sender, EventArgs e)
        {
            player.GoEast();
            DisplayNextRoom();

        }

        private void goWest_Click(object sender, EventArgs e)
        {
            player.GoWest();
            DisplayNextRoom();
        }

        private void goSouth_Click(object sender, EventArgs e)
        {
            player.GoSouth();
            DisplayNextRoom();

        }



        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxInput.Focus();
            if (e.KeyCode == Keys.Enter)
            {
                player.CheckPlayerInput(textBoxInput.Text);
                DisplayNextRoom();
                textBoxInput.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void btnSetName_Click(object sender, EventArgs e)
        {
            playerName = textboxName.Text;
            player = new Player(playerName);
            textboxName.Hide();
            btnSetName.Hide();
            DisplayNextRoom();

            goNorth.Show();
            goEast.Show();
            goSouth.Show();
            goWest.Show();
            textBoxInput.Show();
        }
    }
}