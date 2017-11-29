(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];
    function productCategoryAddController($scope, $state, apiService, notificationService, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        };

        $scope.AddProductCategory = AddProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm!');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công!');
            });
        }

        function loadParentCategory() {
            apiService.get('api/productCategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get parent list.');
            });
        }
        loadParentCategory();
    }
})(angular.module('kimshop.product_categories'));