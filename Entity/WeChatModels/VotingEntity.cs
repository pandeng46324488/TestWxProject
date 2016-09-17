using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    /// <summary>
    /// 投票结果返回对象实体类
    /// </summary>
    public class VotingEntity
    {
        #region 属性
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        public int Status { get; set; }

        //public List<WeChat_VoteOptionEntity> DataList { get; set; }
        #endregion

        #region 方法
        public VotingEntity()
        {
            //DataList = new List<WeChat_VoteOptionEntity>();
        }
        #endregion
    }
}
