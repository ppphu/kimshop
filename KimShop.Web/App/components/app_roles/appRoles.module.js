/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop.app_roles', ['kimshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('app_roles', {
            url: '/app_roles',
            parent: 'base',
            templateUrl: '/App/components/app_roles/appRoleListView.html',
            controller: 'appRoleListController'
        })
            .state('add_app_role', {
                url: '/add_app_role',
                parent: 'base',
                templateUrl: '/App/components/app_roles/appRoleAddView.html',
                controller: 'appRoleAddController'
            })
            .state('edit_app_role', {
                url: '/edit_app_role/:id',
                parent: 'base',
                templateUrl: '/App/components/app_roles/appRoleEditView.html',
                controller: 'appRoleEditController'
            });
    }
})();