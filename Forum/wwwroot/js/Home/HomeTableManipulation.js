$(".table-row").each((count,value) => {
    if(count % 2 == 0)
       $(value).css("background-color", "#ddd");
});