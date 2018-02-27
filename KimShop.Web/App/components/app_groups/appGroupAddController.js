(function (app) {
    'use strict';

    app.controller('appGroupAddController', appGroupAddController);

    appGroupAddController.$inject = ['$scope','$location', 'apiService', 'notificationService', 'commonService'];

    function appGroupAddController($scope, $location, apiService, commonService, notificationService) {
        $scope.group = {
            ID: 0,
            Roles: []
        };

        $scope.AddAppGroup = AddAppGroup;

        function AddAppGroup() {
            apiService.post('/api/appgroup/add', $scope.group, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được thêm mới.');

            $location.url('app_groups');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        function loadRoles() {
            apiService.get('/api/approle/getlistall',
                null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });
        }

        loadRoles();
    }
})(angular.module('kimshop.app_groups'));