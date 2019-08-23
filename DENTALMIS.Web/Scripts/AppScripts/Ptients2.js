function getPatientByDisease(dId) { // This is for cascade dropdown 
    var url = "/PatientMedicalHistory/GetPatientbyDiseases";
    $.ajax({
        url: url,
        type: "get",
        data: { "id": dId },
        dataType: 'json',
        success: function(data) {
            //if (data.length != 0) {
            //    var items = '<option>--Select Patient Name--</option>';

            //    $.each(data, function(i, patient) {

            //        items += "<option value='" + patient.PatientId + "'>" + patient.Name + "</option>";
            //    });
            //    $('#patientId').html(items);
            //} else {
            //    var items = '<option>Not found</option>';
            //    $('#patientId').html(items);
            //}

        }
    });
}