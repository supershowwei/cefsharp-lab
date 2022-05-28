$(function () {
    window.objectBound.then(() => {
        console.log(CefSharp.IsObjectCached("/#viewBinding"));

        $("#test").on("click", () => {
            window.viewBinding.add(1, 1).then(result => {
                console.log(result);
                window.location = "/test/test.html";
            });

            // window.viewBinding.getTestData().then(result => {
            //     console.log(JSON.stringify(result));
            // });

            // window.viewBinding.getTestDataWithCallback(function (result) {
            //     console.log(JSON.stringify(result));
            // });

            // window.viewBinding.getSupportedPrimitiveDataTypesWithCallback(function (a, b, c, d, e, f, g, h) {
            //     console.log(a);
            //     console.log(b);
            //     console.log(c);
            //     console.log(d);
            //     console.log(e);
            //     console.log(f);
            //     console.log(JSON.stringify(g));
            //     console.log(btoa(String.fromCharCode.apply(null, new Uint8Array(h))));
            // });

        });

    });
});

// (async function () {
//     let convertPromiseToCefSharpCallback = function (p) {
//         let f = function (callbackId, ...args) {
//             //We immediately return CefSharpDefEvalScriptRes as we will be
//             //using a promise and will call sendEvalScriptResponse when our
//             //promise has completed
//             (async function () {
//                 try {
//                     //Await the promise
//                     let response = await p(...args);

//                     //We're done, let's send our response back to our .Net App
//                     cefSharp.sendEvalScriptResponse(callbackId, true, response, true);
//                 }
//                 catch (err) {
//                     //An error occurred let's send the response back to our .Net App
//                     cefSharp.sendEvalScriptResponse(callbackId, false, err.message, true);

//                 }
//             })();

//             //Let CefSharp know we're going to be defering our response as we have some async/await
//             //processing to happen before our callback returns it's value
//             return "CefSharpDefEvalScriptRes";
//         }

//         return f;
//     }

//     let callback = convertPromiseToCefSharpCallback(function () {
//         return new Promise((resolve, reject) => {
//             setTimeout(() => {
//                 resolve('Hello from Javascript');
//             }, 300);
//         });
//     });

//     await CefSharp.BindObjectAsync("_index");

//     _index_viewBinding.add(1, 1).then(result => {
//         alert(result);
//     });

//     $("#test").on("click", () => {
//         window.location = "/test/test.html";
//     });
// })();