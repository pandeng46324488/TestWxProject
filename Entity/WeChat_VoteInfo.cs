using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Entity
{
    /// <summary>
    /// 投票信息表
    /// </summary>
    public class WeChat_VoteInfoEntity
    {
        /// <summary>
        /// 主键,对应Activity的ActivityID
        /// </summary>
        public int VoteInfoID { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }

        /// <summary>
        /// 投票形式: 1普通投票(预留)
        /// </summary>
        [DisplayName("投票形式")]
        public int VoteType { get; set; }

        /// <summary>
        /// 类型: 1单人单投制,2单人多投制,3单人单日制(预留)
        /// </summary>
        [DisplayName("类型")]
        public int VoteMulite { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 描述(规则)
        /// </summary>
        [DisplayName("描述(规则)")]
        public string Description { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string ContentText { get; set; }

        /// <summary>
        /// 跳转Url
        /// </summary>
        [DisplayName("跳转Url")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 缩略图片路径
        /// </summary>
        [DisplayName("缩略图片路径")]
        public string IconImg { get; set; }

        /// <summary>
        /// 详情图片
        /// </summary>
        [DisplayName("详情图片")]
        public string VoteImg { get; set; }

        /// <summary>
        /// 背景图(预留)
        /// </summary>
        [DisplayName("背景图(预留)")]
        public string BackgroundImg { get; set; }

        /// <summary>
        /// 总投票机会数:-1表示不限制
        /// </summary>
        [DisplayName("总投票机会数")]
        public int TotalVoteNum { get; set; }

        /// <summary>
        /// 未关注允许投票总数:-1表示不限制
        /// </summary>
        [DisplayName("未关注允许投票总数")]
        public int AnyoneVoteNum { get; set; }

        /// <summary>
        /// 投票上限(-1):表示不限制(预留)
        /// </summary>
        [DisplayName("投票上限")]
        public int UpperNum { get; set; }

        /// <summary>
        /// 投票下限(-1):表示不限制(预留)
        /// </summary>
        [DisplayName("投票下限")]
        public int LowerNum { get; set; }

        /// <summary>
        /// 投票数(预留)
        /// </summary>
        [DisplayName("投票数")]
        public int VoteNum { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DisplayName("排序号")]
        public int OrderIndex { get; set; }

        /// <summary>
        /// 投票开始时间
        /// </summary>
        [DisplayName("投票开始时间")]
        public string StartTime { get; set; }

        /// <summary>
        /// 投票截止时间
        /// </summary>
        [DisplayName("投票截止时间")]
        public string EndTime { get; set; }

        /// <summary>
        /// 报名开始时间(预留)
        /// </summary>
        [DisplayName("报名开始时间")]
        public string ReportSTime { get; set; }

        /// <summary>
        /// 报名截止时间(预留)
        /// </summary>
        [DisplayName("报名截止时间")]
        public string ReportETIme { get; set; }

        /// <summary>
        /// 创建人Id(预留)
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建人名称(预留)
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间(预留)
        /// </summary>
        [DisplayName("创建时间")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 分享标题
        /// </summary>
        public string ShareTitle { get; set; }

        /// <summary>
        /// 分享描述
        /// </summary>
        public string ShareDescribe { get; set; }

        /// <summary>
        /// 分享图片
        /// </summary>
        public string ShareImg { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
        public int ActiveStatus { get; set; }

        /// <summary>
        /// 是否已删除,0否,1是
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 预留1
        /// </summary>
        public string Extend1 { get; set; }

        /// <summary>
        /// 预留2
        /// </summary>
        public string Extend2 { get; set; }
    }
}
