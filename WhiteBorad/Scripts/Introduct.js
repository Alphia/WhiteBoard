function IntroductionController($scope, $http, $rootScope, uploadManager) {
    $scope.files = [];
    $scope.percentage = 0;

    $http.get('api/person').success(function (data) {
        $scope.persons = data;
    });
    $scope.AddAction = function () {
        var person = {
            "Name": $scope.name,
            "Description": $scope.description,
            "Image": $scope.imagePath
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

    $scope.upload = function () {
        uploadManager.upload();
        $scope.files = [];
    };

    $rootScope.$on('fileAdded', function (e, call) {
        $scope.files.push(call);
        $scope.$apply();
    });

    $rootScope.$on('uploadProgress', function (e, call) {
        $scope.percentage = call;
        $scope.$apply();
    });

    $rootScope.$on('displayImg', function (e, call) {
        $scope.imagePath = "/uploads/" + call;
        $scope.$apply();
    });

};