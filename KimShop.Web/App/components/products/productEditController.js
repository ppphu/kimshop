(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['$scope', '$state','$stateParams', 'apiService', 'notificationService', 'commonService'];
    function productEditController($scope, $state, $stateParams, apiService, notificationService, commonService) {
        $scope.product = {};
        $scope.moreImages = [];

        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.getProductCategories = getProductCategories;

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        };

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });
            };
            finder.popup();
        };

        function getProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }), function (error) {
                notificationService.displayError(error.data);
            };
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật!');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công!');
            });
        }

        function getProductCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get product category list.');
            });
        }

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });
            };
            finder.popup();
        };

        getProductDetail();
        $scope.getProductCategories();
    }
})(angular.module('kimshop.products'));