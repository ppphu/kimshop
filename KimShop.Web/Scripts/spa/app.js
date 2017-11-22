/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("schoolController", schoolController);
myApp.controller("studentController", studentController);
myApp.controller("teacherController", teacherController);

myController.$inject = ['$scope'];

// Declare
function schoolController($scope)
{
    $scope.message = "Anountment from school.!";
}

// Declare
function studentController($scope) {
    //$scope.message = "This is my message from student controller!";
}

// Declare
function teacherController($scope) {
    //$scope.message = "This is my message from teacher controller!";
}