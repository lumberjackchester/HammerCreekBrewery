'use strict';

/* Controllers */

var hammercreekApp = angular.module('hammercreekApp', []);

hammercreekApp.controller('BeerMenuCtrl', function ($scope, $http) {
    $http.get('api/BeerMenu/GetBeerMenu').success(function (data) {
        $scope.allBeer = data.AllBeer;
        $scope.locations = data.AllLocations;
    });
   // $scope.orderProp = 'LocationName';

});