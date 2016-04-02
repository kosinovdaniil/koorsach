webApp.service('descriptionService', function () {
    var todo;

    return {
        getProperty: function () {
            return todo;
        },
        setProperty: function (value) {
            todo = value;
        },
        initialProperty: null,
        isOpen: function () {
            return todo != null;
        },
        isChanged: function () {
            return this.initialProperty && JSON.stringify(this.initialProperty) != JSON.stringify(todo);
        },
        closeDescription: function () {
            this.initialProperty = null;
            $('.item-info').css('display', 'none');
            
            $("#main").animate({ width: '75%' }, 300);

            this.setProperty(null);
        },
        showDescription: function (value) {
            this.initialProperty = jQuery.extend({}, value);
            $('.item-info').css('display', 'block');
            if (!this.isOpen()) {
                $('.close-icon').css('display', 'none');
                $("#main").animate({ width: '50%' }, 300, '', function () { $(".close-icon").fadeIn('1000ms'); });
            }

            this.setProperty(value);
        },
        tempDate: null
    };
});

