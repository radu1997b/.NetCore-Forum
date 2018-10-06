let page = window.location.pathname.split('/').pop();
let lastPage = $("#pagination-container li").last().prev().text();
if (page == 1)
    $("#prev-page").addClass("disabled");
if (page == lastPage)
    $("#next-page").addClass("disabled");