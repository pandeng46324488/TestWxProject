using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using TestWxProject.Units;
using Common;

namespace TestWxProject.Controllers
{
//    /// <summary>
//    /// 投票
//    /// </summary>
//    public class VoteController : Controller
//    {
//        /// <summary>
//        /// 起始页
//        /// </summary>
//        /// <returns></returns>
//        public ActionResult VoteDetails(string code = "", string state = "")
//        {
//            try
//            {
//                #region 获取WebPageAccessToken                
//                if( string.IsNullOrEmpty( code ) )
//                {
//                    //如果未能获取到code，转跳到错误页面，或者让用户重新进入。 
//                    return RedirectToAction("Index", "Error", new { Ex = new Exception("非常抱歉，获取用户信息时发生异常，请重新进入此页面。") });
//                }

//                if (string.IsNullOrEmpty(state))
//                {
//                    //如果获取不到参数，得不到项目ID
//                    return RedirectToAction("Index", "Error", new {Ex = new Exception("非常抱歉，获取不到项目信息，无法获取数据，请联系我们进行处理，谢谢您的支持。") });
//                }
//                #endregion
                
//                //获取Token
//                WebPageAccessTokenEntity TokenObj = WebPageHelper.GetWebPageAccessToken(code);

//                #region 基本信息

//                //获取用户基本信息
//                WxWebPageUserEntity UserInfoObj = WxUserHelper.GetWebPageUserInfo(TokenObj.access_token, TokenObj.openid);

//                ViewBag.NickName = UserInfoObj.nickname;
//                ViewBag.UserOpenId = TokenObj.openid;      //用户ID
//                #endregion

//                #region 获取数据以及判断是否允许投票

//                WeChat_VoteInfoEntity InfoObj = null;
//                int VoteStatus = (int)VoteProjectStatusEnum.Normal;
//                string LimitReason = "服务器发生异常，请联系我们的系统开发人员进行处理，谢谢！";
//                if (!string.IsNullOrEmpty(state))
//                {
//                    int VoteId = Convert.ToInt32(state); //获取投票项目ID                    
//                    BLL.VoteInfoBLL BllObj = new VoteInfoBLL();
//                    InfoObj= BllObj.FindById(VoteId);
//                }

//                if( InfoObj != null && Convert.ToDateTime( InfoObj.StartTime ) > DateTime.Now ) //投票时间还未开始
//                {
//                    //投票还未开始
//                    VoteStatus = (int)VoteProjectStatusEnum.NotStarted;
//                    LimitReason = "投票还未开始";
//                }

//                if( InfoObj != null && Convert.ToDateTime( InfoObj.EndTime ) <= DateTime.Now ) //投票时间已经结束
//                {
//                    //投票时间已经结束
//                    VoteStatus = (int)VoteProjectStatusEnum.Complete;
//                    LimitReason = "投票时间已经结束";
//                }

//                if( InfoObj != null && (int)VoteProjectStatusEnum.Normal == VoteStatus )
//                {
//                    #region 检查当前这个人的投票情况
//                    BLL.VoteRecordBLL RecordBllObj = new VoteRecordBLL();       //投票业务层对象
//                    long CurrentVoteNum = RecordBllObj.GetVoteAllNum(InfoObj.VoteInfoID);   //获取当前投票数
                    
//                    #region 检查投票限制类型
//                    //检查投票限制类型
//                    switch (InfoObj.VoteType)
//                    {
//                        case (int)Common.VoteTypeEnum.EachDayLimit:  //每人每天一票                            

//                            //如果是每一天限制一次,如果在允许的条件下，这个人投过票，则不再允许再投票[允许条件：1：当前有限制总投票数且当前已投票数未达到最该限制值 2：不限制 ]
//                            if ( ( CurrentVoteNum < InfoObj.TotalVoteNum && InfoObj.TotalVoteNum > 0  ) || InfoObj.TotalVoteNum <= 0 )
//                            {
//                                //获取该用户当前的投票数来判断是否已经投过票
//                                int UserVote = RecordBllObj.CheckIsVoted( InfoObj.VoteInfoID, UserInfoObj.openid, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
//                                VoteStatus = UserVote > 0 ? (int)VoteProjectStatusEnum.HaveVoted : (int)VoteProjectStatusEnum.Normal ;
//                                LimitReason = UserVote > 0 ? "您今天已经投过票了，请明天再来投票吧~":"";
//                            }
//                            else{
//                                //已经不满足投票
//                                VoteStatus = (int)VoteProjectStatusEnum.ReachLimit;
//                                LimitReason = "已达到投票总数限制";
//                            }
                            
//                            break;

//                        case (int)Common.VoteTypeEnum.AllLimit: break; //如果是根据总机会来限制

//                            //如果是-1则明没有限制，大于0则表明是限制了
//                            if ( ( CurrentVoteNum < InfoObj.TotalVoteNum && InfoObj.TotalVoteNum > 0  ) || InfoObj.TotalVoteNum <= 0) 
//                            {
//                                //如果是在此模式下，只要未达到上限，则允许任意投票
//                                VoteStatus = (int)VoteProjectStatusEnum.Normal;
//                                LimitReason = "";
//                            }
//                            else{
//                                //已经不满足投票
//                                VoteStatus = (int)VoteProjectStatusEnum.ReachLimit;
//                                LimitReason = "已达到投票总数限制";
//                            }

//                        default: 
//                                //未处理的情况
//                                VoteStatus = (int)VoteProjectStatusEnum.ReachLimit;
//                                LimitReason = "已达到投票总数限制";
//                            break;
//                    };
//                    #endregion
                    
//                    #endregion
//                }
                
//                BLL.VoteOptionBLL optionBll = new VoteOptionBLL();
//                if( null!= InfoObj)
//                {
//                    //获取投票选项
//                    List<WeChat_VoteOptionEntity> OptionList = optionBll.GetListByVoteId(InfoObj.VoteInfoID);
//                    ViewData["OptionList"] = OptionList;
//                }

//                ViewData["VoteStatus"] = VoteStatus;
//                ViewData["LimitReason"] = LimitReason;
//                return View(InfoObj);                
//                #endregion                
//            }
//            catch (Exception Ex)
//            {
//                ViewData["VoteStatus"] = (int)VoteProjectStatusEnum.Error;
//                ViewData["LimitReason"] = "服务器发生异常，请联系我们的系统开发人员进行处理，谢谢！";
//                return View();
//            }
//        }



//        /// <summary>
//        /// 进行投票
//        /// </summary>
//        /// <param name="userid">用户ID</param>
//        /// <param name="optionid">投票ID</param>
//        /// <returns></returns>
//        public JsonResult Voting(string userid,string nickname, int voteid, int optionid)
//        {
//            VotingEntity ReturnObj = new VotingEntity();
            
//            ReturnObj.Status = (int)VoteProjectStatusEnum.Normal; //未初始化

//            try
//            {
//                WeChat_VoteInfoEntity InfoObj = null;
//                BLL.VoteInfoBLL BllObj = new VoteInfoBLL();
//                InfoObj = BllObj.FindById(voteid);

//                #region 检查项目起止时间
//                if( InfoObj != null && Convert.ToDateTime( InfoObj.StartTime ) > DateTime.Now ) //投票时间还未开始
//                {
//                    //未开始
//                    ReturnObj.Status = (int)VoteProjectStatusEnum.NotStarted;
//                }

//                if( InfoObj != null && Convert.ToDateTime( InfoObj.EndTime ) <= DateTime.Now ) //投票时间已经结束
//                {
//                    //已经结束
//                    ReturnObj.Status = (int)VoteProjectStatusEnum.Complete;
//                }
//                #endregion

//                #region 检查当前这个人的投票情况
//                BLL.VoteRecordBLL RecordBllObj = new VoteRecordBLL();       //投票业务层对象
//                long CurrentVoteNum = RecordBllObj.GetVoteAllNum(voteid);   //获取当前投票数

//                if (ReturnObj.Status == (int)VoteProjectStatusEnum.Normal && InfoObj != null)
//                {
//                    #region 检查投票限制类型
//                    //检查投票限制类型
//                    switch (InfoObj.VoteType)
//                    {
//                        case (int)Common.VoteTypeEnum.EachDayLimit:  //每人每天一票                            

//                            //如果是每一天限制一次,如果在允许的条件下，这个人投过票，则不再允许再投票[允许条件：1：当前有限制总投票数且当前已投票数未达到最该限制值 2：不限制 ]
//                            if ((CurrentVoteNum < InfoObj.TotalVoteNum && InfoObj.TotalVoteNum > 0) || InfoObj.TotalVoteNum <= 0)
//                            {
//                                //获取该用户当前的投票数来判断是否已经投过票
//                                int UserVote = RecordBllObj.CheckIsVoted(InfoObj.VoteInfoID, userid, DateTime.Now.ToString("yyyy-MM-dd 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
//                                ReturnObj.Status = UserVote > 0 ? (int)VoteProjectStatusEnum.HaveVoted : (int)VoteProjectStatusEnum.Normal;
//                            }
//                            else
//                            {
//                                //已经不满足投票
//                                ReturnObj.Status = (int)VoteProjectStatusEnum.ReachLimit;
//                            }

//                            break;

//                        case (int)Common.VoteTypeEnum.AllLimit: break; //如果是根据总机会来限制

//                            //如果是-1则明没有限制，大于0则表明是限制了
//                            if ((CurrentVoteNum < InfoObj.TotalVoteNum && InfoObj.TotalVoteNum > 0) || InfoObj.TotalVoteNum <= 0)
//                            {
//                                //如果是在此模式下，只要未达到上限，则允许任意投票
//                                ReturnObj.Status = (int)VoteProjectStatusEnum.Normal;
//                            }
//                            else
//                            {
//                                //已经不满足投票
//                                ReturnObj.Status = (int)VoteProjectStatusEnum.ReachLimit;
//                            }

//                        default:
//                            //未处理的情况
//                            ReturnObj.Status = (int)VoteProjectStatusEnum.ReachLimit;
//                            break;
//                    };
//                    #endregion
//                }
//                #endregion

//                if (ReturnObj.Status == (int)VoteProjectStatusEnum.Normal)  //如果正常投票
//                {
//                    ReturnObj.Status = 0;

//                    //插入投票数据
//                    Entity.WeChat_VoteRecordEntity InsertData = new WeChat_VoteRecordEntity();

//                    InsertData.NickName = nickname;
//                    InsertData.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
//                    InsertData.OpenId = userid;
//                    InsertData.OptionID = optionid;
//                    InsertData.VoteInfoID = voteid;
//                    InsertData.ActiveStatus = 1;
//                    InsertData.IsDelete = 0;
//                    InsertData.MarkText = "测试";

//                    BLL.VoteRecordBLL VeBllObj = new VoteRecordBLL();
//                    if (VeBllObj.Insert(InsertData))
//                    {
//                        ReturnObj.Status = 1;
//                        ReturnObj.Message = "投票成功";
//                        //投票成功后，重新刷新此页面

//                        #region 获取最新的数据
//                        BLL.VoteOptionBLL OpBllObj = new VoteOptionBLL();
//                        List<WeChat_VoteOptionEntity> VoteDataList = OpBllObj.GetListByVoteId(voteid);
                        
//                        for( int i=0; i<VoteDataList.Count;i++)
//                        {
//                            VoteDataList[i].VoteNum = (int)RecordBllObj.GetVoteNum(VoteDataList[i].OptionID);
//                        }
//                        ReturnObj.DataList = VoteDataList;
//                        #endregion

//                    }
//                    else
//                    {
//                        ReturnObj.Status = 0;
//                        ReturnObj.Message = "投票失败";
//                    }
//                }
//                else
//                {
//                    ReturnObj.Status = 0;
//                    ReturnObj.Message = "投票失败";
//                }

//                return Json(ReturnObj, "application/json", JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception Ex)
//            {
//                ReturnObj.Message = Ex.Message;
//                ReturnObj.Status = -1; //发生错误
//                return Json(ReturnObj, "application/json", JsonRequestBehavior.AllowGet);
//            }
//        }
//    }
}

