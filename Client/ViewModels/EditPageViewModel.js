var EditPageViewModel = function (server, user, password, customer) {
    this.customer = customer;

    this.save = function () {
        ajax(server + '/api/customers/', user, password, 'POST', {
            contentType: "application/json; charset=utf-8",
            data: ko.mapping.toJSON(customer),
            success: function(result) {
                updateViewModel(customer, result['ViewModel']);

                history.back();
            }
        });
    };
}