using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Alexon.UsefulTools
{
    public static class Tools
    {

        /*
            .NET Framework version	Minimum value
            .NET Framework 4.5	378389
            .NET Framework 4.5.1	378675
            .NET Framework 4.5.2	379893
            .NET Framework 4.6	393295
            .NET Framework 4.6.1	394254
            .NET Framework 4.6.2	394802
            .NET Framework 4.7	460798
            .NET Framework 4.7.1	461308
            .NET Framework 4.7.2	461808
            .NET Framework 4.8	528040
            .NET Framework 4.8.1	533320
         */
        public static string GetVersionFromRelease(int releaseKey)
        {
            if (releaseKey >= 533320)
            {
                return "4.8.1";
            }

            if (releaseKey >= 528040)
            {
                return "4.8";
            }

            if (releaseKey >= 461808)
            {
                return "4.7.2";
            }

            if (releaseKey >= 461308)
            {
                return "4.7.1";
            }

            if (releaseKey >= 460798)
            {
                return "4.7";
            }

            if (releaseKey >= 394802)
            {
                return "4.6.2";
            }

            if (releaseKey >= 394254)
            {
                return "4.6.1";
            }

            if (releaseKey >= 393295)
            {
                return "4.6";
            }

            if (releaseKey >= 379893)
            {
                return "4.5.2";
            }

            if (releaseKey >= 378675)
            {
                return "4.5.1";
            }

            if (releaseKey >= 378389)
            {
                return "4.5";
            }

            return "No 4.5 or later version detected";
        }

        public static IEnumerable<string> GetDotNetFrameworkVersions()
        {
            var allVersions = new List<string>();

            using (var ndpKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                var versionKeyNames = ndpKey.GetSubKeyNames().Where(x => x.StartsWith("v"));

                foreach (var versionKeyName in versionKeyNames)
                {
                    var versionKey = ndpKey.OpenSubKey(versionKeyName);
                    var name = (string)versionKey.GetValue("Version", "");
                    var sp = versionKey.GetValue("SP", "").ToString();
                    var install = versionKey.GetValue("Install", "").ToString();
                    if (install == "1")
                    {
                        allVersions.Add($"{versionKeyName} {name} SP{sp}");
                    }
                    if (name != "")
                    {
                        continue;
                    }
                    foreach (var subKeyName in versionKey.GetSubKeyNames())
                    {
                        var subKey = versionKey.OpenSubKey(subKeyName);
                        name = (string)subKey.GetValue("Version", "");
                        if (name != "")
                        {
                            sp = subKey.GetValue("SP", "").ToString();
                        }
                        install = subKey.GetValue("Install", "").ToString();
                        if (install == "1")
                        {
                            allVersions.Add($"{versionKeyName} {subKeyName} {name} SP{sp}");
                        }
                    }
                }

                // Check for .NET Framework 4.5 and later
                var v4FullKey = ndpKey.OpenSubKey(@"v4\Full");
                if (v4FullKey != null)
                {
                    var release = (int)v4FullKey.GetValue("Release", 0);
                    if (release != 0)
                    {
                        allVersions.Add($" {GetVersionFromRelease(release)} ({release})");
                    }
                }
            }

            allVersions.Add($"Runtime {RuntimeInformation.FrameworkDescription}");

            return allVersions;
        }
    }
}