function PopulateDropDownList() {
    var subjectList1 = $("#SubjectList1");
    var subjectList2 = $("#SubjectList2");
    var subjectList3 = $("#SubjectList3");
    $.ajax({
        type: "GET",
        url: "/UniversityStudent/GetSubjects",
        dataType: "json",
        success: function (results) {
            $.each(results.subjectDatas, function (i,p) {
                subjectList1.append($('<option></option>').val(p.SubjectID).html(p.SubjectName));
                subjectList2.append($('<option></option>').val(p.SubjectID).html(p.SubjectName));
                subjectList3.append($('<option></option>').val(p.SubjectID).html(p.SubjectName));
            });
        }
    });
}
function Register() {
    var FirstName = $("#FirstName").val();
    var LastName = $("#LastName").val();
    var Email = $("#Email").val();
    var Password = $("#Password").val();
    var Address = $("#Address").val();
    var PhoneNo = $("#PhoneNo").val();
    var DateofBirth = $("#DateofBirth").val();
    var GuardianName = $("#GuardianName").val();
    var NationalID = $("#NationalID").val();
    var Subject1 = $("#SubjectList1").val();
    var Grade1 = $("#Grades1").val();
    var Subject2 = $("#SubjectList2").val();
    var Grade2 = $("#Grades2").val();
    var Subject3 = $("#SubjectList3").val();
    var Grade3 = $("#Grades3").val();
    var register = { FirstName: FirstName, LastName: LastName, Email: Email, Password: Password, Address: Address, PhoneNo: PhoneNo, DateofBirth: DateofBirth, GuardianName: GuardianName, NationalID: NationalID, SubjectID_1: Subject1, Grade_1: Grade1, SubjectID_2: Subject2, Grade_2: Grade2, SubjectID_3: Subject3, Grade_3: Grade3 };
    $.ajax({
        type: "POST",
        url: "/UniversityStudent/AddStudent",
        data: register,
        dataType: "json",
        success: function (response) {
            if (response.hasErrors) {
                throwValidationMessage(response);
            } else {
                window.location = response.url;
            }
             
        },

    });
}


function throwValidationMessage(response) {
    //var Message = "";
    //good to have 
    //split messages on seperate lines
    if (response.hasErrors) {
        alert(response.ErrorMessage);
    }
}