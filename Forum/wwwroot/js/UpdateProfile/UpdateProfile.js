$(":input[type='date']").datepicker({
    dateFormat: 'yy-mm-dd',
    changeMonth: true,
    changeYear: true,
    yearRange: "1950:" + (new Date().getFullYear()).toString()
});