let page = new URLSearchParams(window.location.search).get("page");
if (page === null)
    page = 1;
$("#pagination-container li").filter((x, y) => y.innerText == page).children().css("background-color", "aqua");
console.log($("#pagination-container li").filter(x => x.innerText == page));
let lastPage = $("#pagination-container li").last().prev().text();
if (page == 1)
    $("#prev-page").addClass("disabled");
if (page == lastPage || lastPage == "Previous")
    $("#next-page").addClass("disabled");