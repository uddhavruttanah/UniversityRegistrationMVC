function SignIn() {
    var email = $("#email").val();
    var password = $("#password").val();
    var loggingDetails = { Email: email, Password: password };
    $.ajax({
        type: "POST",
        url: "/UniversityLogin/UniversityLogin",
        data: loggingDetails,
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
function throwValidationMessage(response) {
    //var Message = "";
    //good to have 
    //split messages on seperate lines
    if (response.hasErrors) {
        alert(response.ErrorMessage);
    }
}