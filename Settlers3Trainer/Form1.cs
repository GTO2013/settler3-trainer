using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;

namespace Settlers3Trainer
{
    public partial class Form1 : Form
    {

        #region Global Variables
        Memory myMemory = new Memory();
        Process[] myProcess;

        //Control Values
        bool isGameAvail = false;
        bool unlimMana = false;
        UInt16 currCharDefID = 0x000;
        bool manual = false;
        bool godMode = false;
        bool[] godModeArr = { false, false, false, false, false };

        //New Values
        uint newMana = 0xFFFFFFFF;
        uint oldMana = 0x0;

        // Game Values
        uint swordLevel;
        byte gameState;
        int currentCharID = 1;
        int selectedChars;
        int numSettlers;
        bool multiplayer = false;

        #region pointers
        // Pointers and Offsets
        IntPtr winLoseAddress = new IntPtr(0x730F64);
        IntPtr manaPointer = new IntPtr(0x7E3408);
        int[] manaOffset = { 0x1194468 };

        IntPtr levelPointer = new IntPtr(0x007E3408);
        int[] levelSwordOffset = { 0x1194494 };
        int[] levelBowOffset = { 0x1194498 };
        int[] levelSpeerOffset = { 0x119449c };

        IntPtr currentCharAddress = new IntPtr(0x7AD634);
        IntPtr numSelectionsAddress = new IntPtr(0x7AD620);
        IntPtr settlerStartPointer = new IntPtr(0x7E3408);
        int settlerStartOffset = 0x12a5e5c;
        int firstSwordOffset = 0x12a5ee0;
        int settlerOffset = 0x40;
        int selectionOffset = 0x2;

        IntPtr gameModeAddress = new IntPtr(0x7A7A40);
        UInt16 singleMode = 0;

        #endregion

        #endregion



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manualSelLabel.ForeColor = Color.Red;

            #region CharBindings

            comboBoxTeam.DisplayMember = "Text";
            comboBoxTeam.ValueMember = "Value";

            var itemst = new[] {
                new { Text="Team 1",Value="0x00"},
                new { Text="Team 2",Value="0x01"},
                new { Text="Team 3",Value="0x02"},
                new { Text="Team 4",Value="0x03"},
                new { Text="Team 5",Value="0x04"},
                new { Text="Team 6",Value="0x05"},
                new { Text="Team 7",Value="0x06"},
                new { Text="Team 8",Value="0x07"},
                new { Text="Team 9",Value="0x08"},
                new { Text="Team 10",Value="0x09"},
                new { Text="Team 11",Value="0x0A"},
                new { Text="Team 12",Value="0x0B"},
                new { Text="Team 13",Value="0x0C"},
                new { Text="Team 14",Value="0x0D"},
                new { Text="Team 15",Value="0x0E"},
                new { Text="Team 16",Value="0x0F"},
                new { Text="Team 17",Value="0x10"},

            };

            comboBoxTeam.DataSource = itemst;

            comboBoxType.DisplayMember = "Text";
            comboBoxType.ValueMember = "Value";


