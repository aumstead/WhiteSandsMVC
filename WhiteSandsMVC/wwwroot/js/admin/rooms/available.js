var dataTable;

$(document).ready(function () {
    loadList();
});
function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/rooms/available",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "id", "width": "10%", "className": "dt-body-center" },
            { "data": "roomType.name", "width": "10%" },
            { "data": "roomNumber", "width": "10%", "className": "dt-body-center" },
            {
                "data": "available", "width": "10%", "className": "dt-body-center", "render": function (data) {
                    if (data) {
                        return "Available"
                    } else {
                        return "Occupied"
                    }
                }
            },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Rooms/Details/${data}" class="small-btn" style="cursor:pointer; width: 100px;">View Details
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