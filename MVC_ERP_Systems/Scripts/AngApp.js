var app = angular.module("AngApp", ['ui.bootstrap']);


app.controller("EmpsController", function ($scope, $http) {

    $scope.maxsize = 5;
    $scope.totalcount = 0;
    $scope.pageIndex = 1;
    $scope.pageSize = 5;

    $scope.registerlist = function () {

        $http.get("/Home/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {


            $scope.registerdata = response.data.registerdata;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {

            alert('failed');

        });
    }


    $scope.registerlist();


    $scope.pagechanged = function () {

        $scope.registerlist();
    }


    $scope.changePageSize = function () {

        $scope.pageIndex = 1;

        $scope.registerlist();
    }
});
