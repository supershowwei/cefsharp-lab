using System;
using CefSharp;

namespace NetCoreCefSharpLab.ViewBindings
{
    public class ViewBindingFactory
    {
        private static readonly Lazy<ViewBindingFactory> Lazy = new Lazy<ViewBindingFactory>(() => new ViewBindingFactory());

        private ViewBindingFactory()
        {
        }

        public static ViewBindingFactory Instance => Lazy.Value;

        public object Create(string objectName, IChromiumWebBrowserBase browser)
        {
            var viewName = objectName.Replace("#viewBinding", string.Empty);

            switch (viewName)
            {
                case "indexViewBinding":
                case "/":
                case "/index": return new IndexViewBinding(browser);
                case "/test/test": return new IndexViewBinding(browser);
                default: throw new ArgumentOutOfRangeException(nameof(objectName));
            }
        }
    }
}