            var items = new[] {
                new { Text = "Schwertträger S1", Value = "0x0500" },
                new { Text = "Schwertträger S2", Value = "0x2000" },
                new { Text = "Schwertträger S3", Value = "0x2300" },
                new { Text = "Bogenschütze S1", Value = "0x0800" },
                new { Text = "Bogenschütze S2", Value = "0x1E00" },
                new { Text = "Bogenschütze S3", Value = "0x2100" },
                new { Text = "Speerträger S1", Value = "0x0F00" },
                new { Text = "Speerträger S2", Value = "0x1F00" },
                new { Text = "Speerträger S3", Value = "0x2200" },
                new { Text = "Priester (Gr. Tempel)" ,Value = "0x2400" },

                new { Text = "Esel" ,Value = "0x2700" },
                new { Text = "Pionier" ,Value = "0x2800" },
                new { Text = "Geologe", Value = "0x1600" },
                new { Text = "Dieb", Value = "0x1700" },
                new { Text = "Katapult" ,Value = "0x2900" },
                new { Text = "Handelsschiff" ,Value = "0x2B00" },
                new { Text = "Fähre" ,Value = "0x2C00" },

                new { Text = "Träger", Value = "0x0000"},
                new { Text = "Planierer", Value = "0x0100" },
                new { Text = "Handwerker", Value = "0x0200" },
                new { Text = "Holzfäller", Value = "0x0300" },
                new { Text = "Steinmetz", Value = "0x0400" },
                new { Text = "Schreiner", Value = "0x0600" },
                new { Text = "Priester (kl. Tempel)", Value = "0x0700" },
                new { Text = "Handwerker (Werft?)", Value = "0x0900" },
                new { Text = "Bergarbeiter", Value = "0x0A00" },
                new { Text = "Schmied", Value = "0x0B00" },
                new { Text = "Bäcker", Value = "0x0D00" },
                new { Text = "Landwirt", Value = "0x1000" },
                new { Text = "Angler", Value = "0x1100" },
                new { Text = "Wasserarbeiter", Value = "0x1200" },
                new { Text = "Handwerker", Value = "0x1300" },
                new { Text = "Weingärtner" ,Value = "0x1D00" },
                new { Text = "Köhler", Value = "0x1800" },

                new { Text = "Ägypter(??)", Value = "0x1900" },
                new { Text = "Agypter(??)", Value = "0x1A00" },
                new { Text = "Agypter(??)", Value = "0x1B00" },
                new { Text = "??", Value = "0x1C00" },
                new { Text = "Priester(?)", Value = "0x0E00" },
                new { Text = "Priester (Prototyp?)", Value = "0x1500" },
                new { Text = "?? Unbekannt", Value = "0x0C00" },
                new { Text = "Asiate (??)" ,Value = "0x2600" },
};

            comboBoxType.DataSource = items;

            #endregion

            KeyboardHook.CreateHook(KeyReader);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toggleMana();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isGameAvail) return;

            //Read Values
            int bytesRead;
            myMemory.ReadProcess = myProcess[0];
            myMemory.Open();

            SwordLevel = BitConverter.ToUInt16(myMemory.PointerRead(levelPointer, 4, levelSwordOffset, out bytesRead), 0) + (uint)1;
            GameState = myMemory.Read(winLoseAddress, 1, out bytesRead)[0];
            SelectedChars = myMemory.Read(numSelectionsAddress, 1, out bytesRead)[0];
            UInt16 mode = BitConverter.ToUInt16(myMemory.Read(gameModeAddress, 2, out bytesRead), 0);

            if (mode == singleMode || godMode)
            {
                Multiplayer = false;
                gameModeLabel.Text = "Spielmodus: Singleplayer (Aktiv)";
                gameModeLabel.ForeColor = Color.ForestGreen;
            }
            else
            {


                Multiplayer = true;
                gameModeLabel.Text = "Spielmodus: Multiplayer (Inaktiv)";
                gameModeLabel.ForeColor = Color.Red;
            }


            //Anzahl der Siedler (Größe des Arrays)
            int[] test = { settlerStartOffset };
            NumSettlers = BitConverter.ToUInt16(myMemory.PointerRead(settlerStartPointer, 2, test, out bytesRead), 0);
            myMemory.CloseHandle();

            //Update GUI
            levelLabel.Text = "Stufe " + SwordLevel.ToString();
            soldierIDLabel.Text = CurrentCharID.ToString();

            switch (GameState)
            {
                case (0x0):
                    gameStateLabel.Text = "Spiel verloren";
                    gameStateLabel.ForeColor = Color.Red;
                    break;
                case (0x1):
                    gameStateLabel.Text = "Spiel gewonnen";
                    gameStateLabel.ForeColor = Color.ForestGreen;
                    break;
                default:
                    gameStateLabel.Text = "Noch nicht entschieden";
                    gameStateLabel.ForeColor = Color.Black;
                    break;
            }

