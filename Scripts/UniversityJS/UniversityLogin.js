﻿function SignIn() {
    var email = $("#email").val();
    var password = $("#password").val();
    var loggingDetails = { Email: email, Password: password };
    $.ajax({
        type: "POST",
        url: "/UniversityLogin/UniversityLogin",
        data: loggingDetails,
        dataType: "json",
        success: function (response) {
            if (response.result) {
                window.location = response.url;
            }
            else {
               toastr.error('Incorrect Email Or Password!!!');
                return false;
            }
        },
    });
}
function SignUp()
{
    $.ajax({
        type: "POST",
        url: "/UniversityLogin/UniversitySignUp",
        dataType: "json",
        success: function (response) {
                window.location = response.url;
        }
    });
}