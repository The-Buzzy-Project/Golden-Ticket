/*   This file is part of Golden Ticket.
*
*    Golden Ticket is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 2 of the License, or
*    (at your option) any later version.
*
*    Golden Ticket is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with Golden Ticket.  If not, see <https://www.gnu.org/licenses/>.
*/


﻿using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Golden_Ticket.Utilities
{
    /// <summary>
    /// Gets information about the system in use.
    /// </summary>
    public static class MachineInfo
    {
        // TODO: Reimplement as a proper object.
        public static string WindowsVersion => GetWinVerFromVb;
        public static int WindowsBuild => Environment.OSVersion.Version.Build;
        public static string ProcessorName => GetProcessorNameFromWmi();
        public static string Arch => Environment.Is64BitOperatingSystem? "x64" : "x86";
        public static string GpuName => GetGpuNameFromWmi();
        public static ulong TotalMemory => GetTotalMemoryInBytes;

        /// <summary>
        /// Gets a registry entry from HKEY_LOCAL_MACHINE.
        /// </summary>
        /// <param name="path">The path to the registry key.</param>
        /// <param name="key">The name of the key.</param>
        /// <returns>The contents of the registry key.</returns>
        private static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string) rk.GetValue(key);
            }
            catch { return null; }
        }

        /// <summary>
        /// Gets the friendly name of this version of Windows from the registry.
        /// </summary>
        /// <returns>The Windows product name, or null if the operation fails.</returns>
        /// <remarks>In testing, I noticed this incorrectly reports my Windows SKU as Enterprise instead of Pro.</remarks>
        private static string GetWinVerFromRegistry()
        {
            string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (!string.IsNullOrWhiteSpace(productName))
            {
                return (productName.StartsWith("Microsoft") ? "" : "Microsoft ") + productName +
                       (csdVersion != "" ? " " + csdVersion : "");
            }

            return null;
        }

        /// <summary>
        /// Gets the friendly name of this version of Windows from .NET.
        /// </summary>
        /// <returns>The Windows product name.</returns>
        private static string GetWinVerFromVb => new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;

        /// <summary>
        /// Gets the friendly name of the processor from Windows Management Instrumentation.
        /// Takes a surprisingly long time.
        /// </summary>
        /// <returns>The name of the processor.</returns>
        private static string GetProcessorNameFromWmi()
        {
            // TODO: WMI is insanely slow! Perhaps there is a better way of doing this? Do research.
            ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT name FROM Win32_Processor");

            foreach (ManagementObject moProcessor in mosProcessor.Get())
            {
                return moProcessor?["name"].ToString();
            }
            return null;
        }

        /// <summary>
        /// Gets the friendly name of the primary graphics processor from Windows Management Instrumentation.
        /// Takes a surprisingly long time.
        /// </summary>
        /// <returns>The name of the GPU.</returns>
        private static string GetGpuNameFromWmi()
        {
            ManagementObjectSearcher searcher
                = new ManagementObjectSearcher("SELECT description FROM Win32_DisplayConfiguration");

            foreach (ManagementObject moGpu in searcher.Get())
            {
                return moGpu?["description"].ToString();
            }
            return null;
        }

        /// <summary>
        /// Checks if the current application is running as an administrator.
        /// </summary>
        public static bool IsAdministrator
        {
            get
            {
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// Gets whether User Account Control is enabled on this computer.
        /// </summary>
        /// <remarks>I don't like consulting the registry for this, but I haven't found a better way.</remarks>
        public static bool IsUacEnabled =>
            (HKLM_GetString(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA") != "0");

        /// <summary>
        /// Gets the total addressable RAM of the current system in bytes.
        /// </summary>
        /// <returns>RAM in bytes.</returns>
        private static ulong GetTotalMemoryInBytes => new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;

        /// <summary>
        /// Outputs a description of the system in use to a string with Markdown formatting.
        /// </summary>
        /// <returns>Markdown formatted description of the current system.</returns>
        public static string[] ToFileOutput()
        {
            // Add system and some launcher info to the List
            // Also format with markdown to make it easier to read on Github/reddit...
            List<string> specsExport = new List<string>
            {
                "## Auto-Generated by Golden Ticket at " + DateTime.Now,
                "",
                "---",
                "",
                "* **OS:** " + WindowsVersion + Arch,
                "",
                "* **CPU:** " + ProcessorName,
                "",
                "* **GPU:** " + GpuName,
                "",
                "* **RAM:** " + FormatBytesUnsafe(TotalMemory),
                "",
                "* **Golden Ticket version:** " + Application.ProductVersion
            };

            // Convert to array
            return specsExport.ToArray();
        }

        /// <summary>
        /// Formats bytes in a user-friendly way by converting to the most appropriate denominator.
        /// </summary>
        /// <param name="bytes">Size in bytes.</param>
        /// <returns>A friendly description of a size.</returns>
        public static string FormatBytes(ulong bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return $"{dblSByte:0.##} {suffix[i]}";
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatByteSize(
            ulong fileSize
            , [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer
            , int bufferSize);
        
        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="fileSize">The numeric value to be converted.</param>
        /// <returns>The converted string</returns>
        /// <remarks>Taken from pinvoke.net.</remarks>
        public static string FormatBytesUnsafe(ulong fileSize)
        {
            StringBuilder sb = new StringBuilder(11);
            StrFormatByteSize(fileSize, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}