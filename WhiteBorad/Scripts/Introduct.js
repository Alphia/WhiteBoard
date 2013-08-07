function IntroductionController($scope, $http) {

    $http.get('api/person').success(function (data) {
        $scope.persons = data;
    });
    $scope.AddAction = function () {
        var person = {
            "Name": $scope.name,
            "Description": $scope.description
        };
        if ($scope.name == null || $scope.description == null) {
            alert("fill the blanks");
            return;
        }
        $http.post('api/person', person).success(function () {
            $scope.name = "";
            $scope.description = "";
            $scope.persons.push(person);
        });
    };

    $scope.Edit = function (person) {
        person.mode = 'edit';
    };

    $scope.Save = function (person) {
        $http.put('api/person', person).success(function () {
            person.mode = 'show';
        });

    };

};