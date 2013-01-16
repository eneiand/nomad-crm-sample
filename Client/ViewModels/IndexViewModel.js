var indexViewModel = function () {
    this.userId = ko.observable('admin');

    this.password = ko.observable('password');

    this.server = ko.observable('http://nomad-dtw-crm-sample.azurewebsites.net');

    this.IncorrectLogin = ko.observable(false);

    var resetIncorrectLogin = function () {
        this.IncorrectLogin(false);
    }.bind(this);

    this.userId.subscribe(resetIncorrectLogin);

    this.password.subscribe(resetIncorrectLogin);

    this.DoLogin = function () {
        ajax(this.server() + '/api/Authentication/', this.userId(), this.password(), 'GET', {
            context: this,
            success: function () {
                PageStateManager.changePage('searchPage.html', new SearchPageViewModel(this.server(), this.userId(), this.password()));
            },
            error: function () {
                this.IncorrectLogin(true);
            }
        });
    };
};
