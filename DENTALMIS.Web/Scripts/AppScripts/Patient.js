
function  getPatientByDisease()  {
    $('#diseasesId').unbind('change').bind('change', function () {
        var dId = $(this).val();
        var responseText = $("#diseasesId option:selected").text();
        if (responseText != '--Select diseases Name--') {
            getPatientByDiseasesId(dId);
        } else {
            $("#patientId").find('option')
                .remove()
                .end()
                .append('<option>--Select--</option>');

        }
    });
}
function getPatientByDiseasesId(dId) {
    $('#patientId').html('');
    if (dId != "") {
        $.getJSON('/PatientMedicalHistory/GetAllPatientByDiseasesId', { id: dId }).done(function (data) {
            if (data.length != 0) {
                var items = '<option >--Select Patient Name--</option>';
                $.each(data, function (i, d) {
                    items += "<option value='" + d.PatientId + "'>" + d.Name + "</option>";
                });
                $('#patientId').html(items);
            } else {
                var items = '<option>Not found</option>';
                $('#EmployeeDetail_EmployeeDesignationId').html(items);
            }

        });

    } else {

        $('#EmployeeDetail_EmployeeGradeId option').remove();
        $('#EmployeeDetail_EmployeeDesignationId option').remove();
    }
}



function loadAction(url) {
    if (url != undefined && url != "") {
        requseturl = url;
        jQuery.Ajax({
            url: url
            , container: '#contentRight'
        });

    } else {
        requseturl = "";
    }

}