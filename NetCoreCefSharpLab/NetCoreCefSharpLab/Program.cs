using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;

namespace NetCoreCefSharpLab
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var settings = new CefSettings();

            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            settings.RegisterScheme(
                new CefCustomScheme
                {
                    SchemeName = "chef",
                    DomainName = "appcookhouse",
                    //SchemeHandlerFactory = new FolderSchemeHandlerFactory(@"Views", defaultPage: "index.html")
                    SchemeHandlerFactory = new ResourcesSchemeHandlerFactory()
                });

            Cef.EnableHighDPISupport();
            Cef.Initialize(settings);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
