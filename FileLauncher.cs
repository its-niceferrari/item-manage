using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace item_manage {
    public class FileLauncher {
        public void OpenFileOrApp(string filePath) {
            try {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", filePath);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    Process.Start(new ProcessStartInfo {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                } else {
                    Console.WriteLine("Unsupported operating system.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error opening file: {ex.Message}");
            }
        }
    }
}