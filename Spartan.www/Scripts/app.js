//基础配置
var options = {};
options.baseUrl = "http://localhost:15943/api";

//定义路由 并注入newServices服务
var routeSpartan = angular.module('routeSpartan', ['ngRoute', 'newServices'], function ($httpProvider) {
    //全局XHR提交的时候 设置头信息
    $httpProvider.defaults.headers.post["Content-Type"] = "application/json";
    $httpProvider.defaults.headers.put["Content-Type"] = "application/json";
    $httpProvider.defaults.headers.common["Content-Type"] = "application/json";
});
routeSpartan.config(['$routeProvider', function ($routeProvider) {
    //设置路由
    $routeProvider
        .when('/list/:s?', {
            templateUrl: '/Views/List.html',//调用页面
            controller: 'ListCtl'//对应的controller方法
        })
        .when("/edit/:id", {
            templateUrl: '/Views/Edit.html',
            controller: 'EditCtl'
        })
        .when("/create", {
            templateUrl: '/Views/Edit.html',
            controller: 'CreateCtl'
        })
        .otherwise({   //如果都不能匹配则默认跳转到list
            redirectTo: '/list'
        });
}]);