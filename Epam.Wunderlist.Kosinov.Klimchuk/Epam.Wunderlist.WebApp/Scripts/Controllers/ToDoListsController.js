webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'currentListService', '$uibModal', 'descriptionService', function ($scope, ListsRest, currentListService, $uibModal, descriptionService) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        switchList(data[0]);

    });
    //ListsRest.save();

    $scope.showItems = function (list) {
        switchList(list);
    };

    function switchList(list) {
        if (descriptionService.isChanged()) {
            $scope.$broadcast('itemChanged', descriptionService.getProperty());
        }
        $scope.$broadcast('listClicked', list);
        if (currentListService.getProperty()) {
            $('#list-' + currentListService.getProperty().Id).css('background', 'white');
        }
        
        currentListService.setProperty(list);
        $scope.tempList = list;
        
    };

    $scope.openListModal = function (list) {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'createList.html',
            controller: 'ModalListController',
            size: 'sm',
            resolve: {
                list: function () {
                    return list;
                }
            }
        });

        modalInstance.result.then(function (list) {
            if (list.Name) {
                if (list.Id) {
                    ListsRest.update({}, list,
                       function (data) {
                           console.log(data);
                           switchList(list);
                       });
                    var x = $scope.toDoLists.findIndex(function (temp) { return temp.Id == list.Id; });
                    $scope.toDoLists[x] = list;
                    //console.log(y);
                }
                else {
                    ListsRest.save({}, { Name: list.Name, Users: [{ Id: userId }] },
                        function (data) {
                            console.log(data);
                            $scope.toDoLists.push(data);
                            switchList(data);
                        });

                }
            }
        });
    };

    $scope.deleteList = function (list) {
        ListsRest.delete({ listId: list.Id }, function () {
            console.log(list.Id + 'deleted');
            console.log($scope.toDoLists.splice($scope.toDoLists.indexOf(list), 1));
            if (currentListService.getProperty() == list) {
                $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
                    switchList(data[0]);
                });
            }
            if ($scope.toDoLists == false) { //sic!
                switchList(null);
            }
            $scope.listHidden = true;
        });

    };
    $scope.listHidden = true;

    $scope.toggleHiddenList = function (id) {
        if ($scope.listHidden) {
            $('#list-buttons-' + id).fadeIn(100);
            $scope.listHidden = false;
        }
        else {
            $('#list-buttons-' + id).fadeOut(100);
            $scope.listHidden = true;
        }
    };


}]);