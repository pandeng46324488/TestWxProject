using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WeChat_VoteRecordEntity
    {
        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// 投票信息主表Id
        /// </summary>
	    public int VoteInfoID { get; set; }

        /// <summary>
        /// 投票项ID
        /// </summary>
	    public int OptionID { get; set; }

        /// <summary>
        /// 投票人ID
        /// </summary>
	    public string OpenId { get; set; }

        /// <summary>
        /// 投票时间
        /// </summary>
	    public string CreateTime { get; set; }

        /// <summary>
        /// 投票人手机(预留)
        /// </summary>
	    public string PhoneNum { get; set; }

        /// <summary>
        /// 投票人联系地址(预留)
        /// </summary>
	    public string AddressText { get; set; }

        /// <summary>
        /// 投票人邮箱(预留)
        /// </summary>
	    public string Email { get; set; }

        /// <summary>
        /// 投票人邮政编号(预留)
        /// </summary>
	    public string PostCode { get; set; }

        /// <summary>
        /// 投票人昵称(预留)
        /// </summary>
	    public string NickName { get; set; }

        /// <summary>
        /// 备注[留言](预留)
        /// </summary>
	    public string MarkText { get; set; }

        /// <summary>
        /// 其它(预留)
        /// </summary>
	    public string OtherText { get; set; }

        /// <summary>
        /// 状态:
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
