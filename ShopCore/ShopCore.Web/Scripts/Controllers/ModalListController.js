webApp.controller('ModalListController', ['$scope', '$uibModalInstance', 'list', function ($scope, $uibModalInstance, list) {
    $scope.list = jQuery.extend({}, list);

    $scope.modalHeader = list ? 'Update list' : 'Create list';
    $scope.ok = function () {
        $uibModalInstance.close($scope.list);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.length = 12;
    $scope.$watch('list.Name', function (newValue) {
        if (newValue && newValue.length > 12) {
            $scope.list.Name = newValue.substring(0, 12);
        }

        if (newValue != undefined) {
            $scope.length = 12 - newValue.length;
        }
    });
}]);