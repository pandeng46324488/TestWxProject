//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAL;
//using Common;
//using Entity;
//using System.Data;
//using System.Data.SqlClient;

//namespace BLL
//{
//    public class VoteOptionBLL
//    {
//        #region 属性
//        private EFrameContenxt ContextObj = null;
//        #endregion

//        #region 方法
//        public VoteOptionBLL()
//        {
//           ContextObj = new EFrameContenxt(CSetting.ConnecStr);
//        }

//        /// <summary>
//        /// 通过ID获取指定的投票项目
//        /// </summary>
//        /// <param name="voteId"></param>
//        /// <returns></returns>
//        public WeChat_VoteOptionEntity FindById(int optionId)
//        {
//            return ContextObj.WeChat_VoteOption.Where(u => u.OptionID == optionId && u.IsDelete == (int)DeleteEnum.No ).FirstOrDefault();
//            //WeChat_VoteOptionEntity ReturnObj = null;

//            //using (SqlConnection connc = new SqlConnection(CSetting.ConnecStr))
//            //{
//            //    connc.Open();

//            //    SqlCommand Comm = new SqlCommand(
//            //        string.Format("SELECT TOP 1 * FROM WeChat_VoteOption WHERE OptionID = {0} AND IsDelete = 0 AND ActiveStatus = 1", optionId)
//            //        , connc);
//            //    Comm.CommandType = System.Data.CommandType.Text;

//            //    SqlDataAdapter ad = new SqlDataAdapter(Comm);
//            //    DataTable dt = new DataTable();
//            //    ad.Fill(dt);

//            //    if (dt.Rows.Count == 1)
//            //    {
//            //        ReturnObj = new WeChat_VoteOptionEntity();
//            //        ReturnObj.Title = dt.Rows[0]["Title"].ToString();
//            //        ReturnObj.Description = dt.Rows[0]["Description"].ToString();
//            //    }
//            //    connc.Close();
//            //    connc.Dispose();
//            //}

//            //return ReturnObj;
//        }

//        /// <summary>
//        /// 通过项目ID获取选项集合
//        /// </summary>
//        /// <param name="voteId"></param>
//        /// <returns></returns>
//        public List<WeChat_VoteOptionEntity> GetListByVoteId(int voteId)
//        {
//            return ContextObj.WeChat_VoteOption.Where(s => s.VoteInfoID == voteId && s.IsDelete == (int)DeleteEnum.No && s.ActiveStatus == (int)ActiveStatusEnum.Active ).ToList();

//            //List<WeChat_VoteOptionEntity> ReturnObj = null;

//            //using (SqlConnection connc = new SqlConnection(CSetting.ConnecStr))
//            //{
//            //    connc.Open();

//            //    SqlCommand Comm = new SqlCommand(
//            //        string.Format( "SELECT * FROM WeChat_VoteOption WHERE VoteInfoID = {0} AND IsDelete = 0 AND ActiveStatus = 1 ",voteId),
//            //        connc);
//            //    Comm.CommandType = System.Data.CommandType.Text;

//            //    SqlDataAdapter ad = new SqlDataAdapter(Comm);
//            //    DataTable dt = new DataTable();
//            //    ad.Fill(dt);

//            //    if (dt.Rows.Count == 1)
//            //    {
//            //        WeChat_VoteOptionEntity TempObj = new WeChat_VoteOptionEntity();
//            //        TempObj.Title = dt.Rows[0]["Title"].ToString();
//            //        TempObj.Description = dt.Rows[0]["Description"].ToString();
//            //        ReturnObj.Add(TempObj);
//            //    }
//            //    connc.Close();
//            //    connc.Dispose();
//            //}

//            //return ReturnObj;
//        }
//        #endregion
//    }
//}
