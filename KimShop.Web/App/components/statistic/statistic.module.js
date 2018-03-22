/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kimshop.statistic', ['kimshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('statistic', {
            url: '/statistic',
            parent: 'base',
            templateUrl: '/App/components/statistic/revenueStatisticView.html',
            controller: 'revenueStatisticController'
        });
    }
})();