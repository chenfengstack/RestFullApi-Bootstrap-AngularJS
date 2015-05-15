//定义服务newServices
var newServices = angular.module("newServices", ['ngResource']);

//使用工厂模式创建News服务对象，并在app.js中申明可注入
//$resource 为封装的$http.get .post .put类，默认支持query/get/save/delete/remove,调用方式为：
//News.[query/get/save/delete/remove]([paramers],[success],[error])
newServices.factory("News", function ($resource) {
    return $resource(options.baseUrl + "/news/:id", {}, {  
        update: { method: "PUT" }
    });
});