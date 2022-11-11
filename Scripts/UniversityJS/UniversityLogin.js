function SignIn() {
  //  window.location.href = 'url.Action("UniversitySuccessfulLogin","UniversitySuccessfulLogin")';
    var emailAddress = $("#email").val(); // read email address input
    var password = $("#password").val(); // read password input
    // create object to map LoginModel
    var authObj = { EmailAddress: emailAddress, Password: password };
    $.ajax({
        type: "POST",
        url: "/UniversityLogin/UniversityLogin",
        data: authObj,
        dataType: "json",
        success: function (response) {
            if (response.result) {
               // toastr.success("Authentication Succeed. Redirecting to relevent page.....");
                window.location = response.url;
            }
            else {
               // toastr.error('Unable to Authenticate user');
                return false;
            }
        },
        failure: function (response) {
            //toastr.error('Unable to make request!!');
        },
        error: function (response) {
           // toastr.error('Something happen, Please contact Administrator!!');

        }
    });


}
