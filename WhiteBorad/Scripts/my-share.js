function ShareController($scope, $http) {
    $scope.add = function () {
        //var input = {Name: "test"};
        //console.log($scope.share);
        var input = { Name: $scope.share };
        $http.post('/api/Share', input).success(function (data, status, headers, config) {
            //$scope.share = "sucess"; // assign  $scope.persons here as promise is resolved here
            //$scope.share = "";
            $http.get('/api/Share').success(function (data) {
                //console.log("dta2: ", data);
                $scope.Shared = data;
            });
        }).error(function (data, status, headers, config) {
            $scope.share = "error";
        });
    };
    $scope.show = function () {
        $http.get('/api/Share').success(function (data) {
            //console.log("dta2: ", data);
            //$scope.Shared = "The share is:";
            $scope.Shared = data;
        });
    };
};