/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop.app_groups', ['kimshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('app_groups', {
            url: '/app_groups',
            parent: 'base',
            templateUrl: '/App/components/app_groups/appGroupListView.html',
            controller: 'appGroupListController'
        })
            .state('add_app_group', {
                url: '/add_app_group',
                parent: 'base',
                templateUrl: '/App/components/app_groups/appGroupAddView.html',
                controller: 'appGroupAddController'
            })
            .state('edit_app_group', {
                url: '/edit_app_group/:id',
                parent: 'base',
                templateUrl: '/App/components/app_groups/appGroupEditView.html',
                controller: 'appGroupEditController'
            });
    }
})();