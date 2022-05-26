using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;
using NetCoreCefSharpLab.ViewBindings;

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
                    SchemeHandlerFactory = new FolderSchemeHandlerFactory(@"Views", defaultPage: "index.html")
                });

            Cef.Initialize(settings);

            this.browser = new ChromiumWebBrowser { Dock = DockStyle.Fill };

            this.browser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
                {
                    e.ObjectRepository.Register(e.ObjectName, ViewBindingFactory.Instance.Create(e.ObjectName));
                };

            this.browser.ConsoleMessage += (sender, args) =>
                {
                    Debug.WriteLine(args.Message);
                };

            this.browser.LoadUrl("local://shiseido/");

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