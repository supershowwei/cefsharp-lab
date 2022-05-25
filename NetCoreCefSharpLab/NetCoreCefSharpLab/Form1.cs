using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;

namespace NetCoreCefSharpLab
{
    public partial class Form1 : Form
    {
        private readonly ChromiumWebBrowser browser;

        public Form1()
        {
            this.InitializeComponent();

            var settings = new CefSettings();

            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            settings.RegisterScheme(
                new CefCustomScheme
                {
                    SchemeName = "local",
                    DomainName = "shiseido",
                    SchemeHandlerFactory = new FolderSchemeHandlerFactory(@"views", defaultPage: "index.html")
                });

            Cef.Initialize(settings);

            this.browser = new ChromiumWebBrowser("local://shiseido/") { Dock = DockStyle.Fill };

            this.Controls.Add(this.browser);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.browser.Dispose();

            Cef.Shutdown();

            base.OnFormClosing(e);
        }
    }
}