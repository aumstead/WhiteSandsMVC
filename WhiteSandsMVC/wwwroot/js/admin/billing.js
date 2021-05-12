var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/billing",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "id", "width": "10%", "className": "dt-body-center" },
            { "data": "guest.firstName", "width": "10%" },
            { "data": "guest.lastName", "width": "10%" },
            { "data": "status", "width": "10%" },
            { "data": "billOfSale.paymentStatus", "width": "10%", "className": "dt-body-center" },
            {
                "data": "billOfSaleId", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Billing/Invoice/${data}" class="small-btn" style="cursor:pointer; width: 100px;">View Invoice
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