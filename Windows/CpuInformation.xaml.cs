using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScoobyDoo.Windows
{
    /// <summary>
    /// Interaction logic for CpuInformation.xaml
    /// </summary>
    public partial class CpuInformation : Window
    {
        public CpuInformation()
        {
            InitializeComponent();
            _Information.Text = GetCpuInformation();
        }

        public static string GetCpuInformation()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetCpuInformationWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetCpuInformationLinux();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetCpuInformationMac();
            else
                return "Unsupported OS";
        }

        private static string GetCpuInformationWindows()
        {
            StringBuilder cpuInfo = new StringBuilder();

            try
            {
                // Query the CPU information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    cpuInfo.AppendLine("CPU Information:");
                    cpuInfo.AppendLine($"Name: {obj["Name"]}");
                    cpuInfo.AppendLine($"Manufacturer: {obj["Manufacturer"]}");
                    cpuInfo.AppendLine($"Description: {obj["Description"]}");
                    cpuInfo.AppendLine($"Number Of Cores: {obj["NumberOfCores"]}");
                    cpuInfo.AppendLine($"Number Of Logical Processors: {obj["NumberOfLogicalProcessors"]}");
                    cpuInfo.AppendLine($"Processor ID: {obj["ProcessorId"]}");
                    cpuInfo.AppendLine($"Socket Designation: {obj["SocketDesignation"]}");
                    cpuInfo.AppendLine($"Max Clock Speed: {obj["MaxClockSpeed"]} MHz");
                    cpuInfo.AppendLine($"Current Clock Speed: {obj["CurrentClockSpeed"]} MHz");
                    cpuInfo.AppendLine($"L2 Cache Size: {obj["L2CacheSize"]} KB");
                    cpuInfo.AppendLine($"L3 Cache Size: {obj["L3CacheSize"]} KB");
                    cpuInfo.AppendLine();
                }
            }
            catch (Exception ex)
            {
                cpuInfo.AppendLine($"An error occurred while retrieving CPU information: {ex.Message}");
            }

            return cpuInfo.ToString();
        }

        private static string GetCpuInformationLinux()
        {
            return ExecuteBashCommand("lscpu");
        }

        private static string GetCpuInformationMac()
        {
            return ExecuteBashCommand("sysctl -a | grep machdep.cpu");
        }

        private static string ExecuteBashCommand(string command)
        {
            StringBuilder output = new StringBuilder();

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "/bin/bash";
                    process.StartInfo.Arguments = $"-c \"{command}\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    output.Append(process.StandardOutput.ReadToEnd());
                    output.Append(process.StandardError.ReadToEnd());

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                output.AppendLine($"An error occurred while executing the command: {ex.Message}");
            }

            return output.ToString();
        }
    }
}
