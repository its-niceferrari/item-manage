using System.Diagnostics;

namespace item_manage
{
    public static class FileLauncher
    {
        public static void OpenFileOrApp(string itemName)
        {
            string? appPath = itemName switch
            {
                "Visual Studio" => "/Applications/Visual Studio.app",
                "Terminal" => "/System/Applications/Utilities/Terminal.app",
                "Project Plan" => "/Users/nicef/Documents/ProjectPlan.pdf",
                "Meeting Notes" => "/Users/nicef/Documents/MeetingNotes.docx",
                _ => null
            };

            if (!string.IsNullOrEmpty(appPath))
            {
                Process.Start("open", appPath);
            }
        }
    }
}
