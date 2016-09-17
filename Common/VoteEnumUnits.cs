using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Common
{
    #region 枚举
    /// <summary>
    /// 删除标志枚举
    /// </summary>
    public enum DeleteEnum : int
    {
        /// <summary>
        /// 0 - 未删除
        /// </summary>
        No = 0,

        /// <summary>
        /// 1 - 已删除
        /// </summary>
        Yes = 1,
    }

    /// <summary>
    /// 投票限制类型枚举
    /// </summary>
    public enum VoteTypeEnum:int
    {
        /// <summary>
        /// 总机会
        /// </summary>
        [Description("总机会")]
        AllLimit    = 1,

        /// <summary>
        /// 每天限制(每人每天一票）
        /// </summary>
        [Description("每天限制(每人每天一票)")]
        EachDayLimit = 2,
    }

    #region ActiveStatus枚举状态
    /// <summary>
    /// ActiveStatus枚举状态
    /// </summary>
    public enum ActiveStatusEnum : int
    {
        /// <summary>
        /// -1 未知状态[未定义]
        /// </summary>
        Unknown  = -1, 

        /// <summary>
        /// 0 待审核 
        /// </summary>
        WaitAudit = 0,

        /// <summary>
        /// 1 有效的[正常的]
        /// </summary>
        Active  = 1,

        /// <summary>
        /// 2 无效的[停止的]
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// 3 取消
        /// </summary>
        Cancel = 3,

        /// <summary>
        /// 4 删除的
        /// </summary>
        Deleted = 4,

        /// <summary>
        /// 5 锁定的
        /// </summary>
        Locaked = 5,

        /// <summary>
        /// 6 未锁定的
        /// </summary>
        Unlocked = 6,

        /// <summary>
        /// 7 冻结的
        /// </summary>
        Freeze  = 7,
    }
    #endregion

    #region VoteProjectStatus
    public enum VoteProjectStatusEnum : int
    {
        /// <summary>
        /// 1 未开始
        /// </summary>
        NotStarted = 1,

        /// <summary>
        /// 2 已经结束
        /// </summary>
        Complete = 2,

        /// <summary>
        /// 3 已投票
        /// </summary>
        HaveVoted = 3,

        /// <summary>
        /// 4 正常
        /// </summary>
        Normal = 4,

        /// <summary>
        /// 5 已达到投票上限
        /// </summary>
        ReachLimit = 5,

        /// <summary>
        /// -1 错误
        /// </summary>
        Error = -1
    }
    #endregion
    #endregion


}
