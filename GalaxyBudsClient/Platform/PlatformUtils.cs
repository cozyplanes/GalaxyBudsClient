using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GalaxyBudsClient.Platform
{
    public static class PlatformUtils
    {
        public enum Platforms
        {
            Windows,
            Linux,
            Other
        }
        
        public static bool IsPlatformSupported()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ||
                   RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static bool SupportsTrayIcon => IsWindows;
        
        public static Platforms Platform
        {
            get
            {
                if (IsWindows)
                {
                    return Platforms.Windows;
                }
                else if (IsLinux)
                {
                    return Platforms.Linux;
                }

                return Platforms.Other;
            }
        }
        
        public static string CombineDataPath(string postfix)
        {
            return Path.Combine(AppDataPath, postfix);
        }

        public static string AppDataPath =>
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/GalaxyBudsClient/";
    }
}