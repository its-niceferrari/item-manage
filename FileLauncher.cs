using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace item_manage {
    public class FileLauncher {
        public void OpenFileOrApp(string filePath) {
            try { Process.Start("open", filePath); }
            catch (Exception ex) { Console.WriteLine($"Error opening file: {ex.Message}"); }
        }
    }
}