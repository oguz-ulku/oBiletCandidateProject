function parseCustomDate(dateText) {
    var parts = dateText.split(' ');
    if (parts.length === 4) {
        var day = parseInt(parts[0]);
        var month = getMonthNumber(parts[1]);
        var year = parseInt(parts[2]);
        return new Date(year, month, day);
    }
    return null;
}

function getMonthNumber(monthName) {
    var months = [
        'Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran',
        'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'
    ];
    return months.indexOf(monthName);
}

function setDefaultValueDatePicker(defaultDate) {
    $(".todayBtn").addClass('selected');
    $("#datepicker").datepicker("setDate", defaultDate);
}
function setToDayDatePicker() {
    var today = new Date();
    $("#datepicker").datepicker("setDate", today);
}
function setTomorrowDatePicker() {
    const today = new Date()
    const tomorrow = new Date(today)
    tomorrow.setDate(tomorrow.getDate() + 1)
    $("#datepicker").datepicker("setDate", tomorrow);
}

function swapDropdownValues() {
    var dropdown1 = $("#toFrom");
    var dropdown2 = $("#toWhere");

    var tempValue = dropdown1.val();
    dropdown1.val(dropdown2.val()).trigger('change');
    dropdown2.val(tempValue).trigger('change');
}

function isFutureDate() {

}


$(document).ready(function () {
    $("#toFrom").select2();
    $("#toWhere").select2();
    $(".select2-searchable").select2();

    $(document).on('keyup', '.select2-search__field', function (e) {
        var dropdown1 = $(".select2-search__field");
        var value = dropdown1.val();
        sendData(value);
    });


    function sendData(searchValue) {
        $.ajax({
            url: 'Home/Search',
            type: 'POST',
            data: { searchValue: searchValue },
            success: function (response) {
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }



    $('.datepicker-button').on('click', function () {
        $('.datepicker-button').removeClass('selected');
        $(this).addClass('selected');
    });


    $(function () {
        $("#datepicker").datepicker({
            dateFormat: "dd MM yy DD",
            altField: "#datepicker",
            altFormat: "dd MM yy DD",
            minDate: 0,
            onSelect: function (dateText, inst) {

                var today = new Date()
                var tomorrow = new Date(today)
                tomorrow.setDate(tomorrow.getDate() + 1)


                var selectedDate = parseCustomDate(dateText);
                if (selectedDate) {
                    var options = { day: 'numeric', month: 'long', year: 'numeric', weekday: 'long' };
                    var formattedDate = selectedDate.toLocaleDateString('tr-TR', options);
                    var formattedToday = today.toLocaleDateString('tr-TR', options);
                    var formattedTomorrow = tomorrow.toLocaleDateString('tr-TR', options);
                    $(this).val(formattedDate);

                    if (dateText === formattedToday) {
                        $(".todayBtn").addClass('selected');
                        $(".tomorrowBtn").removeClass('selected');
                    } else if (dateText === formattedTomorrow) {
                        $(".todayBtn").removeClass('selected');
                        $(".tomorrowBtn").addClass('selected');
                    } else {
                        $(".todayBtn").removeClass('selected');
                        $(".tomorrowBtn").removeClass('selected');
                    }
                }
            }
        });

        setDefaultValueDatePicker(new Date());
    });
 
});

