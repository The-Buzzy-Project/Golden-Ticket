﻿using Microsoft.Win32;

public class MachineInfo
{

    string HKLM_GetString(string path, string key)
    {
        try
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
            if (rk == null) return "";
            return (string)rk.GetValue(key);
        }
        catch { return ""; }
    }

    public string /*Friendly*/WindowsVersion()
    {
        string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
        string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
        if (ProductName != "")
        {
            return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                        (CSDVersion != "" ? " " + CSDVersion : "");
        }
        return "";
    }

}