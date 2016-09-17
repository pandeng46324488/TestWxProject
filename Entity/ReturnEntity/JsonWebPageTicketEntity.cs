using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class JsonWebPageTicketEntity
    {
        #region 属性
        public string timestamp { get; set; }

        public string noncestr { get; set; }

        public string signature { get; set; }

        public string appid { get; set; }
        #endregion
    }
}
