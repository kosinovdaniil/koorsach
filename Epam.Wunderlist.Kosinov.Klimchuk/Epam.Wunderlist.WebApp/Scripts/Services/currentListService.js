webApp.service('currentListService', function () {
    var list;

    return {
        getProperty: function () {
            return list;
        },
        setProperty: function (value) {
            list = value;
        }
    };
});