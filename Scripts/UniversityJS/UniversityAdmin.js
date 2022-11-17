//function getStudents() {
//    return new Promise((resolve, reject) => {
//        $.ajax({
//            type: "GET",
//            url: "/UniversityAdmin/UniversityAdmin",
//            datatype: "json",
//            success: function (data) {
//                if (data != null) {
//                    resolve(JSON.parse(data));
//                }
//            },
//            error: function (error) {
//                reject("No Students");
//            }
//        });
//    });
//}
//function fillTables() {
//    getStudents().then((response) => {
//        if (response != null) {
//            $("#table-rows").empty();
//            topStudentCounter = 0;
//            $.each(response, function (key, value) {
//                let studentDetail = value;
//                let studentRow = document.createElement("tr");
//                let studentId;
//                $.each(Object.keys(studentDetail), function (key, value) {
//                    studentId = studentDetail["studentid"];
//                    studentData.textContent = studentDetail[value];
//                    studentRow.append(studentData);
//                });
//                $("#table-rows").append(studentRow);
//            });
//        }
//    }).catch((error) => {
//        console.log("eroor");
//        toastr.error(error);
//    });
//}
