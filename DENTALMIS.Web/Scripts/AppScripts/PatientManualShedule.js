

function SearchPatientData() {
    var patientCode = $('.PatientCode').val();
    var dt = $('.VisitingTime').val();
    jQuery.ajax({
        url: "/PatientManualSheduling/GetPatientData"
        , data: { "patientCode": patientCode, "dt": dt }
        , type: "POST"
        ,success: function(r) {
            if (!r.Success) {
                alert("Patint did not found");
            }
            else if (r.Success) {
                $('.Gender').val(r.data[0]);
                $('.Diseases').val(r.data[1]);
                $('.Name').val(r.data[2]);
                $('.Contact').val(r.data[3]);
                $('.PatientId').val(r.data[4]);
                InTimeSetting(r.data[5]);
                $('.Id').val(r.data[6]);
                $('.Purpose').val(r.data[7]);
                var InDate = r.data[8];
                if (InDate > 0) {
                    $('.InTime').val(r.data[10]);
                }
            }
            else {
                self.DialogOpened();
            }
            }
    });
}
function SavePatientShedule() {
    var InPeriod = $('.InPeriod option:selected').val();
    var InHours = $('.InHours option:selected').val();
    var InMinutes = $('.InMinutes option:selected').val();
    if (InHours == 'Hour' || InMinutes == 'Minute' || InPeriod == 'AM/PM') {
        alert("Insert a valid In-Time");
        return;
    }
    if (InPeriod == 'PM' & InHours != '12')
        InHours = parseInt(InHours) + 12;
    if (InPeriod == 'AM' & InHours == '12')
        InHours = '00';
    //var OutPeriod = $('.OutPeriod option:selected').val();
    //var OutHours = $('.OutHours option:selected').val();
    //var OutMinutes = $('.OutMinutes option:selected').val();
    //var OutTimeValidation = OutHours + OutMinutes + OutPeriod;

    //if (OutTimeValidation != 'HourMinuteAM/PM') {
    //    if (isNaN(OutHours) || isNaN(OutMinutes) || OutPeriod == 'AM/PM') {
    //        alert("Insert a valid Out-Time");
    //        return;
    //    }
    //}

    //if (OutPeriod == 'PM' & OutHours != '12')
    //    OutHours = parseInt(OutHours) + 12;

    //if (OutPeriod == 'AM' & OutHours == '12')
    //    OutHours = '00';
    var values = [];
    values[0] = $('.PatientCode').val();
    values[1] = $('.VisitingTime').val();
    values[2] = InHours + ':' + InMinutes + ':00';
    values[3] = $('.Purpose').val();
    values[4] = $('.PatientId').val();
    values[5] = $('.Id').val();
    values[6] = $('.Contact').val();
    values[7] = $('.Serial').val();
    values[8] = $('.PataientType').val();
    jQuery.ajax({
        contentType: 'application/json; charset=utf-8'
    , dataType: 'json'
    , url: "/PatientManualSheduling/SavePatientShedule"
    , data: JSON.stringify(values)
    , type: "POST"
    , success: function (r) {
        if (r.Success) {
            var now = new Date();
            var twoDigitMonth = ((now.getMonth().length + 1) === 1) ? (now.getMonth() + 1) : '0' + (now.getMonth() + 1);
            var currentDate = now.getDate() + "/" + twoDigitMonth + "/" + now.getFullYear();
            $('.VisitingTime').val(currentDate);
            //$('.OutTime').val(currentDate);
            //InOutDropdownList();
            $('.PatientCode').val('');
            alert(r.Message);
        }
        else {
            self.DialogOpened();
        }
    }
    });
}






function InTimeSetting(InTimeData) {

    if (InTimeData == '00:00:00')
        return;

    if (InTimeData != null)
        var InTime = InTimeData;

    var InHours = InTime.substring(0, 2);
    var Period = 'AM';

    if (InHours > 12) {
        InHours = InHours - 12;
        Period = 'PM';
    }
    else if (InHours == 12) {
        Period = 'PM';
    }
    else if (InHours == 0) {
        InHours = 12;
    }

    if (InHours.toString().length == 1)
        InHours = '0' + InHours;

    var Minutes = InTime.substring(3, 5);

    $('.InHours').val(InHours);
    $('.InMinutes').val(Minutes);
    $('.InPeriod').val(Period);
}


function InOutDropdownList() {

    $('.PatientId').val('');
    $('.Contact').val('');
    $('.PataientType').val('');
    $('.Serial').val('');
    $('.Gender').val('');
    $('.Diseases').val('');
    $('.Name').val('');
   

    $('.InHours').val('Hour');
    $('.InMinutes').val('Minute');
    $('.InPeriod').val('AM/PM');

    $('.OutHours').val('Hour');
    $('.OutMinutes').val('Minute');
    $('.OutPeriod').val('AM/PM');

    $('.Purpose').val('');
}
