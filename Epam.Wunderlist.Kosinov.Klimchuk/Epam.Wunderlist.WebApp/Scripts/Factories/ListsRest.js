webApp.factory('ListsRest', ['$resource', function ($resource) {
    return $resource('api/lists/', {}, {
        query: { method: 'GET', url: 'api/users/:userId/lists', isArray: true },
        get: { method: 'GET', url: 'api/lists/listId' },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/lists/:listId' }
    });
}]);