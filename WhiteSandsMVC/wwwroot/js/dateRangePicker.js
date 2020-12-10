$('input[name="dateinput"]').daterangepicker({
    opens: 'left'
}, function (start, end, label) {
    console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));

    let checkInHidden = document.getElementById('check-in-hidden');
    let checkOutHidden = document.getElementById('check-out-hidden');
    checkInHidden.value = start;
    checkOutHidden.value = end;
});