alert(whiteBoard);
whiteBoard.controller('wantedController', ['$scope', '$http', function ($scope, $http) {
    $scope.Src = '/pages/WantedList.htm';
    $scope.wantedList = [];
    alert("initializing");
    var initialize = function () {
        syncWantedList();
    };
    var syncWantedList = function () {
        $http({ method: 'GET', url: '/api/wanted',
            headers: { "Content-Type": "application/json" }
        }).
            success(function (data, status) {
                $scope.wantedList = data;
            }).
            error(function (data, status) {
                return null;
            });
    };
    
    initialize();
    alert("initialized!");
    $scope.getWantedById = function (id) {

    };
    $scope.saveWantedById = function (id) {

    };
    $scope.deleteWantedById = function (id) {

    };
} ]);
