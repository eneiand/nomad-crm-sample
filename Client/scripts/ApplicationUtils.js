var ajax = function (url, user, pass, methodType, options) {
    $.mobile.loading('show', {
        text: 'AJAX-ing...',
        textVisible: true
    });
    
    var optionsIncludingAuthentication = {
        type: methodType,
        dataType: 'json',
        beforeSend: function (xhr) {
            var token = window.btoa(user + ':' + pass);
            xhr.setRequestHeader('Authorization', 'Basic ' + token);
        },
        error: function () {
            alert('Unable to communicate with server...');
        },
        complete: function() {
            $.mobile.loading('hide');
        }
    };

    $.extend(optionsIncludingAuthentication, options);

    $.ajax(url, optionsIncludingAuthentication);
};

var updateViewModel = function(targetObservableViewModel, sourceViewModel) {
    ko.mapping.fromJS(sourceViewModel, targetObservableViewModel);
};