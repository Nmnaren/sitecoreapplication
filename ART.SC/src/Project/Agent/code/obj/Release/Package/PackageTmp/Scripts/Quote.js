var dateFormat = "YYYY-MM-DD";
var datetimeFormat = "YYYY-MM-DD hh:mm:ss";
$(function () {
    $('#PolicyEffectiveDate').fdatepicker().on('changeDate', function (ev) {
        var date = moment($('#PolicyEffectiveDate').val(), dateFormat).add(1, 'years').format(dateFormat);
        $('#PolicyExpiryDate').val(date);
    });
    $('#ManufacYear').fdatepicker();
    $('#DOB').fdatepicker();
    $('#LicenseEffectiveDate').fdatepicker();
    $('#LicenseExpiryDate').fdatepicker();
});

(function () {

    validate.extend(validate.validators.datetime, {
        // The value is guaranteed not to be null or undefined but otherwise it
        // could be anything.
        parse: function (value, options) {
            return +moment.utc(value);
        },
        // Input is a unix timestamp
        format: function (value, options) {
            var format = options.dateOnly ? dateFormat : datetimeFormat;
            return moment.utc(value).format(format);
        }
    });
    var constraints = {
        "PolicyDetails.PolicyEffectiveDate": {
            presence: true
        },
        "PolicyDetails.CoverageAmount": {
            presence: true
        },
        VehicleMake: {
            presence: true
        },
        RegistrationNumber: {
            presence: true
        },
        VehicleModel: {
            presence: true
        },
        VehicleUsage: {
            presence: true
        },
        ManufactureYear: {
            presence: true
        },
        TransmissionType: {
            presence: true
        },
        FirstName: {
            presence: true
        },
        LastName: {
            presence: true
        },
        Birthdate: {
            presence: true,
            date: {
                latest: moment().format(dateFormat),
                message: "Birth date cannot be future date"
            }
        },
        ZipCode: {
            presence: true
        },
        City: {
            presence: true
        },
        LicenseNumber: {
            presence: true
        },
        PlaceOfIssue: {
            presence: true
        },
        EffectiveDate: {
            presence: true,
            date: {
                earliest: moment().format(dateFormat),
                message: "^Effective date should not be earlier than curent date"
            }
        },
        ExpiryDate: {
            presence: true,
            date: {
                earliest: moment().format(dateFormat),
                message: "^Expiry date should not be earlier than curent date"
            }
        }
    };

    // Hook up the form so we can prevent it from being posted

    function handleFormSubmit(form) {
        // First we gather the values from the form
        var values = validate.collectFormValues(form);
        // then we validate them against the constraints
        var errors = validate(values, constraints);
        // then we update the form to reflect the results
        showErrors(form, errors || {});
        // And if all constraints pass we let the user know
        if (!errors) {
            return true;
        }
        return true;
    }

    // Updates the inputs with the validation errors
    function showErrors(form, errors) {
        // We loop through all the inputs and show the errors for that input
        jQuery('.form-error').html('');
        _.each(form.querySelectorAll("input[name], select[name]"), function (input) {
            // Since the errors can be null if no errors were found we need to handle
            // that
            showErrorsForInput(input, errors && errors[input.name]);
        });
    }

    // Shows the errors for a specific input
    function showErrorsForInput(input, errors) {
        // This is the root of the input
        var formGroup = closestParent(input.parentNode, "form-group")
        // Find where the error messages will be insert into
        messages = formGroup.querySelector(".form-error");
        // First we remove any old messages and resets the classes
        resetFormGroup(input);
        // If we have errors

        if (errors) {
            // we first mark the group has having errors
            messages.classList.add("is-visible");
            input.classList.add("is-invalid-input");
            // then we append all the errors
            _.each(errors, function (error) {
                addError(messages, error);
            });
        } else {
            // otherwise we simply mark it as success
            input.classList.add("has-success");
        }
    }

    // Recusively finds the closest parent that has the specified class
    function closestParent(child, className) {
        if (!child || child == document) {
            return null;
        }
        if (child.classList.contains(className)) {
            return child;
        } else {
            return closestParent(child.parentNode, className);
        }
    }

    function resetFormGroup(formGroup) {
        // Remove the success and error classes
        formGroup.classList.remove("is-invalid-input");
        formGroup.classList.remove("has-success");
        // and remove any old messages
        _.each(formGroup.querySelectorAll(".help-block.error"), function (el) {
            el.parentNode.removeChild(el);
        });
    }

    // Adds the specified error with the following markup
    // <p class="help-block error">[message]</p>
    function addError(messages, error) {
        var block = document.createElement("p");
        block.classList.add("help-block");
        block.classList.add("error");
        block.innerHTML = error;
        messages.appendChild(block);
    }

    window.onload = function () {
        document.querySelector("form#main")
            .addEventListener("submit", function (ev) {
                if (!handleFormSubmit(this))
                    ev.preventDefault();
            });
    }

})();
$(document).ready(function () {
    $('#policyCoverage').on('blur', function () {
        var coverage = $('#policyCoverage').val();
        if (coverage.length>0)
        {
            if (parseInt(coverage) > 100000) {
                $('#btnApproval').prop('disabled', false);
                $('#btnApproval').removeClass("disabled")
            }
            else {
                $('#btnSubmit').prop('disabled', false);
                $('#btnSubmit').removeClass("disabled")
            }

        }
       
    });

    $('#vehicleMake').on("change", function () {
        var vehicle = $('#vehicleMake').val();
        $.ajax({
            type: "GET",
            url: "/api/feature/quote/getmotorvehcledetails",
            data: { makeType: vehicle },
            success: function (response) {
                var data = response;
                var options = '';

                $('#vehicleModel').html('');
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < data.Models.length; i++) {
                    options += '<option value="' + data.Models[i] + '">' + data.Models[i] + '</option>';
                }
                $('#vehicleModel').append(options);

                $('#vehicleColor').html('');
                options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < data.Color.length; i++) {
                    options += '<option value="' + data.Color[i] + '">' + data.Color[i] + '</option>';
                }
                $('#vehicleColor').append(options);

                $('#transmissionType').html('');
                options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < data.Transmission.length; i++) {
                    options += '<option value="' + data.Transmission[i] + '">' + data.Transmission[i] + '</option>';
                }
                $('#transmissionType').append(options);

                $('#vehicleType').html('');
                options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < data.Class.length; i++) {
                    options += '<option value="' + data.Class[i] + '">' + data.Class[i] + '</option>';
                }
                $('#vehicleType').append(options);
            },
            error: function (error) {
                console.log(error);
            }

        });
    }); 
});

