(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', '$state', 'authData', 'loginService', 'authenticationService'];
    function rootController($scope, $state, authData, loginService, authenticationService) {
        $scope.logout = function () {
            loginService.logOut();
            $state.go('login');
        };
        //authenticationService.init();
        $scope.authentication = authData.authenticationData;
        $scope.sideBar = "/App/shared/views/sideBar.html";
    }
})(angular.module('kimshop'));