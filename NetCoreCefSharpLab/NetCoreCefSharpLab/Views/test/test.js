$(function () {
    window.objectBound.then(() => {
        $("#test").on("click", () => {
            window.viewBinding.add(1, 1).then(result => {
                console.log(result);
                window.location = "/";
            });
        });
        
    });
});