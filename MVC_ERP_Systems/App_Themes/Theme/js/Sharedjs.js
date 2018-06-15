

var appWithUi = angular.module("AngApp", ['ui.bootstrap']);

function ShowSMEs(o, m) {

    o.empty().show();

    angular.forEach(m, function (value, key) {
        o.append("<div class='alert alert-" + value.Stat + "'>" + value.SEM + "</div>");
    });
};