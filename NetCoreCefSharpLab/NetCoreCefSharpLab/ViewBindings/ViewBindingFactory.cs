using System;

namespace NetCoreCefSharpLab.ViewBindings
{
    public class ViewBindingFactory
    {
        private static readonly Lazy<ViewBindingFactory> Lazy = new Lazy<ViewBindingFactory>(() => new ViewBindingFactory());

        private ViewBindingFactory()
        {
        }

        public static ViewBindingFactory Instance => Lazy.Value;

        public object Create(string objectName)
        {
            var viewName = objectName.Replace("#viewBinding", string.Empty);

            switch (viewName)
            {
                case "/":
                case "/index": return new IndexViewBinding();
                case "/test/test": return new IndexViewBinding();
                default: throw new ArgumentOutOfRangeException(nameof(objectName));
            }
        }
    }
}