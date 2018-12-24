$.validator.unobtrusive.adapters.add('dategreaterthancurrent', ['datetimeformat', 'options'], function (options) {
    options.rules['dategreaterthancurrent'] = { datetimeformat: options.params.datetimeformat, options: options.params.options };
    options.messages['dategreaterthancurrent'] = options.message;
});

$.validator.addMethod("dategreaterthancurrent", function (value, element, param) {
    var currentdate = new Date();
    var Enddate = new Date(value);
    if (value !== '')
        if (param.options === "GREATER")
            return Enddate > currentdate;
        else if (param.options === "EARLIER")
            return Enddate < currentdate;
    return true;
});


$.validator.unobtrusive.adapters.add('dategreaterthan', ['otherpropertyname', 'datetimeformat'], function (options) {
    options.rules['dategreaterthan'] = { otherpropertyname: options.params.otherpropertyname, datetimeformat: options.params.datetimeformat };
    options.messages['dategreaterthan'] = options.message;
});

$.validator.addMethod("dategreaterthan", function (value, element, param) {
    var otherProp = $('#' + param.otherpropertyname);
    if (otherProp.val() !== '') {
        var StartDate = new Date(moment(otherProp.val(), param.datetimeformat));

        var Enddate = new Date(value);
        if (StartDate !== '') {
            return Enddate >= StartDate;
        }
    }
    return true;
});