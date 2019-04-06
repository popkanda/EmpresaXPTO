$.validator.setDefaults({

    highlight: function (el) {
        $(el).closest('.form-group')
            .find('input, label, select, textarea, span')
            .addClass('is-invalid');
    },

    unhighlight: function (el) {
        $(el).closest('.form-group')
            .find('input, label, select, textarea, span')
            .removeClass('is-invalid');
    }

});