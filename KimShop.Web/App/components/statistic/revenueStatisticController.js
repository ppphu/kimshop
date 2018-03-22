(function (app) {
    app.controller('revenueStatisticController', revenueStatisticController);

    revenueStatisticController.$inject = ['$scope', '$filter', 'apiService', 'notificationService'];

    function revenueStatisticController($scope, $filter, apiService, notificationService) {

        $scope.tabledata = [];
        $scope.chartdata = [];
        $scope.labels = [];
        $scope.series = ['Doanh số', 'Lợi nhuận'];
        

        function getStatistic() {
            var config = {
                param: {
                    //mm/dd/yyyy
                    fromDate: '01/01/2016',
                    toDate: '05/05/2018'
                }
            };
            apiService.get('api/statistic/getRevenue?fromDate=' + config.param.fromDate + '&toDate=' + config.param.toDate, null, function (response) {
                $scope.tabledata = response.data;

                var labels = [];
                var chartData = [];
                var revenues = [];
                var benefits = [];

                $.each(response.data, function (i, item) {
                    labels.push($filter('date')(item.Date, 'dd/MM/yyyy'));
                    revenues.push(item.Revenues);
                    benefits.push(item.Benefit);
                });
                
                chartData.push(revenues);
                chartData.push(benefits);

                $scope.chartdata = chartData;
                $scope.labels = labels;

            }, function (response) {
                notificationService.displayError('Không thể tải dữ liệu');
            });
        }

        getStatistic();
    }
})(angular.module('kimshop.statistic'));