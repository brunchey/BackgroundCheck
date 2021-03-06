﻿/// <reference path="Scripts/angular.js" />
/// <reference path="Scripts/angular-route.js" />


var backgroundCheckApp = angular.module('backgroundCheckApp', [
    'ngRoute']
);

backgroundCheckApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'applicantsController',
                templateUrl: '../../app/views/applicantList.html'
            })
            .when('/applicant/:Id', {
                controller: 'applicantController',
                templateUrl: '../../app/views/applicantDetail.html'
            })
            .when('applicant/add', {
                controller: 'applicantController',
                templateUrl: '../../app/views/applicantDetail.html'
            });
    }]);


