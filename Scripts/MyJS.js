$(document).ready(function () {
    $('#datePicker')
        .datepicker({
            autoclose: true,
            format: 'mm/dd/yyyy'
        })
        .on('changeDate', function (e) {
            // Revalidate the date field
            $('#eventForm').formValidation('revalidateField', 'date');
        });

    $('#eventForm').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            name: {
                validators: {
                    notEmpty: {
                        message: 'The name is required'
                    }
                }
            },
            EditBday: {
                validators: {
                    notEmpty: {
                        message: 'The date is required'
                    },
                    EditBday: {
                        format: 'MM/DD/YYYY',
                        message: 'The date is not a valid'
                    }
                }
            }
        }
    });
});

$(document).ready(function () {
    $('#datePicker2' )
        .datepicker({
            autoclose: true,
            format: 'mm/dd/yyyy'
        })
        .on('changeDate', function (e) {
            // Revalidate the date field
            $('#eventForm').formValidation('revalidateField', 'date');
        });

    $('#eventForm').formValidation({
        framework: 'bootstrap',
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            name: {
                validators: {
                    notEmpty: {
                        message: 'The name is required'
                    }
                }
            },
            EditBday: {
                validators: {
                    notEmpty: {
                        message: 'The date is required'
                    },
                    EditBday: {
                        format: 'MM/DD/YYYY',
                        message: 'The date is not a valid'
                    }
                }
            }
        }
    });
});