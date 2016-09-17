using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Entity
{
    public class WeChat_VoteOptionEntity
    {
        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public int OptionID { get; set; }

        /// <summary>
        /// 投票信息表Id
        /// </summary>
	    public int VoteInfoID { get; set; }

        /// <summary>
        /// 投票选项模板(预留)
        /// </summary>
	    public int ModelType { get; set; }

        /// <summary>
        /// 投票选项类型(预留)
        /// </summary>
	    public int OptionType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
	    [DisplayName("名称")]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>        
        [DisplayName("描述")]
	    public string Description { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [DisplayName("图片")]
	    public string OptionImg { get; set; }

        /// <summary>
        /// 跳转Url(预留)
        /// </summary>
	    public string LinkUrl { get; set; }

        /// <summary>
        /// 排序号(预留)
        /// </summary>
	    public int OrderIndex { get; set; }

        /// <summary>
        /// 总投票机会数:-1表示不限制
        /// </summary>
	    public int TotalVoteNum { get; set; }

        /// <summary>
        /// 未关注允许投票总数:-1表示不限制
        /// </summary>
	    public int AnyoneVoteNum { get; set; }

        /// <summary>
        /// 投票上限(-1):表示不限制(预留)
        /// </summary>
	    public int UpperNum { get; set; }

        /// <summary>
        /// 投票下限(-1):表示不限制(预留)
        /// </summary>
	    public int LowerNum { get; set; }

        /// <summary>
        /// 选项有效开始时间(预留)
        /// </summary>
	    public string ValidSTime { get; set; }

        /// <summary>
        /// 选项有效截止时间(预留)
        /// </summary>
	    public string ValidETime { get; set; }

        /// <summary>
        /// 投票数(预留)
        /// </summary>
	    public int VoteNum { get; set; }

        /// <summary>
        /// 创建时间(预留)
        /// </summary>
	    public string CreateTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
	    public int ActiveStatus { get; set; }

        /// <summary>
        /// 是否已删除,0否,1是
        /// </summary>
	    public int IsDelete { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
	    public string Extend1 { get; set; }

        /// <summary>
        /// 预留字段2
        /// </summary>
        public string Extend2 { get; set; }
        #endregion
    }
}
