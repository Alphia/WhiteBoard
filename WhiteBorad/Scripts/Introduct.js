function IntroductionController($scope, $http) {

    $http.get('api/person').success(function (data) {
        $scope.persons = data;
    });
    $scope.AddAction = function () {
        var person = {
            "Name": $scope.name,
            "Age": $scope.age,
            "Sex": $scope.sex,
            "Hometown": $scope.hometown,
            "Hobby": $scope.hobby
        };
        $scope.persons.push(person);
        $http.post('api/person', person).success(function () {
            $scope.name = "";
            $scope.age = "";
            $scope.sex = "";
            $scope.hometown = "";
            $scope.hobby = "";
        });
    };
};