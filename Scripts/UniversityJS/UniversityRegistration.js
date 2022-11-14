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
    var register = { FirstName: FirstName, LastName: LastName, Email: Email, Password: Password, Address: Address, PhoneNo: PhoneNo, DateofBirth: DateofBirth, GuardianName: GuardianName, NationalID: NationalID };
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