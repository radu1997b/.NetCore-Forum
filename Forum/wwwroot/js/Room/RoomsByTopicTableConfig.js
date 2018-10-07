$(document).ready(() => {

    $("#room-table").DataTable({

        "serverSide": true,
        "processing": true, // for show progress bar
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "/Room/GetRoomsByTopic",
            "type": "GET",
            "datatype": "json",
            "data": function (d) {
                let table = $("#room-table").DataTable();
                let order = table.order();
                d.numPage = table.page.info().page + 1;
                d.pageSize = 10;
                d.columnToSort = "RoomName";
                d.order = order[0][1];
                d.searchKeyword = $('.dataTables_filter input').val();
                d.columnToSearch = "RoomName";
                d.TopicId = window.location.pathname.split("/").pop();
            }
        },
        "columns": [
            {
                "render": function (data, type, full, meta) {

                    return '<a href="/Room/GetRoom/' + full.RoomId + '">' + full.RoomName + '</a>';
                },
                "sortable": true
            },
            { "data": "NumberOfPosts", "name": "Number of Posts", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {

                    return full.CreationDate.substring(0, 10);
                },
                "sortable": false
            },
        ],
        "bLengthChange": false,
        "bInfo": true
    });

});