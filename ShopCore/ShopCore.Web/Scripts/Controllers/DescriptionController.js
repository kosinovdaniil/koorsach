webApp.controller('DescriptionController', ['$scope', 'descriptionService', function ($scope, descriptionService) {

    $scope.getTodo = function () {
        return descriptionService.getProperty();
    }

    $scope.$on('changeTempDate', function (event, data) {      
        $scope.tempDate = data.DateCompletion ? new Date(data.DateCompletion) : null;
    });

    $scope.closeDescription = function () {

        descriptionService.getProperty().DateCompletion = $scope.tempDate;
        if (descriptionService.isChanged()) {
            $scope.$emit('itemChanged', descriptionService.getProperty());
        }
        $scope.tempDate = null;
        descriptionService.closeDescription();

    };

    $scope.openCalendar = function () {
        $scope.popup.opened = true;
    };

    $scope.popup = {
        opened: false
    };
}]);