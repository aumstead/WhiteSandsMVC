var date = new Date()
// Add a day
date.setDate(date.getDate() + 1)

var start = new Date()
var end = date;

//$('#check-in-hidden').data('daterangepicker').setStartDate(start);
//$('#check-out-hidden').data('daterangepicker').setEndDate(end);
const checkInEl = document.getElementById('check-in-hidden');
const checkOutEl = document.getElementById('check-out-hidden');
start = checkInEl.value;
end = checkOutEl.value;

$('input[name="dateinput"]').daterangepicker({
    opens: 'left',
    minDate: new Date(),
    startDate: start,
    endDate: end
}, function (start, end, label) {
    let checkInHidden = document.getElementById('check-in-hidden');
    let checkOutHidden = document.getElementById('check-out-hidden');
    checkInHidden.value = start.format('YYYY-MM-DD');
    checkOutHidden.value = end.format('YYYY-MM-DD');
});