var SearchPageViewModel = function(server, user, password) {
    this.customerArray = ko.observableArray([]);
    
    ajax(server + '/api/customers/', user, password, 'GET', {
        context: this,
        success: function (data) {
            var mappedData = $.map(data, function(item) {
                var fromJs = ko.mapping.fromJS(item);
                fromJs['Notes'] = ko.observable(item['Notes']);
                fromJs['DisplayName'] = ko.computed(function() {
                    return fromJs.FirstName() + ' ' + fromJs.SecondName();
                });
                return fromJs;
            });
            
            this.customerArray(mappedData);
        }
    });

    this.SelectedCustomer = ko.observable();
    
    this.viewCustomer = function (customer) {
        PageStateManager.changePage('viewPage.html', new ViewPageViewModel(server, user, password, customer));
    };
};
