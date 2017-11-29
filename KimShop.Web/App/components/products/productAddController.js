(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'commonService'];

    function productAddController($scope, $state, apiService, notificationService, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        };

        $scope.AddProduct = AddProduct;
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

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm!');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công!');
            });
        }

        function getProductCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get product category list.');
            });
        }

        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });
            };
            finder.popup();
        };

        $scope.getProductCategories();
    }
})(angular.module('kimshop.products'));