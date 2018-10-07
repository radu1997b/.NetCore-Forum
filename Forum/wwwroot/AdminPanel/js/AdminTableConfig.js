$(document).ready(() => {

    $("#topic-admin-table").DataTable({

        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "/AdminPanel/Admin/LoadTopics",
            "type": "GET",
            "datatype": "json",
            "data": function (d) {
                let table = $("#topic-admin-table").DataTable();
                let order = table.order();
                d.numPage = table.page.info().page + 1;
                d.pageSize = table.page.info().length;
                d.columnToSort = table.settings().init().columns[order[0][0]].data;
                d.order = order[0][1];
                d.searchKeyword = $('.dataTables_filter input').val();
                d.columnToSearch = "TopicName";
            }
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "searchable": true,
            },
            {
                "targets": [3],
                "render": function (data, type, row) {
                    return formatData(data);
                }
            }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "TopicName", "name": "Topic Name", "autoWidth": true },
            { "data": "NumberOfRooms", "name": "Number of Rooms", "autoWidth": true, "sortable": false },
            { "data": "CreationDate", "name": "Created Date", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {

                    return '<a id=' + full.Id + ' class="btn btn-info update-topic-btn">Edit</a>';
                },
                "sortable": false
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.Id + "'); >Delete</a>";
                },
                "sortable": false
            }
        ],
        "drawCallback": function (settings, json) {
            addEventToUpdateButtons();
        }
    });


});

function formatData(data) {

    return data.substring(0, 10);
}


$("#topic-update-dialog").dialog({
    modal: true
}).dialog("close");

function Update(Id, topicName) {
    $("#topic-update-dialog").dialog("open");
    var table = $("#topic-admin-table").DataTable();
    $("#update-topic input[type='text']").val(topicName);
    $("#update-topic input[type='hidden'").val(Id);
}


var addEventToUpdateButtons = () => {
    let table = $("#topic-admin-table").DataTable();
    var updateButtonList = $(".update-topic-btn");
    updateButtonList.each((i, obj) => {
        $(obj).on("click", () => {
            var data = table.row(i).data();
            Update(data.Id, data.TopicName);
        });
    });
}

$("#topic-create-dialog").dialog({
    modal: true
}).dialog("close");

function CreateTopic() {

    $("#topic-create-dialog").dialog('open');
}

function DeleteData(CustomerID) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(CustomerID);
    }
    else {
        return false;
    }
}

function Delete(ID) {
    var url = "/AdminPanel/Admin/DeleteTopic";
    $.ajax({
        url: url,
        type: 'DELETE',
        data: { id: ID },
        success: function (result) {
            oTable = $('#topic-admin-table').DataTable();
            oTable.draw();
        },
        error: function (result) {
            alert("error on deleting row");
        }
    });
}

