$(document).ready(() => {

    $("#topic-admin-table").DataTable({

        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "Topic/LoadTopics",
            "type": "GET",
            "datatype": "json",
            "data": function (d) {
                let table = $("#topic-admin-table").DataTable();
                let order = table.order();
                d.numPage = table.page.info().page + 1;
                d.pageSize = table.page.info().length;
                d.columnToSort = "TopicName"
                d.order = order[0][1];
                d.searchKeyword = $('.dataTables_filter input').val();
                d.columnToSearch = "TopicName";
            }
        },
        "columnDefs":
            [{
                "targets": [0],
                "searchable": true,
            },
            {
                "targets": [2],
                "render": function (data, type, row) {
                    return data.substring(0, 10);
                }
            }],
        "columns": [
            {
                "render": function (data, type, full, meta) {
                    return '<a href="/Room/RoomsByTopic/' + full.Id + '">' + full.TopicName + '</a>';
                },
                "autoWidth": true,
                "sortable": true
            },
            {
                "data": "NumberOfRooms",
                "name": "Number of Rooms",
                "autoWidth": true
            },
            {
                "data": "CreationDate",
                "name": "Created Date",
                "autoWidth": true
            }
        ],
        "bLengthChange": false, //thought this line could hide the LengthMenu
        "bInfo": true, 
    });


});