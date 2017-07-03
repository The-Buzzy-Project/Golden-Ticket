using System;
using System.IO;
using Microsoft.Win32;

public class GameInfo
{

    public string GetGameVersionFromReg()
    {
        try
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Bullfrog Productions Ltd\\Theme Park World"))
            {
                if (key != null)
                {
                    return key.GetValue("Version").ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string GetInstallLocationFromReg()
    {

        try
        {
            if (Environment.Is64BitOperatingSystem == true) // There's a difference in the registry path between x86 and x64. Check the arch and change accordingly.
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\TP.exe"))
                {
                    if (key != null)
                    {
                        return key.GetValue("Path").ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\TP.exe"))
                {
                    if (key != null)
                    {
                        return key.GetValue("Path").ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool CheckGoldEditionStatus()
    {

       /*
        * This will attempt to find out if we're Gold Edition or not by checking for a Gold Edition file from each park
        */

            string gamePath = GetInstallLocationFromReg();

            // Check if a Gold Edition sideshow exists in the Fantasy park
            if (File.Exists(gamePath + "\\data\\levels\\fantasy\\sideshow\\_puzzle_24.wad"))
            {
                if(File.Exists(gamePath + "\\data\\levels\\hallow\\rides\\_devil_18.wad")) // It does, let's check for a ride in the Hallow park
                {
                    if(File.Exists(gamePath + "\\data\\levels\\jungle\\rides\\_snake_1.wad")) // It does, let's check for a ride in the Jungle park
                    {
                        if(File.Exists(gamePath + "\\data\\levels\\space\\features\\_pulsar_29.wad")) // It does, let's check for a feature in the Space park
                        {
                            // All checks successful -- We're Gold Edition!
                            return true;
                        }
                        else
                        {
                            // Feature check did not return for the Gold Edition feature from Space
                            return false;
                        }
                    }
                    else
                    {
                        // Ride check did not return the Gold Edition ride from Jungle
                        return false;
                    }
                }
                else
                {
                    // Ride check did not return the Gold Edition ride from Hallow
                    return false;
                }
            }
            else
            {
                // Sideshow check did not return the Gold Edition sideshow from Fantasy
                return false;
            }
    }

    public bool GameIsPatched()
    {
        /*
         * We need to check if the game is patched or not.
         * This can easily be achieved by looking for a single file...
         * 
         *      - patchedByGoldenTicket (main game path with TP.exe)
         */

        if(!File.Exists(GetInstallLocationFromReg() + "\\patchedByGoldenTicket"))
        {
            // The 'patchedByGoldenTicket' file doesn't exist. Return false.
            return false;
        }
        return true; // The file exists. 
    }
}