webApp.controller('ModalUserController', ['$scope', 'user', '$uibModalInstance', 'Upload', function ($scope, user, $uibModalInstance, Upload) {
    $scope.user = jQuery.extend({}, user);

    $scope.ok = function () {
        $scope.user.PhotoPath = $scope.user.PhotoPath + '?' + new Date().getTime();
        $uibModalInstance.close($scope.user);
    };

    // upload on file select or drop
    $scope.upload = function (file) {
        if ($scope.form.file.$valid && $scope.file) {
            Upload.upload({
                url: '/Home/UploadFile',
                data: { file: file }
            }).then(function (resp) {
                $scope.user.PhotoPath = resp.data.FileName;
            });
        }
        else {
            if (!$scope.form.file.$valid)
                alert('Only JPEG/PNG/GIF/SVG image can be uploaded');
        }
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.length = 12;
    $scope.$watch('user.Name', function (newValue) {
        if (newValue && newValue.length > 12) {
            $scope.user.Name = newValue.substring(0, 12);
        }

        if (newValue != undefined) {
            $scope.length = 12 - newValue.length;
        }
    });
}]);