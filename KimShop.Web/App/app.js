/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop',
        [
            'kimshop.products',
            'kimshop.app_groups',
            'kimshop.app_roles',
            'kimshop.app_users',
            'kimshop.product_categories',
            'kimshop.statistic',
            'kimshop.common'
        ])
        .config(config)
        .config(configAuthentication);

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

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();