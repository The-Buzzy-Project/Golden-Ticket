using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Golden_Ticket.Classes;
using Golden_Ticket.Patches;
using Golden_Ticket.Properties;
using Golden_Ticket.Utilities;
using Golden_Ticket.Windows;

namespace Golden_Ticket
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form = null;
            Game game = GetGame();
            List<Patch> patches = new List<Patch>();
            bool isPatching = false;
            foreach (string argument in args)
            {
                switch (argument.ToLowerInvariant())
                {
                    case "/i": case "-i":
                        isPatching = true;
                        break;
                    case "/?": case "-?":
                        MessageBox.Show("Command line arguments are as follows:" + Environment.NewLine +
                                        "/i - Launch patching utility.");
                        break;
                    case "auto":
                        patches.AddRange(PatchList.GetPatches());
                        break;
                    case "generic":
                        patches.Add(new GenericPatch());
                        break;
                    case "winvista":
                        patches.Add(new WinVistaPatch());
                        break;
                    case "win8":
                        patches.Add(new Win8Patch());
                        break;
                }
            }

            if (isPatching)
            {
                if (patches.Count == 0) { patches.AddRange(PatchList.GetPatches()); }

                form = new PatchingWindow(game, patches.ToArray());
            }

            Application.Run(form ?? new MainWindow(game));
        }

        /// <summary>
        /// Gets the Game object for use in all windows.
        /// If an error is returned, prompt the user to choose the directory.
        /// </summary>
        /// <returns>A game object describing the installation.</returns>
        private static Game GetGame()
        {
            try
            {
                return new Game();
            }
            catch (ArgumentNullException)
            {
                string folderPath = FileDialogs.GetTpwFolder();

                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    MessageBox.Show(
                        string.Format(Resources.GetGame_Error_Message, Resources.GameName_Europe, Resources.GameName_America),
                        Resources.GetGame_Error_Title,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return null;
                }
                return new Game(folderPath);
            }
        }
    }
}
