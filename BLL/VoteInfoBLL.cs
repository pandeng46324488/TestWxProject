//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAL;
//using Common;
//using Entity;
//using System.Data.SqlClient;
//using System.Data;

//namespace BLL
//{
//    public class VoteInfoBLL
//    {
//        #region 属性
//        private EFrameContenxt ContextObj =  null; 
//        #endregion

//        public VoteInfoBLL()
//        {
//            ContextObj = new EFrameContenxt(CSetting.ConnecStr); //this.Database.Initialize(false);
//        }

//        #region 方法        
//        /// <summary>
//        /// 通过ID获取指定的投票项目
//        /// </summary>
//        /// <param name="voteId"></param>
//        /// <returns></returns>
//        public WeChat_VoteInfoEntity FindById(int voteId)
//        {
//            return ContextObj.WeChat_VoteInfo.Where(s => s.VoteInfoID == voteId).FirstOrDefault();

//            //WeChat_VoteInfoEntity ReturnObj = null;
            
//            //using (SqlConnection connc = new SqlConnection(CSetting.ConnecStr))
//            //{
//            //    connc.Open();

//            //    SqlCommand Comm = new SqlCommand(
//            //        string.Format("SELECT TOP 1 * FROM WeChat_VoteInfo WHERE VoteInfoID = {0} AND IsDelete = 0 ", voteId)
//            //        , connc);
//            //    Comm.CommandType = System.Data.CommandType.Text;

//            //    SqlDataAdapter ad = new SqlDataAdapter(Comm);
//            //    DataTable dt = new DataTable();
//            //    ad.Fill(dt);

//            //    if (dt.Rows.Count == 1)
//            //    {
//            //        ReturnObj = new WeChat_VoteInfoEntity();
//            //        ReturnObj.Title = dt.Rows[0]["Title"].ToString();
//            //        ReturnObj.Description = dt.Rows[0]["Description"].ToString();
//            //    }
//            //    connc.Close();
//            //    connc.Dispose();
//            //}

//            //return ReturnObj;
//        }
//        #endregion
//    }
//}
