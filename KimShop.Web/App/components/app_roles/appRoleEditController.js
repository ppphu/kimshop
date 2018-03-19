(function (app) {
    'use strict';

    app.controller('appRoleEditController', appRoleEditController);

    appRoleEditController.$inject = ['$scope', '$location', '$stateParams', 'apiService', 'notificationService'];

    function appRoleEditController($scope, $location, $stateParams, apiService, notificationService) {
        $scope.role = {};

        $scope.updateAppRole = updateAppRole;

        function updateAppRole() {
            apiService.put('api/appRole/update', $scope.role, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('api/appRole/detail/' + $stateParams.id, null,
            function (result) {
                $scope.role = result.data;
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được cập nhật thành công.');

            $location.url('app_roles');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        loadDetail();
    }
})(angular.module('kimshop.app_roles'));