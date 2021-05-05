var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    console.log('in loadList')
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Guests",
            "type": "GET",
            "dataType": "json"
        },

        "columns": [
            { "data": "firstName", "width": "10%" },
            { "data": "lastName", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "email", "width": "10%" },
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/booking/details/${data}" class="small-btn" style="cursor:pointer; width: 100px;">View Details
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