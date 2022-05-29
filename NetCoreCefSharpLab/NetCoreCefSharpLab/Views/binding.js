window.objectBound = (async function (bindingName) {

    await CefSharp.BindObjectAsync(bindingName);

    Object.defineProperty(window, "viewBinding", { get: function () { return this[bindingName]; } });

})(`${window.location.pathname.replace(/\.[^\/]+$/g, "")}#viewBinding`);
