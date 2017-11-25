﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop.product_categories', ['kimshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: '/product_categories',
            templateUrl: '/App/components/product_categories/productCategoryListView.html',
            controller: 'productCategoryListController'
        });
    }
})();