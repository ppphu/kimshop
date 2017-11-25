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
        $stateProvider.state('home', {
            url: '/Admin',
            templateUrl: '/App/components/home/homeView.html',
            controller: 'homeController'
        });
        $urlRouterProvider.otherwise('/Admin');
    }
})();