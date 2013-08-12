'use strict';

angular.module('whiteBoard', ['whiteBoard.services', 'whiteBoard.directives'])
    .config(['$routeProvider', function($routeProvider) {
        $routeProvider.
            when('/api/values', { templateUrl: '' }).
            otherwise({ redirectTo: '/' });
    }]);