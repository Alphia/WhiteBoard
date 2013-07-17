whiteBoard.controller('wantedController', ['$scope', '$http', function ($scope, $http) {
    $scope.Src = 'http://localhost:12824/pages/WantedList.htm';
    $scope.wantedList = [];
    var initialize = function () {
        syncWantedList();
    };
    var syncWantedList = function () {
        $http({ method: 'GET', url: 'http://localhost:12824/api/wanted' }).
            success(function (data, status) {
                $scope.wantedList = data;
            }).
            error(function (data,status) {
                return null;
            });
    };
    initialize();
    $scope.getWantedById = function (id) {

    };
    $scope.saveWantedById = function (id) {

    };
    $scope.deleteWantedById = function (id) {

    };
} ]);
