﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using CefSharp;
using NetCoreCefSharpLab.Models.Data;

namespace NetCoreCefSharpLab.ViewBindings
{
    public class IndexViewBinding
    {
        private readonly IChromiumWebBrowserBase browser;

        public IndexViewBinding(IChromiumWebBrowserBase browser)
        {
            this.browser = browser;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public TestData GetTestData()
        {
            return new TestData { Id = 1, Name = "Johnny", Test = new TestData { Id = 2, Name = "Mary" } };
        }

        public void GetTestDataWithCallback(IJavascriptCallback callback)
        {
            callback.ExecuteAsync(new TestData
                                  {
                                      Id = 1,
                                      Name = "Johnny",
                                      Test = new TestData
                                             {
                                                 Id = 2,
                                                 Name = "Mary"
                                             }
                                  });
        }

        public void GetSupportedPrimitiveDataTypesWithCallback(IJavascriptCallback callback)
        {
            callback.ExecuteAsync(
                1,
                1.1d,
                DateTime.Now,
                true,
                "str",
                new List<int> { 1 },
                new List<TestData> { new TestData { Id = 1, Name = "Johnny", Test = new TestData { Id = 2, Name = "Mary" } } },
                Encoding.UTF8.GetBytes("軟體廚房"));
        }

        public void PassSupportedPrimitiveDataTypes(int a, double b, DateTime c, bool d, string e, dynamic f, List<object> g, List<dynamic> h)
        {
        }

        public int GetInt()
        {
            return 1;
        }

        public double GetDouble()
        {
            return 1.1;
        }

        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public bool GetBool()
        {
            return true;
        }

        public List<TestData> GetObjectList()
        {
            return new List<TestData> { new TestData { Id = 1, Name = "Johnny", Test = new TestData { Id = 2, Name = "Mary" } } };
        }
    }
}
