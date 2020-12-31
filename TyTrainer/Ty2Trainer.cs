using System;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using Memory;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace TyTrainer
{
    public partial class Ty2Trainer : Form
    {
        public Mem memory = new Mem();
        bool processOpen = false; //tracks whether Ty2.exe is open or not
        readonly List<string> pointerTypes = new List<string>(); //stores the data type of each pointer
        readonly List<string> pointerNames = new List<string>(); //stores the name of each pointer
        readonly List<string> pointers = new List<string>(); //stores the address of each pointer
        readonly List<Panel> mainPanels = new List<Panel>(); //stores all of the Top-Level panels (PanelBunyip, PanelTy, etc.)
        readonly List<CheckBox> checkBoxes = new List<CheckBox>(); //stores all of the CheckBoxes
        readonly List<TextBox> textBoxes = new List<TextBox>(); //stores all of the TextBoxes
        readonly List<List<string>> musicTitles = new List<List<string>>(); //stores in-game music titles ordered by category
        string currentMusicTitle = ""; //tracks the currently playing music, used to know where in the game the player is

        //modes determine which UI Panel to display at each moment
        readonly string[] modes = { "Bunyip", "Cutscene", "Heli", "Kart", "Sub", "Other", "Ty", "Truck", "Unknown" };
        string mode;

        //stores pairs of Address Name -> Label Text for UI
        readonly SortedDictionary<string, string> labelLookup = new SortedDictionary<string, string>();

        //stores pairs of Music Title -> Music String for displaying for UI
        readonly Dictionary<string, string> musicStrings = new Dictionary<string, string>();

        //stores pairs of Character State -> UI Text
        readonly Dictionary<int, string> stateStrings = new Dictionary<int, string>();

        //logging related variables
        StreamWriter logWriter = null;
        bool verbose = true; //whether to detail everything or just important events
        bool loggedStartup = false; //whether the startup is done or not

        public Ty2Trainer()
        {
            Log("Initializing Components...", "SETUP", false);
            InitializeComponent();
            LabelLastAction.Text = "";
            foreach (Control control in this.Controls)
            {
                if (control.Name.Contains("MainPanel"))
                {
                    mainPanels.Add((Panel)control);
                    musicTitles.Add(new List<string>()); //same number of MainPanels as musicTitle lists
                }
            }
            ReadFiles();
            foreach (string name in pointerNames)
            {
                if (name == "CharacterState" || name == "CurrentMusicTitle")
                    continue;
                textBoxes.Add((TextBox)this.Controls.Find("Text" + name, true)[0]);
                checkBoxes.Add((CheckBox)this.Controls.Find("Check" + name, true)[0]);
            }
            Log("Trainer initialized.", "SETUP", false);
        }

        private void ReadFiles()
        {
            //pointers.txt contains each pointer's type, name, and address
            Log("Reading files...", "SETUP", false);
            Log("Reading pointers.txt.", "SETUP", true);
            string[] lines = GetLines("pointers.txt");
            foreach (string line in lines)
            {
                string[] split = line.Split(' ');
                pointerTypes.Add(split[0]);
                pointerNames.Add(split[1]);
                pointers.Add(split[2]);
            }

            //music_titles.txt contains lists of music titles in order of category
            Log("Reading music_titles.txt.", "SETUP", true);
            lines = GetLines("music_titles.txt");
            for (int i = 0; i < lines.Length; ++i)
            {
                string[] split = lines[i].Split(' ');
                foreach (string token in split)
                {
                    musicTitles[i].Add(token);
                }
            }

            //music_strings.txt contains list of what to display on the UI for each music title
            Log("Reading music_strings.txt.", "SETUP", true);
            lines = GetLines("music_strings.txt");
            foreach (string line in lines)
            {
                string[] split = line.Split(' ');
                musicStrings.Add(split[0], split[1].Replace('_', ' ')); //_ is placeholder for spaces in file
            }

            //labelLookup stores pairs of address name -> UI text
            Log("Reading UI_text.txt.", "SETUP", true);
            lines = GetLines("UI_text.txt");
            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                labelLookup.Add(pointerNames[i], line);
            }

            //stateStrings stores UI text for each character state
            Log("Reading state_strings.txt.", "SETUP", true);
            lines = GetLines("state_strings.txt");
            foreach(string line in lines)
            {
                string[] split = line.Split(' ');
                stateStrings.Add(int.Parse(split[0]), split[1].Replace('_', ' '));
            }
        }

        private string[] GetLines(string file)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(asm.GetManifestResourceStream("TyTrainer.Resources." + file));
            List<string> lines = new List<string>();
            while (!reader.EndOfStream)
                lines.Add(reader.ReadLine());
            return lines.ToArray();
        }

        private string GetPointer(string name)
        {
            return pointers[pointerNames.IndexOf(name)]; //returns pointer address given a pointer name
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                processOpen = memory.OpenProcess("Ty2");
                if (!processOpen)
                {
                    loggedStartup = false;
                    Log("Ty2.exe is not open. Waiting 5 seconds and trying again.", "WARNING", false);
                    worker.ReportProgress(0);
                    mode = "Closed";
                    if (LabelCurrentArea.Text != "Current Area: Game Closed!")
                        LabelCurrentArea.Invoke(new Action(() => LabelCurrentArea.Text = "Current Area: Game Closed!"));
                    UpdateUI(mainPanels.Find(panel => panel.Name == "MainPanel" + mode));
                    Thread.Sleep(5000);
                    continue;
                }
                else if(processOpen && !loggedStartup)
                {
                    Log("Ty2.exe opened.", "GAME", false);
                    loggedStartup = true;
                }

                bool modeUpdated = GetMode(); //update mode to determine what UI should be shown
                UpdateArea(); //update area name text
                UpdateState(); //update character state text

                //if necessary, update UI
                if (modeUpdated)
                    UpdateUI(mainPanels.Find(panel => panel.Name == "MainPanel" + mode));

                //if necessary, update label texts
                if(mode != "Cutscene" && mode != "Other" && mode != "Unknown")
                    UpdateLabels(mainPanels.Find(panel => panel.Parent.Controls.GetChildIndex(panel) == 0));

                worker.ReportProgress(0); //report progress to update closed/open status
                Thread.Sleep(25); //sleep for 25ms
            }
        }

        private bool GetMode()
        {
            string oldMusic = currentMusicTitle;
            string oldMode = mode; //store current mode to determine if mode was changed
            if(memory.ReadString(GetPointer("CurrentMusicTitle")) != "missionsucceed")
                currentMusicTitle = memory.ReadString(GetPointer("CurrentMusicTitle")).ToLower(); //grab current music title
            bool found = false; //tracks if current music title has been found in an array or not

            for (int i = 0; i < musicTitles.Count; ++i)
            {
                if(musicTitles[i].IndexOf(currentMusicTitle) != -1)
                {
                    if(i == 8) //TyBunyip case
                        mode = memory.ReadInt(GetPointer("CharacterState")) == 0 ? "Ty" : "Bunyip";
                    else if(i == 9) //TyTruck case
                        mode = memory.ReadInt(GetPointer("CharacterState")) == 0 ? "Ty" : "Truck";
                    else
                        mode = modes[i];
                    found = true;
                    break;
                }
            }

            if (!found)
                mode = "Unknown"; //if not otherwise found, assume Unknown

            if(oldMode != mode)
                Log("Mode changed from " + oldMode + " to " + mode + ".", "GAME", true);

            if (oldMusic != currentMusicTitle && oldMusic != "" && currentMusicTitle != "")
                Log("Music changed from " + musicStrings[oldMusic] + " to " + musicStrings[currentMusicTitle] + ".", "GAME", true);

            return oldMode != mode; //true if mode has been changed
        }

        private void UpdateArea()
        {
            string text;
            if (musicStrings.ContainsKey(currentMusicTitle))
                text = musicStrings[currentMusicTitle];
            else
                text = "Unknown";

            if(LabelCurrentArea.Text != "Current Area: " + text)
                LabelCurrentArea.Invoke(new Action(() => LabelCurrentArea.Text = "Current Area: " + text));
        }

        private void UpdateState()
        {
            string state = stateStrings[memory.ReadInt(GetPointer("CharacterState"))];
            string currentState = LabelCharacterState.Text.Substring(17);
            string text = "Character State: " + state;
            if(LabelCharacterState.Text != text)
            {
                Log("Character State changed from " + currentState + " to " + state + ".", "GAME", true);
                LabelCharacterState.Invoke(new Action(() => LabelCharacterState.Text = text));
            }
        }

        private void UpdateUI(Panel panel)
        {
            //remove text/undo checks before switching, to avoid issues
            Panel inFront = mainPanels.Find(front => front.Parent.Controls.GetChildIndex(front) == 0);
            foreach(CheckBox check in checkBoxes.FindAll(chk => chk.Name.Contains(inFront.Name.Substring(9))))
            {
                if (check.Checked)
                {
                    string name = pointerNames[pointers.IndexOf(GetPointer(check.Name.Substring(5)))];
                    Log("Unfreezing " + name + ".", "FREEZE", false);
                    check.Invoke(new Action(() => check.Checked = false));
                    memory.UnfreezeValue(GetPointer(check.Name.Substring(5)));
                }
            }
            foreach (TextBox text in textBoxes.FindAll(txt => txt.Name.Contains(inFront.Name.Substring(9))))
                text.Invoke(new Action(() => text.Text = ""));
            Log("Bringing " + panel.Name + " to front.", "UI", false);
            panel.Invoke(new Action(() => panel.BringToFront())); //bring current mode's panel to front
            if (LabelLastAction.Text != "")
                LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = ""));
        }

        private void UpdateLabels(Panel panel)
        {
            //convert currentPanel's name and find its respective Label Panel
            Panel labels = (Panel)panel.Controls.Find(panel.Name.Substring(4) + "Label", false)[0];
            
            foreach (Label label in labels.Controls)
            {
                List<string> keys = new List<string>(labelLookup.Keys);
                foreach (string key in keys)
                {
                    if ("Label" + key == label.Name)
                    {
                        string valueType = pointerTypes[keys.FindIndex(findKey => findKey == key)];
                        if (valueType == "float")
                        {
                            float value = memory.ReadFloat(GetPointer(key));
                            label.Invoke(new Action(() => label.Text = labelLookup[key] + value));
                            break;
                        }
                        else if (valueType == "uint")
                        {
                            uint value = memory.ReadUInt(GetPointer(key));
                            label.Invoke(new Action(() => label.Text = labelLookup[key] + value));
                            break;
                        }
                        else if(valueType == "int")
                        {
                            int value = memory.ReadInt(GetPointer(key));
                            label.Invoke(new Action(() => label.Text = labelLookup[key] + value));
                            break;
                        }
                    }
                }
            }
        }

        private void ToggleFreeze(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string pointerName = checkBox.Name.Substring(5);
            if (checkBox.Checked)
            {
                TextBox textBox = textBoxes.Find(text => text.Name == "Text" + pointerName);
                string type = pointerTypes[pointerNames.IndexOf(pointerName)];
                string value = textBox.Text;
                if (value == "")
                {
                    if (type == "float")
                        value = memory.ReadFloat(GetPointer(pointerName)).ToString();
                    else if (type == "int")
                        value = memory.ReadInt(GetPointer(pointerName)).ToString();
                    else if (type == "uint")
                        value = memory.ReadUInt(GetPointer(pointerName)).ToString();
                    Log("Empty text box - freezing current value (" + value + ") to " + pointerName + ".", "FREEZE", false);
                    memory.FreezeValue(GetPointer(pointerName), type, value);
                    LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Froze " + value + " to " + pointerName + "."));
                }
                else
                {
                    bool success = true;
                    if (type == "int" && !int.TryParse(textBox.Text, out int outInt))
                        success = false;
                    else if (type == "float" && !float.TryParse(textBox.Text, out float outFloat))
                        success = false;

                    if (success)
                    {
                        Log("Freezing value " + value + " to " + pointerName + ".", "FREEZE", false);
                        memory.FreezeValue(GetPointer(pointerName), type, textBox.Text);
                        LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Froze " + value + " to " + pointerName + "."));
                    }
                    else
                    {
                        Log("Error freezing value " + value + " to " + pointerName + " - wrong type!", "WARNING", false);
                        LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Can't freeze " + value + " to " + pointerName + " - wrong type!"));
                        checkBox.Invoke(new Action(() => checkBox.Checked = false));
                    }
                }
            }
            else
            {
                Log("Unfreezing " + pointerName, "FREEZE", false);
                memory.UnfreezeValue(GetPointer(pointerName));
                LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Unfroze " + pointerName + "."));
            }
        }

        private void SetValue(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name.Substring(6);
            string value = textBoxes.Find(boxName => boxName.Name == "Text" + name).Text;
            if(value == "")
            {
                Log("Error setting value - empty text box!", "WARNING", false);
                LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Can't set value - need a value in the text box!"));
                return;
            }
            try
            {
                Log("Writing " + value + " to " + name + ".", "SET VALUE", false);
                memory.WriteMemory(GetPointer(name), pointerTypes[pointerNames.IndexOf(name)], value);
                LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Set " + name + " to " + value + "."));
            }
            catch(FormatException)
            {
                Log("Error writing " + value + " to " + name + " - wrong type!", "WARNING", false);
                LabelLastAction.Invoke(new Action(() => LabelLastAction.Text = "Can't set value - wrong type!"));
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //update game status label if not already updated to current status
            if (processOpen && LabelGameStatus.Text != "Game Status: Open!")
            {
                LabelGameStatus.ForeColor = Color.Green;
                LabelGameStatus.Text = "Game Status: Open!";
            }
            else if (!processOpen && LabelGameStatus.Text != "Game Status: Closed!")
            {
                LabelGameStatus.ForeColor = Color.Red;
                LabelGameStatus.Text = "Game Status: Closed!";
            }
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void Log(string message, string category, bool verboseMessage)
        {
            if(!verbose && verboseMessage) //return if this is a verbose message and verbose is off
                return;

            if(logWriter == null) //set logWriter if it hasn't already been set
                logWriter = new StreamWriter("log.txt");

            string timestamp = DateTime.Now.ToString("[HH:mm:ss] ");
            logWriter.WriteLine(timestamp + category + ": " + message);
            logWriter.Flush();
        }
    }
}