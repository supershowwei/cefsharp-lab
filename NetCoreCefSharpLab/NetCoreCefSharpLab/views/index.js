$(function () {
    window.objectBound.then(() => {

        $("#test").on("click", () => {
            window.viewBinding.add(1, 1).then(result => {
                alert(result);
                window.location = "/test/test.html";
            });
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