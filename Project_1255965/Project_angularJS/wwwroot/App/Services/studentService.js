angular.module("courseApp")
    .factory("studentSvc", ($http) => {
        return {
            getStudentWithCourse: () => {
                return $http({
                    method: "GET",
                    url: "/StudentData/StudentsWithCourse",
                    headers: {
                        'Content-Type': "application/json"
                    }
                });
            }
        }
    });