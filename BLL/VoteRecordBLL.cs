//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entity;
//using DAL;
//using Common;
//using System.Data;
//using System.Data.SqlClient;

//namespace BLL
//{
//    public class VoteRecordBLL
//    {
//        #region 属性
//        private EFrameContenxt ContextObj = null;
//        #endregion

//        #region 方法
//        public VoteRecordBLL()
//        {
//           ContextObj = new EFrameContenxt(CSetting.ConnecStr);
//        }       

//        /// <summary>
//        ///  通过选项ID获取投票数量
//        /// </summary>
//        /// <param name="optionId"></param>
//        /// <returns></returns>
//        public long GetVoteNum(int optionId)
//        {
//            return ContextObj.WeChat_VoteRecord.Where(s => s.OptionID == optionId && s.ActiveStatus == (int)ActiveStatusEnum.Active && s.IsDelete == (int)DeleteEnum.No ).Count();
//        }

//        /// <summary>
//        /// 获取统计整个投票项目当前的投票数
//        /// </summary>
//        /// <param name="VoteProjectId"></param>
//        /// <returns></returns>
//        public long GetVoteAllNum(int VoteProjectId)
//        {
//            return ContextObj.WeChat_VoteRecord.Where(s => s.VoteInfoID == VoteProjectId && s.ActiveStatus == (int)ActiveStatusEnum.Active && s.IsDelete == (int)DeleteEnum.No).Count();
//        }

//        /// <summary>
//        /// 检查在指定的时间段内，某一个用户是否对指定的VoteId项目进行了投票
//        /// </summary>
//        /// <param name="VoteProjectId"></param>
//        /// <param name="openid"></param>
//        /// <param name="StartTime"></param>
//        /// <param name="EndTime"></param>
//        /// <returns></returns>
//        public int CheckIsVoted(int VoteProjectId, string openid, string StartTime, string EndTime)
//        {
//            try
//            {
//                int result = 9999;
//                DateTime DStartTime = Convert.ToDateTime(StartTime);
//                DateTime DEndTime = Convert.ToDateTime(EndTime);

//                using (SqlConnection connc = new SqlConnection(CSetting.ConnecStr))
//                {
//                    connc.Open();

//                    string SQL = string.Format(
//                        "SELECT ISNULL( COUNT(*), 0 ) AS Num FROM WeChat_VoteRecord WHERE IsDelete = {0} AND ActiveStatus = {1} AND VoteInfoID = {2} AND OpenId = '{3}' AND CreateTime >= N'{4}' AND CreateTime <= N'{5}' ",
//                        (int)DeleteEnum.No,              //0
//                        (int)ActiveStatusEnum.Active,    //1
//                        VoteProjectId,              //2
//                        openid,                     //3
//                        StartTime,                  //4
//                        EndTime                     //5
//                    );

//                    SqlCommand Comm = new SqlCommand(SQL, connc);
//                    Comm.CommandType = System.Data.CommandType.Text;

//                    object Result = Comm.ExecuteScalar();

//                    if (null != Result)
//                    {
//                        result = Convert.ToInt32(Result);
//                    }
//                    connc.Close();
//                    connc.Dispose();
//                }

//                return result;
//                 //return ContextObj.WeChat_VoteRecord.Where(s => s.VoteInfoID == VoteProjectId && s.IsDelete == (int)DeleteEnum.No && s.ActiveStatus == (int)ActiveStatusEnum.Active && s.OpenId == openid && Convert.ToDateTime( s.CreateTime ) > DStartTime &&  Convert.ToDateTime(s.CreateTime) < DEndTime).Count();
//            }
//            catch (Exception Ex)
//            {
//                return 9999;
//            }
//        }

//        /// <summary>
//        /// 插入投票记录
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        public bool Insert(WeChat_VoteRecordEntity model)
//        {
//            int result = -1;
//            try
//            {
//                using (SqlConnection connc = new SqlConnection(CSetting.ConnecStr))
//                {
//                    connc.Open();

//                    string SQL = string.Format(
//                        "INSERT INTO WeChat_VoteRecord( VoteInfoID, OptionID, OpenId, CreateTime, NickName, MarkText, ActiveStatus, IsDelete ) VALUES ( {0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7} ) ",
//                        model.VoteInfoID,       //0
//                        model.OptionID,         //1
//                        model.OpenId,           //2
//                        model.CreateTime,       //3
//                        model.NickName,         //4
//                        model.MarkText,         //5
//                        model.ActiveStatus,     //6
//                        model.IsDelete
//                    );

//                    SqlCommand Comm = new SqlCommand(SQL, connc);
//                    Comm.CommandType = System.Data.CommandType.Text;

//                    result = Comm.ExecuteNonQuery();
//                    connc.Close();
//                    connc.Dispose();
//                }
//                return result > 0;
//            }
//            catch (Exception Ex)
//            {
//                return false;
//            }
//        }
//        #endregion
//    }
//}
