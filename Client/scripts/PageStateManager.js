PageStateManager = (function () {
    var viewModels = {};

    var changePage = function (url, viewModel) {
        $.mobile.changePage(url, {viewModel: viewModel});
    };

    var registerViewModel = function (viewModelName, viewModel) {
        viewModels[viewModelName] = viewModel;
    };

    var initPage = function(page, newViewModel) {
        var viewModelName = page.attr("data-viewmodel");

        if (viewModelName) {
            if (newViewModel) {
                registerViewModel(viewModelName, newViewModel);
            }

            // get view model object
            var viewModel = viewModels[viewModelName];

            // apply bindings if they are not yet applied
            if (!ko.dataFor(page[0])) {
                ko.applyBindings(viewModel, page[0]);
            }
        }
    };

    var onPageChange = function (e, info) {
        initPage(info.toPage, info.options.viewModel);
    };

    $(document).bind("pagechange", onPageChange);
    
    return {
        changePage: changePage,
        initPage: initPage
    };
})();