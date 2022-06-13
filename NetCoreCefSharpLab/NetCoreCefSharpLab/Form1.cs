using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using CefSharp;
using CefSharp.JavascriptBinding;
using CefSharp.WinForms;
using NetCoreCefSharpLab.Models.Data;
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

            browser.ExecuteScriptAsyncWhenPageLoaded("goToHome();");

            browser.LoadingStateChanged += async (sender, args) =>
                {
                    if (args.IsLoading == false)
                    {
                        // 無回傳值
                        //browser.ExecuteScriptAsync("goToHome();");
                        //browser.ExecuteScriptAsync("goTo", "/");
                        //var response = await browser.EvaluateScriptAsync("passPrimitiveDataTypes", 1, 0.1, DateTime.Now, true, "str");

                        //var result = (int)response.Result;

                        //var o = new TestData { Id = 1, Name = "Johnny", Test = new TestData { Id = 2, Name = "Amy" } };

                        //var response = await browser.EvaluateScriptAsync($"passObject({JsonSerializer.Serialize(o, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })});");

                        //var result = (dynamic)response.Result;

                        var bin = Encoding.UTF8.GetBytes("abc123");

                        var response = await browser.EvaluateScriptAsync($"passBinary([{string.Join(',', bin)}]);");

                        var result = ((IDictionary<string, object>)response.Result).Select(kv => Convert.ToByte(kv.Value)).ToArray();

                        // 有回傳值
                        var res1 = await browser.EvaluateScriptAsync("getNestedObjectList();");
                        var res2 = await browser.EvaluateScriptAsync("add", 1, 2);
                        var res3 = await browser.EvaluateScriptAsPromiseAsync("return addAsPromise(1, 2);"); // Promise Function
                    }
                };

            browser.FrameLoadEnd += (sender, args) =>
                {

                };

            browser.LoadUrl("chef://appcookhouse/");

            this.Controls.Add(browser);
        }
    }
}