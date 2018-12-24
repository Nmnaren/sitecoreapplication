var dateFormat = "YYYY-MM-DD";
var datetimeFormat = "YYYY-MM-DD hh:mm:ss";
$(function () {
    $('#PolicyEffectiveDate').fdatepicker().on('changeDate', function (ev) {
        var date = moment($('#PolicyEffectiveDate').val(), dateFormat).add(1, 'years').format(dateFormat);
        $('#PolicyExpiryDate').val(date);
    });
    $('#ManufacYear').fdatepicker();
    $('#DOB').fdatepicker();
    $('#EffectiveDate').fdatepicker();
    $('#LicenseExpiryDate').fdatepicker();
});

$(document).ready(function () {
    $('#policyCoverage').on('blur', function () {
        var coverage = $('#policyCoverage').val();
        if (coverage.length > 0) {
            if (parseInt(coverage) > 100000) {
                $('#btnApproval').prop('disabled', false);
                $('#btnApproval').removeClass("disabled");
                $('#btnSubmit').prop('disabled', true);
                $('#btnSubmit').addClass("disabled");
            }
            else {
                $('#btnSubmit').prop('disabled', false);
                $('#btnSubmit').removeClass("disabled");
                $('#btnApproval').prop('disabled', true);
                $('#btnApproval').addClass("disabled")
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
                for (var j = 0; j < data.Color.length; j++) {
                    options += '<option value="' + data.Color[j] + '">' + data.Color[j] + '</option>';
                }
                $('#vehicleColor').append(options);

                $('#transmissionType').html('');
                options = '';
                options += '<option value="Select">Select</option>';
                for (var k = 0; k < data.Transmission.length; k++) {
                    options += '<option value="' + data.Transmission[k] + '">' + data.Transmission[k] + '</option>';
                }
                $('#transmissionType').append(options);

                $('#vehicleType').html('');
                options = '';
                options += '<option value="Select">Select</option>';
                for (var l = 0; l < data.Class.length; l++) {
                    options += '<option value="' + data.Class[l] + '">' + data.Class[l] + '</option>';
                }
                $('#vehicleType').append(options);
            },
            error: function (error) {
                console.log(error);
            }

        });
    }); 
});

