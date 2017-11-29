(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'commonService'];
    function productCategoryEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.productCategory = {
            UpdatedDate: new Date()
        };

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật!');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công!');
            });
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }), function (error) {
                notificationService.displayError(error.data);
            };
        }

        function loadParentCategory() {
            apiService.get('api/productCategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get parent list.');
            });
        }
        loadParentCategory();
        loadProductCategoryDetail();
    }
})(angular.module('kimshop.product_categories'));