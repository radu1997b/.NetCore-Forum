var allInputs = $("#form-container").find(":input[type='text'],:input[type='password'],:input[type='email']");

for (let input = 0; input < allInputs.length; ++input) {

    $(allInputs[input]).on("focusin", () => {

        let textBox = allInputs[input];
        let num = $("#form-container").find(":input").index(textBox);
        $(textBox).before("<p>" + $(allInputs[input]).attr("placeholder") + "</p>");
        $(textBox).prev().hide().fadeIn(1000);
    });

    $(allInputs[input]).on("focusout",() => {

        let textBox = allInputs[input];
        window.setTimeout(() => { $(textBox).prev().remove(); },100);
    });
}

$("#form-container :input").tooltip({
    show: null,
    position: {
        my: "left top",
        at: "left bottom"
    },
    open: function (event, ui) {
        ui.tooltip.animate({ top: ui.tooltip.position().top }, "fast");
    },
    content: function () {
        return this.getAttribute("title");
    }
});