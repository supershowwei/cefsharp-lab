using System;
using System.Collections.Generic;
using System.Text;
using CefSharp;
using NetCoreCefSharpLab.Models.Data;

namespace NetCoreCefSharpLab.ViewBindings
{
    public class IndexViewBinding
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public TestData GetTestData()
        {
            return new TestData { Id = 1, Name = "Johnny", Test = new TestData { Id = 2, Name = "Mary" } };
        }

        //public void Add(int a, int b, IJavascriptCallback callback)
        //{
        //    callback.ExecuteAsync(a + b);
        //}
    }
}
