using System;
using System.Collections.Generic;
using System.Text;
using CefSharp;

namespace NetCoreCefSharpLab.ViewBindings
{
    public class IndexViewBinding
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        //public void Add(int a, int b, IJavascriptCallback callback)
        //{
        //    callback.ExecuteAsync(a + b);
        //}
    }
}
