/**

 @Name：全局配置
 @Author：贤心
 @Site：http://www.layui.com/admin/
 @License：LPPL（layui付费产品协议）
    
 */

layui.define(['laytpl', 'layer', 'element', 'util', 'mymod'], function (exports) {
    exports('setter', {
        container: 'LAY_app' //容器ID
        , base: layui.cache.base //记录layuiAdmin文件夹所在路径
        , views: layui.cache.base + 'views/' //视图所在目录
        , entry: 'index' //默认视图文件名
        , engine: '.html' //视图文件后缀名
        , pageTabs: true //是否开启页面选项卡功能。单页版不推荐开启

        , name: 'layuiAdmin Pro'
        , tableName: 'layuiAdmin' //本地存储表名
        , MOD_NAME: 'admin' //模块事件名

        , debug: false //是否开启调试模式。如开启，接口异常时会抛出异常 URL 等信息

        , interceptor: true //是否开启未登入拦截

        //自定义请求字段
        , request: {
            tokenName: 'access_token' //自动携带 token 的字段名。可设置 false 不携带。
        }

        //自定义响应字段
        , response: {
            statusName: 'code' //数据状态的字段名称
            , statusCode: {
                ok: 0 //数据状态一切正常的状态码
                , logout: 1001 //登录状态失效的状态码
            }
            , msgName: 'msg' //状态信息的字段名称
            , dataName: 'data' //数据详情的字段名称
        }

        //独立页面路由，可随意添加（无需写参数）
        , indPage: [
            '/user/login' //登入页 
            , '/template/tips/test' //独立页的一个测试 demo
        ]

        //扩展的第三方模块
        , extend: [
            'echarts', //echarts 核心包
            'echartsTheme' //echarts 主题
        ]

        //主题配置
        , theme: {
            //内置主题配色方案
            color: [{
                main: '#20222A' //主题色
                , selected: '#009688' //选中色
                , alias: 'default' //默认别名
            }, {
                main: '#03152A'
                , selected: '#3B91FF'
                , alias: 'dark-blue' //藏蓝
            }, {
                main: '#2E241B'
                , selected: '#A48566'
                , alias: 'coffee' //咖啡
            }, {
                main: '#50314F'
                , selected: '#7A4D7B'
                , alias: 'purple-red' //紫红
            }, {
                main: '#344058'
                , logo: '#1E9FFF'
                , selected: '#1E9FFF'
                , alias: 'ocean' //海洋
            }, {
                main: '#3A3D49'
                , logo: '#2F9688'
                , selected: '#5FB878'
                , alias: 'green' //墨绿
            }, {
                main: '#20222A'
                , logo: '#F78400'
                , selected: '#F78400'
                , alias: 'red' //橙色
            }, {
                main: '#28333E'
                , logo: '#AA3130'
                , selected: '#AA3130'
                , alias: 'fashion-red' //时尚红
            }, {
                main: '#24262F'
                , logo: '#3A3D49'
                , selected: '#009688'
                , alias: 'classic-black' //经典黑
            }, {
                logo: '#226A62'
                , header: '#2F9688'
                , alias: 'green-header' //墨绿头
            }, {
                main: '#344058'
                , logo: '#0085E8'
                , selected: '#1E9FFF'
                , header: '#1E9FFF'
                , alias: 'ocean-header' //海洋头
            }, {
                header: '#393D49'
                , alias: 'classic-black-header' //经典黑
            }, {
                main: '#50314F'
                , logo: '#50314F'
                , selected: '#7A4D7B'
                , header: '#50314F'
                , alias: 'purple-red-header' //紫红头
            }, {
                main: '#28333E'
                , logo: '#28333E'
                , selected: '#AA3130'
                , header: '#AA3130'
                , alias: 'fashion-red-header' //时尚红头
            }, {
                main: '#28333E'
                , logo: '#009688'
                , selected: '#009688'
                , header: '#009688'
                , alias: 'green-header' //墨绿头
            }]

            //初始的颜色索引，对应上面的配色方案数组索引
            //如果本地已经有主题色记录，则以本地记录为优先，除非请求本地数据（localStorage）
            , initColorIndex: 7
        }

        //开发配置路由路径
        //本地服务即（基础baseapp）
        , userlogin: layui.mymod.apiurl + '/UserService/Login'
        , getuserlist: layui.mymod.apiurl + '/UserService/GetUserList'
        , getrolelist: layui.mymod.apiurl + '/UserService/GetRoleList'
        , postuser: layui.mymod.apiurl + '/UserService/UserRequest'
        , postrole: layui.mymod.apiurl + '/UserService/RoleRequest'
        , getseqlist: layui.mymod.apiurl + '/RestAPIService/SeqQueryParam'
        , getFuncTreeList: layui.mymod.apiurl + '/UserService/GetFuncTreeList'
        , postfile: layui.mymod.apiurl + '/RestAPIService/files/'
        , getreportlist: layui.mymod.apiurl + '/RestAPIService/ReportRequest'
        , getdataitemlist: layui.mymod.apiurl + '/RestAPIService/DtoDataItem'
        , getloginfolist: layui.mymod.apiurl + '/RestAPIService/LogInfoQueryParam'
        , getfunctreelist: layui.mymod.apiurl + '/UserService/GetFuncTreeList'
        , getfileinfolist: layui.mymod.apiurl + '/RestAPIService/FileInfoRequest'
        , getviewlayoutlist: layui.mymod.apiurl + '/QueryService/DtoQueryParam?ACTION=101&KeyName=1'
        , getjoblist: layui.mymod.apiurl + '/RestAPIService/JobRequest?ACTION=100'
        , postjob: layui.mymod.apiurl + '/RestAPIService/JobRequest?ACTION=101'

        //远程服务即（wmapp、projectapp）
        , getlocationlist: layui.mymod.apiurl_remote + '/WMService/LocationRequest?ACTION=100'
        , locationop: layui.mymod.apiurl_remote + '/WMService/LocationRequest'
        , getscenelist: layui.mymod.apiurl_remote + '/WMService/SceneRequest'
        , gettasklist: layui.mymod.apiurl_remote + '/WMService/TaskRequest'
        , taskop: layui.mymod.apiurl_remote + '/WMService/TaskRequest'
        , getdcsinflist: layui.mymod.apiurl_remote + '/WMService/DCSInfRequest'
        , getmsglist: layui.mymod.apiurl_remote + '/WMService/MsgRequest'
        , getscreenlist: layui.mymod.apiurl_remote + '/WMService/LedInfoRequest'
        , getstnlist: layui.mymod.apiurl_remote + '/WMService/StnRequest?ACTION=100'
        , stnop: layui.mymod.apiurl_remote + '/WMService/StnRequest'

        , rkmovereq1: layui.mymod.apiurl_remote + '/WMService/MoveRequest?ACTION=101' //入库确认按钮

        , checkop: layui.mymod.apiurl_remote + '/WMService/CheckRequest'
        , moveop: layui.mymod.apiurl_remote + '/WMService/MoveRequest' //确认移动按钮
        , statuldop: layui.mymod.apiurl_remote + '/QueryService/DtoQueryParam'
        , statagv: layui.mymod.apiurl_remote + '/WMService/StatAGVRequest'


        , locationgroup: layui.mymod.apiurl_remote + '/WMService/LocationRequest'
        , product: layui.mymod.apiurl_remote + '/WMService/ProductRequest'
        , plandetail: layui.mymod.apiurl_remote + '/WMService/PlandetailRequest'
        , basic: layui.mymod.apiurl_remote + '/WMService/BasicRequest'

        , projplandetail: layui.mymod.apiurl_remote + '/WMProject/ProjPlanDetailRequest'
        , projmoverequest: layui.mymod.apiurl_remote + '/WMProject/ProjMoveRequest'

        , pallet: layui.mymod.apiurl_remote + '/WMService/PalletRequest'
        , projpallet: layui.mymod.apiurl_remote + '/WMProject/ProjPalletRequest'

        , projquery: layui.mymod.apiurl_remote + '/WMProject/QueryParam'

        //项目定制
        , projmesoprequest: layui.mymod.apiurl_remote + '/WMProject/ProjMesOPRequest'
        , projinvoprequest: layui.mymod.apiurl_remote + '/WMProject/ProjInvOPRequest'
        , projinfrequest: layui.mymod.apiurl_remote + '/WMProject/ProjInfRequest'


        , projtaskoprequest: layui.mymod.apiurl_remote + '/WMProject/ProjTaskOPRequest'
        , projviewtaksquery: layui.mymod.apiurl_remote + '/WMProject/ProjViewTaksQuery'

        //inf
        , projinfqcapi: layui.mymod.apiurl_remoteinf + '/api/v1/lbk/qc'
    });
});
