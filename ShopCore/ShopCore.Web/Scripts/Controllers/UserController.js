webApp.controller('UserController', ['$scope', 'UsersRest', '$uibModal', '$http', function ($scope, UsersRest, $uibModal, $http) {

    //$scope.users = UsersRest.query();

    $scope.user = UsersRest.get({ userId: userId });

    //$scope.newUser = UsersRest.update({Id: '1', Name: 'newUser', PhotoPath: '35shgf'});
    $scope.openUserModal = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'updateUser.html',
            controller: 'ModalUserController',
            size: 'lg',
            resolve: {
                user: function () {
                    return $scope.user;
                }
            }
        });


        modalInstance.result.then(function (user) {
            console.log(user);
            if (user.Name) {
                UsersRest.update({}, user,
                   function (data) {
                       console.log(data);
                       $scope.user = user;
                   }
                );
            }
        })
    };

    $scope.userHidden = true;

    $scope.toggleHiddenUser = function () {

        if ($scope.userHidden) {
            $('#user').fadeIn(100);
            $scope.userHidden = false;
        }
        else {
            $('#user').fadeOut(100);
            $scope.userHidden = true;
        }
    };
}]);