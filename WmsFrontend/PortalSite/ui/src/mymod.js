/**
  扩展一个自定义模块
**/

layui.define(function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);
    var obj = {
        //测试自定义模块
        hello: function (str) {
            alert('Hello ' + (str || 'mymod'));
        },
        //系统名称配置
        appname_enduser: "广州卷烟厂WMS管理系统",
        appname_developer: "自动化仓储物流系统",
        //全局配置API的服务地址
        apiurl: "",
        apiurl_remote: "http://127.0.0.1:18080",
        apiurl_remoteinf: "http://127.0.0.1:18081",
        kanban: "http://127.0.0.1:8088/KBUI/index.html?id=1",
        zabbix: "http://192.168.1.106/zabbix/"
    };

    //输出自定义模块接口
    exports('mymod', obj);
});