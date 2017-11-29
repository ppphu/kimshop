(function (app) {

    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function productCategoryListController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';

        $scope.search = search;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;
        $scope.deleteProductCategory = deleteProductCategory;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProductCategories: JSON.stringify(listId)
                }
            };
            apiService.del('api/productcategory/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa không?').then(function () {
                var config = {
                    params: { id: id }
                };
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                });
            });
        }

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = { params: { keyword: $scope.keyword, page: page, pageSize: 10 } };
            $scope.loading = true;
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                }
                //else {
                //    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi!');
                //}
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