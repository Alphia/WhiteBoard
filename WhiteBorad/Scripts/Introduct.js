function IntroductionController($scope) {
    $scope.age = 25;
    $scope.action = function () {
        var person = {
            "Name": $scope.name,
            "Age": $scope.age,
            "Sex": $scope.sex,
            "Hometown": $scope.homtown,
            "Hobby": $scope.hobby
        };
        $http.post('api/person/', person).success(alert("success"));
    };
}

