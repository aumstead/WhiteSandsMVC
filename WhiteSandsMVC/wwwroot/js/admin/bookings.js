﻿var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/bookings/all",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "id", "width": "10%", "className": "dt-body-center" },
            { "data": "guest.firstName", "width": "10%" },
            { "data": "guest.lastName", "width": "10%" },
            {
                "data": "checkInDate", "width": "10%", "className": "dt-body-center", "render": function (data) {
                    let checkInDate = moment(data)
                    let checkInDateFormatted = checkInDate.utc().format('M-D-YY');
                    return checkInDateFormatted
                }
            },
            {
                "data": "checkOutDate", "width": "10%", "className": "dt-body-center", "render": function (data) {
                    let checkOutDate = moment(data)
                    let checkOutDateFormatted = checkOutDate.utc().format('M-D-YY');
                    return checkOutDateFormatted
                }
            },
            { "data": "status", "width": "10%", "className": "dt-body-center" },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/bookings/details/${data}" class="small-btn" style="cursor:pointer; width: 100px;">View Details
                            </a>
                            
                        </div>`;
                }, "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[3, "asc"]]
    })
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}