$(".option").on("click", function () {
    $(".option").removeClass("active");
    $(this).addClass("active");
    var type = $(this).data("option");
    setTimeout(function () {
        if (type === "login") {
            window.location = "/auth/login"
        } else if (type === "home") {
            window.location = "/auth/landing"
        }
    }, 500);
});