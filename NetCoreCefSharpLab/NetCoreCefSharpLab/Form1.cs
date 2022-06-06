using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using CefSharp.JavascriptBinding;
using CefSharp.WinForms;
using NetCoreCefSharpLab.ViewBindings;

namespace NetCoreCefSharpLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            var browser = new ChromiumWebBrowser { Dock = DockStyle.Fill };

            browser.JavascriptObjectRepository.NameConverter = new CamelCaseJavascriptNameConverter();

            browser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
                {
                    e.ObjectRepository.Register(e.ObjectName, ViewBindingFactory.Instance.Create(e.ObjectName, browser));
                };

            browser.ConsoleMessage += (sender, args) =>
                {
                    Debug.WriteLine(args.Message);
                };

            browser.LoadingStateChanged += async (sender, args) =>
                {
                    if (args.IsLoading == false)
                    {
                        var res = await browser.EvaluateScriptAsync("getNestedObjectList();");
                    }
                };

            browser.LoadUrl("chef://appcookhouse/");

            this.Controls.Add(browser);
        }
    }
}