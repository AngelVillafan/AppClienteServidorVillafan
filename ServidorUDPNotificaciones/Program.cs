using ServidorUDPNotificaciones.Properties;
using System.Runtime.Versioning;

namespace ServidorUDPNotificaciones
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        
    }
    //public class MyCustomApplicationContext : ApplicationContext
    //{
    //    private NotifyIcon trayIcon;

    //    public MyCustomApplicationContext()
    //    {
    //        trayIcon = new NotifyIcon()
    //        {
    //            Icon = ,
    //            ContextMenuStrip = new ContextMenuStrip()
    //            {
    //                Items = { new ToolStripMenuItem("Exit", null, Exit) }
    //            },
    //            Visible = true
    //        };
    //    }

    //    void Exit(object? sender, EventArgs e)
    //    {
    //        trayIcon.Visible = false;
    //        Application.Exit();
    //    }
    //}
}
