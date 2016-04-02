webApp.factory('ItemsRest', ['$resource', function ($resource) {
    return $resource('api/items/', {}, {
        query: { method: 'GET', url: 'api/lists/:listId/items', isArray: true },
        get: { method: 'GET', url: 'api/items/:itemId' },
        save: { method: 'POST', url: 'api/lists/:listId/items' },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/items/:itemId' }
    });
}]);