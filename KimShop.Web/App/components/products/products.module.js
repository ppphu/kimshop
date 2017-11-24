﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop.products', ['kimshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: '/App/components/products/productListView.html',
            controller: 'productListController'
        }).state('product_add', {
            url: '/product_add',
            templateUrl: '/App/components/products/productAddView.html',
            controller: 'productAddController'
        });
    }
})();