using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using CefSharp.JavascriptBinding;
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

            this.browser = new ChromiumWebBrowser { Dock = DockStyle.Fill };

            this.browser.JavascriptObjectRepository.NameConverter = new CamelCaseJavascriptNameConverter();

            this.browser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
                {
                    e.ObjectRepository.Register(e.ObjectName, ViewBindingFactory.Instance.Create(e.ObjectName, this.browser));
                };

            this.browser.ConsoleMessage += (sender, args) =>
                {
                    Debug.WriteLine(args.Message);
                };

            this.browser.LoadingStateChanged += async (sender, args) =>
                {
                    if (args.IsLoading == false)
                    {
                        var res = await this.browser.EvaluateScriptAsync("getNestedObjectList();");
                    }
                };

            this.browser.LoadUrl("local://shiseido/");

            this.Controls.Add(this.browser);
        }
    }
}