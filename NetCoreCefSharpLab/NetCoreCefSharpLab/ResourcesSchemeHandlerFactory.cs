using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using CefSharp;

namespace NetCoreCefSharpLab
{
    public class ResourcesSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            var fileName = new Uri(request.Url).AbsolutePath;

            if (fileName == "/") fileName = "/index.html";

            // ���}�ഫ���귽�W��
            var resourceName = Regex.Replace(fileName.Replace("/", "."), "\\.(\\d)", "._$1");

            // �q���O�귽Ū��������
            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"NetCoreCefSharpLab.Views{resourceName}");

            if (resource != null)
            {
                var fileExtension = Path.GetExtension(fileName);

                fileExtension = string.IsNullOrEmpty(fileExtension) ? ".html" : fileExtension;

                return ResourceHandler.FromStream(resource, mimeType: Cef.GetMimeType(fileExtension));
            }

            return null;
        }
    }
}