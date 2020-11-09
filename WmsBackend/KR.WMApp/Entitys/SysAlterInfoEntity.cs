using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SYS_ALERTINFO")]
    public class SysAlterInfoEntity : BaseExtend10
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Index]
        [Description("消息类型")]
        [StringLength(100)]
        public string MSGTYPE { get; set; }

        [Description("创建时间")]
        [Required]
        public string CREATEDATE { get; set; }

        [Description("响应状态")]
        [StringLength(100)]
        public string MSGSTATE { get; set; }

        [Description("消息文本")]
        [StringLength(1000)]
        public string MSGTEXT { get; set; }

        [Description("提醒对象")]
        [StringLength(100)]
        public string REMINDER { get; set; }

        [Description("提醒角色")]
        [StringLength(100)]
        public string REMINDERROLE { get; set; }

        [Description("确认状态")]
        [StringLength(100)]
        public string CONFIRMSTATE { get; set; }

        [Description("确认时间")]
        [StringLength(100)]
        public string CONFIRMDATE { get; set; }

        [Default(0)]
        public DateTime CREATEDATETIME { get; set; }
    }
}
