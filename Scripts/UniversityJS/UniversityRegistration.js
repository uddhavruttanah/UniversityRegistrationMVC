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
    //var Subject1 = $("#SubjectList1").val();
    //var Grades1 = $("#Grades1").val();
    //var Subject2 = $("#SubjectList2").val();
    //var Grades2 = $("#Grades2").val();
    //var Subject3 = $("#SubjectList3").val();
    //var Grades3 = $("#Grades3").val();

    var Subjects = [];
    Subjects.push = ($("#SubjectList1").val());
    Subjects.push = ($("#SubjectList2").val());
    Subjects.push = ($("#SubjectList3").val());

    var Grades = [];
    Grades.push($("#Grades1").val());
    Grades.push($("#Grades2").val());
    Grades.push($("#Grades3").val());
    var register = { FirstName: FirstName, LastName: LastName, Email: Email, Password: Password, Address: Address, PhoneNo: PhoneNo, DateofBirth: DateofBirth, GuardianName: GuardianName, NationalID: NationalID, SubjectID: Subjects, Grade: Grades };
    $.ajax({
        type: "POST",
        url: "/UniversityStudent/AddStudent",
        data: register,
        dataType: "json",
        success: function (response) {
                window.location = response.url;
        }
    });
}