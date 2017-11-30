/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop',
        [
            'kimshop.products',
            'kimshop.product_categories',
            'kimshop.common'
        ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/App/shared/views/baseView.html',
                abstract: true
            })
            .state('login', {
                url: '/login',
                templateUrl: '/App/components/login/loginView.html',
                controller: 'loginController'
            })
            .state('home', {
                url: '/Admin',
                parent: 'base',
                templateUrl: '/App/components/home/homeView.html',
                controller: 'homeController'
            });
        $urlRouterProvider.otherwise('/login');
    }
})();