'use strict';

/* Controllers */

var hammercreekApp = angular.module('hammercreekApp', []);

hammercreekApp.controller('BeerMenuCtrl', function ($scope) {
    $scope.beerInFridge = [
      {
          'name': 'Nexus S',
          'snippet': 'Fast just got faster with Nexus S.'
      },
      {
          'name': 'Motorola XOOM™ with Wi-Fi',
          'snippet': 'The Next, Next Generation tablet.'
      },
      {
          'name': 'MOTOROLA XOOM™',
          'snippet': 'The Next, Next Generation tablet.'
      }
    ];
});