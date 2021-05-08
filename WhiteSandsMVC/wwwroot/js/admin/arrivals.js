var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/bookings/arrivals",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "id", "width": "10%", "className": "dt-body-center" },
            { "data": "guest.firstName", "width": "10%" },
            { "data": "guest.lastName", "width": "10%" },
            {
                "data": "checkInDate", "width": "10%", "className": "dt-body-center", "render": function (data) {
                    var date = moment(data)
                    var dateComponent = date.utc().format('M-D-YY');
                    return dateComponent
                }
            },
            { "data": "status", "width": "10%", "className": "dt-body-center" },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/check-in/step-one/${data}" class="small-btn" style="cursor:pointer; width: 100px;">Check In
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