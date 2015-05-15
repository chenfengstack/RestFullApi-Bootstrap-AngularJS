//News服务定义路径为scripte/services/newServices.js

//List页面的controller并注入News服务
routeSpartan.controller("ListCtl", function ($scope, News, $routeParams) {
    var search = $routeParams.s || undefined;
    $scope.news = News.query({ pageSize: 10, search: search });//调用服务查询列表
    $scope.delNew = function (newId) {
        if (confirm("确认删除？")) {
            News.remove({ id: newId },
                function (data) {//success
                    $scope.news = News.query({ pageSize: 10 });
                },
                function (error) {//error
                    alert(error.data.message);
                });
        }
    };  
});
//Create页面的controller并注入News服务
routeSpartan.controller("CreateCtl", function ($scope, News, $location) {
    $scope.new = {};
    $scope.save = function () {
        $scope.hasError = false;
        News.save($scope.new,//调用服务保存
            function (data, status) {//success
                $location.path("list");
            },
            function (error) {//error
                $scope.hasError = true;
                $scope.message = error.data.message;
            });
    };
});

//Edit页面的controller并注入News服务
routeSpartan.controller("EditCtl", function ($scope, News, $location, $routeParams) {
    var id = $routeParams.id;
    $scope.new = News.get({ id: id });//调用服务查询
    $scope.save = function () {
        $scope.hasError = false;
        News.update({ id: $scope.new.id }, $scope.new,//调用服务更新
            function () {//success
                $location.path("list");
            },
            function (error) {//error
                $scope.hasError = true;
                $scope.message = error.data.message;
            });
    };
})