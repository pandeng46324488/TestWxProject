using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class CSetting
    {
        #region 属性

        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public static string ConnecStr
        {
            get
            {
                if (!string.IsNullOrEmpty( ConfigurationManager.ConnectionStrings["Connec"].ConnectionString ))
                {
                    return ConfigurationManager.ConnectionStrings["Connec"].ConnectionString;
                }
                //return @"Data Source=182.254.215.185\sql2005;Initial Catalog=WeChat;User Id=sa;Password=1a?;Max Pool Size = 512;";
                return string.Empty;
            }
        }
        #endregion
    }
}
