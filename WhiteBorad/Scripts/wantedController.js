﻿
whiteBoard.controller('wantedController', ['$scope', '$http', function ($scope, $http) {
    $scope.Src = 'http://localhost:12824/pages/WantedList.htm';
    $scope.wantedList = [];
    
    var initialize = function () {
        syncWantedList();
    };
    var syncWantedList = function () {
        $http({ method: 'GET', url: '/api/wanted',
            headers: { "Content-Type": "application/json" }
        })
            .success(function (data, status) {
                $scope.wantedList = data;
            })
            .error(function (data, status) {
                return null;
            });
    };
    initialize();
    $scope.getWantedById = function (id) {

    };
    $scope.saveWantedById = function () {

    };
    $scope.deleteWantedById = function (id) {

    };
} ]);
