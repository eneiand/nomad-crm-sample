﻿var ViewPageViewModel = function(server, user, password, customer) {
    this.customer = customer;
    this.newNote = ko.observable();
    
    this.editCustomer = function () {
        PageStateManager.changePage('EditPage.html', new EditPageViewModel(server, user, password, this.customer));
    };

    this.addNote = function () {
        var newNote = {
            Content: this.newNote(),
            CustomerId: this.customer.CustomerId
        };
        
        ajax(server + '/api/notetocustomer/', user, password, 'POST', {
            contentType: 'application/json; charset=utf-8',
            data: ko.mapping.toJSON(newNote),
            success: function (result) {
                updateViewModel(customer, result['ViewModel']);
            }
        });

        this.newNote("");
    };
}