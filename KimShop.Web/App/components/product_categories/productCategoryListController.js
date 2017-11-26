(function (app) {

    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';

        function getProductCategories(page) {
            page = page || 0;
            var config = { params: { keyword:$scope.keyword, page: page, pageSize: 10 } }
            $scope.loading = true;
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('Load product category fail.!');
                $scope.loading = false;
            });
        }
        $scope.getProductCategories();
    } 
})(angular.module('kimshop.product_categories'));