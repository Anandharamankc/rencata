$(document).ready(function () {
    employee_list();
});

function employee_list() {
    var emp_details = {
        Dml_Indicator: 'S',
    }
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Home/Employee_details',
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify(emp_details),
        success: function (data) {
            var tr = '';
            $('#tbl_employee').html('');
            if (jQuery.isEmptyObject((data))) {

            }
            else {
                var data = JSON.parse(data);
                var j = 1;
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Address == "" || data[i].Address==null) {
                            data[i].Address = '';
                        }
                        if (data[i].gender == 1) {
                            data[i].gender = 'Male';
                        }
                        else {
                            data[i].gender = 'Female';
                        }
                        if (data[i].marital_status == 1) {
                            data[i].marital_status = 'Married';
                        }
                        else {
                            data[i].marital_status = 'Unmarried';
                        }
                        tr = tr + '<tr><td>' + j + '</td>'
                        + '<td>' + data[i].employee_name + '</td>'
                        + '<td>' + data[i].father_name + '</td>'
                        + '<td>' + data[i].mother_name + '</td>'
                        + '<td>' + data[i].DOB + '</td>'
                        + '<td>' + data[i].gender + '</td>'
                        + '<td>' + data[i].marital_status + '</td>'
                        + '<td>' + data[i].Address + '</td>'
                        + '<td><a href="javaScript:void(0)" onclick="Empedit(' + data[i].employee_id + ')">Edit</a> | <a href="javaScript:void(0)" onclick="Empdelete(' + data[i].employee_id + ')">Delete</a></td></tr>';
                        j++;
                    }
                    $('#tbl_employee').html(tr);
                }
            }
        }
    });
}

function Empedit(val) {
    var emp_details = {
        employee_id:val,
        Dml_Indicator: 'E',
    }
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Home/Employee_details',
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify(emp_details),
        success: function (data) {
            if (jQuery.isEmptyObject((data))) {

            }
            else {
                var data = JSON.parse(data);

                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        $('#txtEmp_id').val(data[i].employee_id);
                        $('#txtEmp_Name').val(data[i].employee_name);
                        $('#txtEmp_FatherName').val(data[i].father_name);
                        $('#txtEmp_MotherName').val(data[i].mother_name);
                        $('#txt_DOB').val(data[i].DOB);
                        $('#Sel_Gender').val(data[i].gender);
                        $('#Sel_Marital_Status').val(data[i].marital_status);
                        $('#txt_Address').val(data[i].Address);
                        $('#btn_submit').html('Update');
                    }
                }
            }
        }
    });
}
function Empdelete(val) {
    var emp_details = {
        employee_id: val,
        Dml_Indicator: 'D',
    }
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Home/Employee_details',
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify(emp_details),
        success: function (data) {
            if (jQuery.isEmptyObject((data))) {

            }
            else {
                var data = JSON.parse(data);
                employee_list();
            }
        }
    });
}
$('#btn_submit').click(function () {
    if ($.trim($('#txtEmp_Name').val()) == "") {
        $('#PtxtEmp_Name').show();
        $('#PtxtEmp_Name').fadeOut(8000);
        $('#PtxtEmp_Name').html('Enter The Employee Name');
        $('#txtEmp_Name').focus();
        $('#txtEmp_Name').val('');
        return false;
    }
    if ($.trim($('#txtEmp_FatherName').val()) == "") {
        $('#PtxtEmp_FatherName').show();
        $('#PtxtEmp_FatherName').fadeOut(8000);
        $('#PtxtEmp_FatherName').html('Enter The Employee Father Name');
        $('#txtEmp_FatherName').focus();
        $('#txtEmp_FatherName').val('');
        return false;
    }
    if ($.trim($('#txtEmp_MotherName').val()) == "") {
        $('#PtxtEmp_MotherName').show();
        $('#PtxtEmp_MotherName').fadeOut(8000);
        $('#PtxtEmp_MotherName').html('Enter The Employee Mother Name');
        $('#txtEmp_MotherName').focus();
        $('#txtEmp_MotherName').val('');
        return false;
    }
    if ($.trim($('#txt_DOB').val()) == "") {
        $('#Ptxt_DOB').show();
        $('#Ptxt_DOB').fadeOut(8000);
        $('#Ptxt_DOB').html('Enter The DOB');
        $('#txt_DOB').focus();
        $('#txt_DOB').val('');
        return false;
    }
    if ($.trim($('#Sel_Gender').val()) == 0) {
        $('#PSel_Gender').show();
        $('#PSel_Gender').fadeOut(8000);
        $('#PSel_Gender').html('Select The Gender');
        $('#Sel_Gender').focus();
        $('#Sel_Gender').val('');
        return false;
    }
    if ($.trim($('#Sel_Marital_Status').val()) == 0) {
        $('#PSel_Marital_Status').show();
        $('#PSel_Marital_Status').fadeOut(8000);
        $('#PSel_Marital_Status').html('Select The Marital Status');
        $('#Sel_Marital_Status').focus();
        $('#Sel_Marital_Status').val('');
        return false;
    }
    var Dml_Indicator = '';
    if ($('#btn_submit').html() == "Submit") {
        Dml_Indicator = 'I';
    }
    else {
        Dml_Indicator = 'U';
    }
    var emp_details = {
        employee_id:$('#txtEmp_id').val(),
        employee_name: $('#txtEmp_Name').val(),
        father_name: $('#txtEmp_FatherName').val(),
        mother_name: $('#txtEmp_MotherName').val(),
        DOB: $('#txt_DOB').val(),
        gender: $('#Sel_Gender').val(),
        marital_status: $('#Sel_Marital_Status').val(),
        Address: $('#txt_Address').val(),
        Dml_Indicator: Dml_Indicator,
    }
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Home/Employee_details',
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify(emp_details),
        success: function (data) {
            if (jQuery.isEmptyObject((data))) {

            }
            else {
                var data = JSON.parse(data);
                $('#txtEmp_Name').val(''),
                $('#txtEmp_FatherName').val(''),
                $('#txtEmp_MotherName').val(''),
                $('#txt_DOB').val(''),
                $('#Sel_Gender').val(0),
                $('#Sel_Marital_Status').val(0),
                $('#txt_Address').val(''),
                employee_list();
                $('#btn_submit').html('Submit');
            }
        }
    });
});