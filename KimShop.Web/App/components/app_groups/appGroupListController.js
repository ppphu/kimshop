(function (app) {

    app.controller('appGroupListController', appGroupListController);

    appGroupListController.$inject = ['$scope', '$ngBootbox', '$filter', 'apiService', 'notificationService'];

    function appGroupListController($scope, $ngBootbox, $filter, apiService, notificationService) {
        $scope.appGroups = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getAppGroups = getAppGroups;
        $scope.keyword = '';

        $scope.search = search;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;
        $scope.deleteAppGroup = deleteAppGroup;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedAppGroups: JSON.stringify(listId)
                }
            };
            apiService.del('api/appgroup/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.appGroups, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.appGroups, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("appGroups", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteAppGroup(id) {
            $ngBootbox.confirm('Bạn có muốn xóa không?').then(function () {
                var config = {
                    params: { id: id }
                };
                apiService.del('api/appGroup/delete', config, function () {
                    notificationService.displaySuccess('Đã xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                });
            });
        }

        function search() {
            getAppGroups();
        }

        function getAppGroups(page) {
            page = page || 0;
            var config = { params: { keyword: $scope.keyword, page: page, pageSize: 10 } };
            $scope.loading = true;
            apiService.get('api/appgroup/getlistpaging', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                }
                $scope.appGroups = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('Load application groups fail.!');
                $scope.loading = false;
            });
        }
        $scope.getAppGroups();
    }
})(angular.module('kimshop.app_groups'));