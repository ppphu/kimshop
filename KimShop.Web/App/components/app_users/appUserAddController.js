(function (app) {
    'use strict';

    app.controller('appUserAddController', appUserAddController);

    appUserAddController.$inject = ['$scope', '$location', 'apiService', 'commonService', 'notificationService'];

    function appUserAddController($scope, $location, apiService, commonService, notificationService) {
        $scope.account = {
            AppGroups: []
        };

        $scope.addAccount = addAccount;

        function addAccount() {
            apiService.post('api/appUser/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.Name + ' đã được thêm mới.');

            $location.url('app_users');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function loadGroups() {
            apiService.get('api/appGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                });
        }

        loadGroups();
    }
})(angular.module('kimshop.app_users'));