var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/bookings/departures",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "id", "width": "10%", "className": "dt-body-center" },
            { "data": "guest.firstName", "width": "10%" },
            { "data": "guest.lastName", "width": "10%" },
            {
                "data": "checkOutDate", "width": "10%", "className": "dt-body-center", "render": function (data) {
                    var checkOutDate = moment(data)
                    var checkOutDateFormatted = checkOutDate.utc().format('M-D-YY');
                    return checkOutDateFormatted
                }
            },
            { "data": "status", "width": "10%", "className": "dt-body-center" },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/CheckOut/${data}" class="small-btn" style="cursor:pointer; width: 100px;">Check Out
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