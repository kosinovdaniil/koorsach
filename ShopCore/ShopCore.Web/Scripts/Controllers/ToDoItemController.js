webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'descriptionService', 'currentListService', '$timeout', function ($scope, ItemsRest, descriptionService, currentListService, $timeout) {

    $scope.animating = false;

    $scope.addToDoItem = function () {
        if (currentListService.getProperty()) {


            if ($scope.todoText) {
                ItemsRest.save({ listId: currentListService.getProperty().Id },
                    { Text: $scope.todoText, IsCompleted: false, IsFavourited: false, DateAdded: new Date(), List: { Id: currentListService.getProperty().Id } },
                    function (data) {
                        console.log(data);
                        //$scope.toDoItems.push(data);
                        $scope.notCompletedItems.push(data);
                        $('#item-' + data.Id).fadeIn('300ms');
                    });
            }
            $scope.todoText = '';
        }
        else {
            $timeout(function () {
                alert('Create list first!');
            });
        }

    };

    $scope.toggleCompleted = function (item) {

        var update = function () {
            if (item.IsCompleted) {
                var index = $scope.completedItems.indexOf(item);
                item.IsCompleted = !item.IsCompleted;
                $scope.notCompletedItems.push(item);
                $scope.completedItems.splice(index, 1)
            } else {
                var index = $scope.notCompletedItems.indexOf(item);
                item.IsCompleted = !item.IsCompleted;
                $scope.completedItems.push(item);
                $scope.notCompletedItems.splice(index, 1)
            }

            ItemsRest.update({},
                { Id: item.Id, IsCompleted: item.IsCompleted },
                function (data) {
                    console.log(data);
                });
        }
        $scope.animating = true;
        $('#item-' + item.Id).fadeOut('100ms', update);
        $scope.animating = false;
    };

    $scope.deleteItem = function (item) {
        if (!$scope.animating) {
            var del = function () {
                ItemsRest.delete({ itemId: item.Id }, function (data) {
                    console.log(item.Id + 'deleted');
                    if (item.IsCompleted) {
                        $scope.completedItems.splice($scope.completedItems.indexOf(item), 1);
                    }
                    else {
                        $scope.notCompletedItems.splice($scope.notCompletedItems.indexOf(item), 1);
                    }
                    if (item == descriptionService.getProperty()) {
                        descriptionService.closeDescription();
                    }
                    $scope.animating = false;
                });
            }
            $scope.animating = true;
            $('#item-' + item.Id).fadeOut('100ms', del);
        }

    };


    $scope.showDescription = function (todo) {
        if (!$scope.animating) {

            //here comes the fail
            if (descriptionService.isChanged()) {
                $scope.$emit('itemChanged', descriptionService.getProperty());
            }
            $scope.tempDate = todo.DateCompletion ? new Date(todo.DateCompletion) : null;

            descriptionService.showDescription(todo);
            $scope.$broadcast('changeTempDate', todo);
        }
    };

    $scope.forceUpdate = function (tempDate) {
        var todo = descriptionService.getProperty();
        todo.DateCompletion = tempDate;
        $scope.$emit('itemChanged', todo);
        $scope.$broadcast('changeTempDate', todo);

    }

    $scope.$on('listClicked', function (event, data) {
        if (descriptionService.isOpen()) {
            descriptionService.closeDescription();
        }
        var list = data;
        if (data) {
            ItemsRest.query({ listId: data.Id }, function (data) {
                $scope.notCompletedItems = [];
                for (var i = 0; i < data.length; i++) {
                    if (!data[i].IsCompleted) {
                        $scope.notCompletedItems.push(data[i]);
                    }
                }
                console.log($scope.notCompletedItems);
                $scope.completedItems = data.filter(function (el) {
                    return $scope.notCompletedItems.indexOf(el) < 0;
                });
                console.log($scope.completedItems);
                $('#list-' + list.Id).css('background', '#ccc');
            });
        }
        else {
            $scope.notCompletedItems = [];
            $scope.completedItems = [];
        }

    });

    $scope.$on('itemChanged', function (event, data) {
        ItemsRest.update({}, data, function (data) {
            console.log(data.Text + ' ' + data.DateCompletion);
        });
    });

    $scope.length = 35;
    $scope.$watch('todoText', function (newValue) {
        if (newValue && newValue.length > 35) {
            $scope.todoText = newValue.substring(0, 35);
        }

        if (newValue != undefined) {
            $scope.length = 35 - newValue.length;
        }
    });

    $scope.models = {
        selected: null
    };
    $scope.onMoved = function (value, event) {
        //console.log('model');
        //for (i = 0; i < $scope.models.lists.length; i++) {
        //    console.log($scope.models.lists[i]);
        //}
        console.log(event);
        console.log($scope.notCompletedItems);
        var index = $scope.notCompletedItems.indexOf(value);
        $scope.notCompletedItems.splice(index, 1);

        //$scope.models.lists.splice($index, 1)
    };

    $scope.itemDropped = function (item, index) {

        item.list = $scope.toDoLists[index];
        console.log(item.list);
        ItemsRest.update({},
           { Id: item.Id, IsCompleted: item.IsCompleted, List: item.list },
           function (data) {
               console.log(data);

           });
        var indexItem = $scope.notCompletedItems.map(function (e) { return e.Id; }).indexOf(item.Id);
        $scope.notCompletedItems.splice(indexItem, 1);
    };

    $scope.lists = []

}]);