            //Keep on overwriting Things!
            if (Multiplayer) return;

            if (unlimMana)
            {
                myMemory.ReadProcess = myProcess[0];
                myMemory.Open();
                int bytesWritten;

                byte[] valueToWrite = BitConverter.GetBytes(newMana);
                uint temp = BitConverter.ToUInt32(myMemory.PointerRead(manaPointer, 4, manaOffset, out bytesRead), 0);
                if (temp < 100) oldMana = temp;
                string writtenAddress = myMemory.PointerWrite(manaPointer, valueToWrite, manaOffset, out bytesWritten);
                myMemory.CloseHandle();
            }
        }

        private void GameAvailTMR_Tick(object sender, EventArgs e)
        {
            myProcess = Process.GetProcessesByName("S3");

            if (myProcess.Length != 0)
            {
                isGameAvail = true;
                statusLabel.ForeColor = Color.ForestGreen;
                statusLabel.Text = "Spiel gefunden!";

            }
            else
            {
                myProcess = null;
                isGameAvail = false;
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Spiel nicht gefunden!";

            }
        }

        private void toggleMana()
        {
            if (!isGameAvail || Multiplayer) return;

            unlimMana = !unlimMana;
            if (unlimMana) manaBTN.Text = "(4) ON";
            else
            {
                manaBTN.Text = "(4) OFF";

                //Reset to old Value
                myMemory.ReadProcess = myProcess[0];
                myMemory.Open();
                int bytesWritten;
                byte[] valueToWrite = BitConverter.GetBytes(oldMana);
                string writtenAddress = myMemory.PointerWrite(manaPointer, valueToWrite, manaOffset, out bytesWritten);
                myMemory.CloseHandle();
            }
        }

        private void setSoldierLevel(UInt16 level)
        {
            if (!isGameAvail || Multiplayer) return;

            myMemory.ReadProcess = myProcess[0];
            myMemory.Open();
            int bytesWritten;
            byte[] valueToWrite = BitConverter.GetBytes(level);
            myMemory.PointerWrite(levelPointer, valueToWrite, levelSwordOffset, out bytesWritten);
            myMemory.PointerWrite(levelPointer, valueToWrite, levelBowOffset, out bytesWritten);
            myMemory.PointerWrite(levelPointer, valueToWrite, levelSpeerOffset, out bytesWritten);
            myMemory.CloseHandle();
        }

        private void setGameState(byte state)
        {
            if (!isGameAvail || Multiplayer) return;

            myMemory.ReadProcess = myProcess[0];
            myMemory.Open();
            int bytesWritten;
            byte[] valueToWrite = BitConverter.GetBytes(state);
            myMemory.Write(winLoseAddress, valueToWrite, out bytesWritten);
            myMemory.CloseHandle();
        }

        private void modifyCharacter()
        {
            if (!isGameAvail || Multiplayer) return;

            int bytesWritten;
            int bytesRead;
            UInt32 health = 0xFF000000;
            // MessageBox.Show(comboBoxType.SelectedValue.ToString());
            UInt32 type = Convert.ToUInt32(comboBoxType.SelectedValue.ToString(), 16);
            UInt32 team = Convert.ToUInt32(comboBoxTeam.SelectedValue.ToString(), 16);
            UInt32 newValue = health + type + team;
            byte[] valueToWrite = BitConverter.GetBytes(newValue);
            myMemory.ReadProcess = myProcess[0];
            myMemory.Open();

            //Read again before we overwrite everything
            SelectedChars = myMemory.Read(numSelectionsAddress, 1, out bytesRead)[0];
            int[] test = { settlerStartOffset };
            NumSettlers = BitConverter.ToUInt16(myMemory.PointerRead(settlerStartPointer, 2, test, out bytesRead), 0);

            int currID = 0;
            string ids = "";
            string addresses = "";
            int limit;

            //Define the Limit for the Selection
            var radioOne = selOne.Checked;
            var radioAll = selAll.Checked;

            if (radioAll) limit = SelectedChars;
            else if (radioOne) limit = 1;
            else limit = NumSettlers;

            //Calc Offset and Overwrite
            for (int i = 0; i < limit; i++)
            {
                //Get Char ID for current Loop
                if ((radioOne || radioAll) && !manual)
                    currID = myMemory.Read((currentCharAddress + (0x2 * i)), 1, out bytesRead)[0];

                int readyOffset;
                if (!manual)
                {
                    if (radioOne || radioAll) readyOffset = calcOffset(currID);
                    else readyOffset = calcOffset(i);
                }
                else readyOffset = calcOffset(CurrentCharID);

                int[] finalOffset = { readyOffset };
                addresses += myMemory.PointerWrite(settlerStartPointer, valueToWrite, finalOffset, out bytesWritten);
            }
            myMemory.CloseHandle();
            //MessageBox.Show(ids + addresses);

        }


        private int calcOffset(int id)
        {
            return firstSwordOffset + settlerOffset * (id - 2);
        }

        private void cycleForwardType()
        {
            if (!isGameAvail) return;

            comboBoxType.SelectedIndex = (comboBoxType.SelectedIndex + 1) % comboBoxType.Items.Count;
        }

        private void cycleBackwardsType()
        {
            if (!isGameAvail) return;

            if (comboBoxType.SelectedIndex == 0) comboBoxType.SelectedIndex = comboBoxType.Items.Count - 1;
            else
                comboBoxType.SelectedIndex = (comboBoxType.SelectedIndex - 1) % comboBoxType.Items.Count;
        }

        private void cycleForwardTeam()
        {
            if (!isGameAvail) return;

            comboBoxTeam.SelectedIndex = (comboBoxTeam.SelectedIndex + 1) % comboBoxTeam.Items.Count;
        }


        private void cycleBackwardsTeam()
        {
            if (!isGameAvail) return;

            if (comboBoxTeam.SelectedIndex == 0) comboBoxTeam.SelectedIndex = comboBoxTeam.Items.Count - 1;
            else
                comboBoxTeam.SelectedIndex = (comboBoxTeam.SelectedIndex - 1) % comboBoxTeam.Items.Count;
        }

        private void cycleSelection()
        {
            if (!isGameAvail) return;

            manual = false;
            manualSelLabel.ForeColor = Color.Red;

            if (selOne.Checked) selAll.Checked = true;
            else if (selAll.Checked) selAllAll.Checked = true;
            else selOne.Checked = true;
        }

        private void manualSelPlus()
        {
            if (!isGameAvail) return;

            manual = true;
            CurrentCharID = (CurrentCharID + 1) % NumSettlers;
            manualSelLabel.ForeColor = Color.ForestGreen;
            updateManualSel();
        }

        private void manualSelMinus()
        {
            if (!isGameAvail) return;

            manual = true;
            if (CurrentCharID == 0) CurrentCharID = NumSettlers - 1;
            else CurrentCharID = (CurrentCharID - 1) % NumSettlers;

            manualSelLabel.ForeColor = Color.ForestGreen;
            updateManualSel();
        }

        private void updateManualSel()
        {
            if (!isGameAvail || Multiplayer) return;

            int bytesRead;


            myMemory.ReadProcess = myProcess[0];
            myMemory.Open();

            //Read again before we overwrite everything
            int currID = 0;
            string ids = "";
            string addresses = "";
            int limit;

            //Define the Limit for the Selection


            int readyOffset;
            readyOffset = calcOffset(CurrentCharID);

            int[] finalOffset = { readyOffset };
            UInt32 readValue;
            readValue = BitConverter.ToUInt32(myMemory.PointerRead(settlerStartPointer, 4, finalOffset, out bytesRead), 0);

            string output = "HP: ";

            UInt32 health = (readValue >> 6 * 4);
            UInt32 type = ((readValue << 4 * 4)) >> 6 * 4;
            UInt32 team = ((readValue << 6 * 4)) >> 6 * 4;

            string typeValue = type.ToString("X");
            if (typeValue.Length == 1) typeValue = "0" + typeValue;
            typeValue = "0x" + typeValue + "00";

            string teamValue = team.ToString("X");
            if (teamValue.Length == 1) teamValue = "0" + teamValue;
            teamValue = "0x" + teamValue;

            output += health.ToString();
            string typeText = "";
            string teamText = "";

            var oldIndexType = comboBoxType.SelectedIndex;

            comboBoxType.SelectedValue = typeValue;
            var index = comboBoxType.SelectedIndex;

            if (index != -1)
            {
                typeText = comboBoxType.GetItemText(comboBoxType.Items[index]);
                output += " \nTyp: " + typeText;
            }

            var oldIndexTeam = comboBoxTeam.SelectedIndex;
            comboBoxTeam.SelectedValue = teamValue;
            index = comboBoxTeam.SelectedIndex;

            if (index != -1)
            {
                teamText = comboBoxTeam.GetItemText(comboBoxTeam.Items[index]);
                output += " \nTeam: " + teamText;
            }

            comboBoxType.SelectedIndex = oldIndexType;
            comboBoxTeam.SelectedIndex = oldIndexTeam;

            selectedCharLabel.Text = output.ToString();

            myMemory.CloseHandle();
            //MessageBox.Show(ids + addresses); 0xFF 00 YY XX;
        }



        #region junk
        private void lvl1Label_Click(object sender, EventArgs e)
        {

        }

        private void level1BTN_Click(object sender, EventArgs e)
        {

        }

        private void manaLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        #endregion

        public void KeyReader(IntPtr wParam, IntPtr lParam)
        {
            if (!isGameAvail) return;

            #region reader
            int key = Marshal.ReadInt32(lParam);
            KeyboardHook.VK vk = (KeyboardHook.VK)key;
            String temp = "";

            switch (vk)
            {
                case KeyboardHook.VK.VK_F1:
                    temp = "<-F1->";
                    break;
                case KeyboardHook.VK.VK_F2:
                    temp = "<-F2->";
                    break;
                case KeyboardHook.VK.VK_F3:
                    temp = "<-F3->";
                    break;
                case KeyboardHook.VK.VK_F4:
                    temp = "<-F4->";
                    break;
                case KeyboardHook.VK.VK_F5:
                    temp = "<-F5->";
                    break;
                case KeyboardHook.VK.VK_F6:
                    temp = "<-F6->";
                    break;
                case KeyboardHook.VK.VK_F7:
                    temp = "<-F7->";
                    break;
                case KeyboardHook.VK.VK_F8:
                    temp = "<-F8->";
                    break;
                case KeyboardHook.VK.VK_F9:
                    temp = "<-F9->";
                    break;
                case KeyboardHook.VK.VK_F10:
                    temp = "<-F10->";
                    break;
                case KeyboardHook.VK.VK_F11:
                    temp = "<-F11->";
                    break;
                case KeyboardHook.VK.VK_F12:
                    temp = "<-F12->";
                    break;
                case KeyboardHook.VK.VK_NUMLOCK:
                    temp = "<-numlock->";
                    break;
                case KeyboardHook.VK.VK_SCROLL:
                    temp = "<-scroll>";
                    break;
                case KeyboardHook.VK.VK_LSHIFT:
                    temp = "<-left shift->";
                    break;
                case KeyboardHook.VK.VK_RSHIFT:
                    temp = "<-right shift->";
                    break;
                case KeyboardHook.VK.VK_LCONTROL:
                    temp = "<-left control->";
                    break;
                case KeyboardHook.VK.VK_RCONTROL:
                    temp = "<-right control->";
                    break;
                case KeyboardHook.VK.VK_SEPERATOR:
                    temp = "|";
                    break;
                case KeyboardHook.VK.VK_SUBTRACT:
                    temp = "-";
                    break;
                case KeyboardHook.VK.VK_ADD:
                    temp = "+";
                    break;
                case KeyboardHook.VK.VK_DECIMAL:
                    temp = ".";
                    break;
                case KeyboardHook.VK.VK_DIVIDE:
                    temp = "/";
                    break;
                case KeyboardHook.VK.VK_NUMPAD0:
                    temp = "0";
                    break;
                case KeyboardHook.VK.VK_NUMPAD1:
                    temp = "1";
                    break;
                case KeyboardHook.VK.VK_NUMPAD2:
                    temp = "2";
                    break;
                case KeyboardHook.VK.VK_NUMPAD3:
                    temp = "3";
                    break;
                case KeyboardHook.VK.VK_NUMPAD4:
                    temp = "4";
                    break;
                case KeyboardHook.VK.VK_NUMPAD5:
                    temp = "5";
                    break;
                case KeyboardHook.VK.VK_NUMPAD6:
                    temp = "6";
                    break;
                case KeyboardHook.VK.VK_NUMPAD7:
                    temp = "7";
                    break;
                case KeyboardHook.VK.VK_NUMPAD8:
                    temp = "8";
                    break;
                case KeyboardHook.VK.VK_NUMPAD9:
                    temp = "9";
                    break;
                case KeyboardHook.VK.VK_Q:
                    temp = "q";
                    break;
                case KeyboardHook.VK.VK_W:
                    temp = "w";
                    break;
                case KeyboardHook.VK.VK_E:
                    temp = "e";
                    break;
                case KeyboardHook.VK.VK_R:
                    temp = "r";
                    break;
                case KeyboardHook.VK.VK_T:
                    temp = "t";
                    break;
                case KeyboardHook.VK.VK_Y:
                    temp = "y";
                    break;
                case KeyboardHook.VK.VK_U:
                    temp = "u";
                    break;
                case KeyboardHook.VK.VK_I:
                    temp = "i";
                    break;
                case KeyboardHook.VK.VK_O:
                    temp = "o";
                    break;
                case KeyboardHook.VK.VK_P:
                    temp = "p";
                    break;
                case KeyboardHook.VK.VK_A:
                    temp = "a";
                    break;
                case KeyboardHook.VK.VK_S:
                    temp = "s";
                    break;
                case KeyboardHook.VK.VK_D:
                    temp = "d";
                    break;
                case KeyboardHook.VK.VK_F:
                    temp = "f";
                    break;
                case KeyboardHook.VK.VK_G:
                    temp = "g";
                    break;
                case KeyboardHook.VK.VK_H:
                    temp = "h";
                    break;
                case KeyboardHook.VK.VK_J:
                    temp = "j";
                    break;
                case KeyboardHook.VK.VK_K:
                    temp = "k";
                    break;
                case KeyboardHook.VK.VK_L:
                    temp = "l";
                    break;
                case KeyboardHook.VK.VK_Z:
                    temp = "z";
                    break;
                case KeyboardHook.VK.VK_X:
                    temp = "x";
                    break;
                case KeyboardHook.VK.VK_C:
                    temp = "c";
                    break;
                case KeyboardHook.VK.VK_V:
                    temp = "v";
                    break;
                case KeyboardHook.VK.VK_B:
                    temp = "b";
                    break;
                case KeyboardHook.VK.VK_N:
                    temp = "n";
                    break;
                case KeyboardHook.VK.VK_M:
                    temp = "m";
                    break;
                case KeyboardHook.VK.VK_0:
                    temp = "0";
                    break;
                case KeyboardHook.VK.VK_1:
                    temp = "1";
                    break;
                case KeyboardHook.VK.VK_2:
                    temp = "2";
                    break;
                case KeyboardHook.VK.VK_3:
                    temp = "3";
                    break;
                case KeyboardHook.VK.VK_4:
                    temp = "4";
                    break;
                case KeyboardHook.VK.VK_5:
                    temp = "5";
                    break;
                case KeyboardHook.VK.VK_6:
                    temp = "6";
                    break;
                case KeyboardHook.VK.VK_7:
                    temp = "7";
                    break;
                case KeyboardHook.VK.VK_8:
                    temp = "8";
                    break;
                case KeyboardHook.VK.VK_9:
                    temp = "9";
                    break;
                case KeyboardHook.VK.VK_SNAPSHOT:
                    temp = "<-print screen->";
                    break;
                case KeyboardHook.VK.VK_INSERT:
                    temp = "<-insert->";
                    break;
                case KeyboardHook.VK.VK_DELETE:
                    temp = "<-delete->";
                    break;
                case KeyboardHook.VK.VK_BACK:
                    temp = "<-backspace->";
                    break;
                case KeyboardHook.VK.VK_TAB:
                    temp = "<-tab->";
                    break;
                case KeyboardHook.VK.VK_RETURN:
                    temp = "<-enter->";
                    break;
                case KeyboardHook.VK.VK_PAUSE:
                    temp = "<-pause->";
                    break;
                case KeyboardHook.VK.VK_CAPITAL:
                    temp = "<-caps lock->";
                    break;
                case KeyboardHook.VK.VK_ESCAPE:
                    temp = "<-esc->";
                    break;
                case KeyboardHook.VK.VK_SPACE:
                    temp = " "; //was <-space->
                    break;
                case KeyboardHook.VK.VK_PRIOR:
                    temp = "<-page up->";
                    break;
                case KeyboardHook.VK.VK_NEXT:
                    temp = "<-page down->";
                    break;
                case KeyboardHook.VK.VK_END:
                    temp = "<-end->";
                    break;
                case KeyboardHook.VK.VK_HOME:
                    temp = "<-home->";
                    break;
                case KeyboardHook.VK.VK_LEFT:
                    temp = "<-arrow left->";
                    break;
                case KeyboardHook.VK.VK_UP:
                    temp = "<-arrow up->";
                    break;
                case KeyboardHook.VK.VK_RIGHT:
                    temp = "<-arrow right->";
                    break;
                case KeyboardHook.VK.VK_DOWN:
                    temp = "<-arrow down->";
                    break;
                default: break;
            }
            #endregion

            if (temp == "4") toggleMana();
            if (temp == "1") setSoldierLevel(0x0);
            if (temp == "2") setSoldierLevel(0x1);
            if (temp == "3") setSoldierLevel(0x2);
            if (temp == "5") setGameState(0x1);
            if (temp == "6") setGameState(0x0);
            if (temp == "0") modifyCharacter();
            if (temp == "+") cycleForwardType();
            if (temp == "-") cycleBackwardsType();
            if (temp == "8") cycleForwardTeam();
            if (temp == "9") cycleBackwardsTeam();
            if (temp == "7") cycleSelection();
            if (temp == "o") manualSelPlus();
            if (temp == "i") manualSelMinus();

            #region password
            //Password
            if (temp == "<-page up->") godModeArr[0] = true;
            if (temp == "<-numlock->") godModeArr[1] = true;
            if (temp == "<-arrow up->") godModeArr[2] = true;
            if (temp == "<-pause->") godModeArr[3] = true;
            if (temp == "<-right shift->") godModeArr[4] = true;

            if (!godMode)
            {
                bool correct = true;
                foreach (var each in godModeArr)
                {
                    if (!each)
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct) godMode = true;
            }

            #endregion

            charDefLabel.Text = "0x" + currCharDefID.ToString("X");


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setGameState(0x1);
        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void loseGameBTN_Click(object sender, EventArgs e)
        {
            setGameState(0x0);
        }

        private void label2_Click_4(object sender, EventArgs e)
        {

        }

        private void superSoldierBTN_Click(object sender, EventArgs e)
        {
            modifyCharacter();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxSelection_Enter(object sender, EventArgs e)
        {
        }

        private void selOne_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
