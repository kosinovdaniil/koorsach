webApp.factory('UsersRest', ['$resource', function ($resource) {
    return $resource('api/users/', {}, {
        query: { method: 'GET', params: {}, isArray: true },
        get: { method: 'GET', url: 'api/users/:userId' },
        update: { method: 'PUT', params: {} }
    });
}]);