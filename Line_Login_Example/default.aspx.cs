using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using isRock.LineLoginV21;

namespace Line_Login_Example
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果從callback.aspx導回此頁，應該可以取得token
            if (!this.IsPostBack)
            {
                //如果有，則保留於text
                //(注意這不安全，應該要保留在後端，此為範例)
                this.txb_token.Value = Request.QueryString["token"];
            }
        }

        protected void ButtonGetUserProfile_Click(object sender, EventArgs e)
        {
            //透過token取得用戶資廖
            var user = Utility.GetUserProfile(this.txb_token.Value);
            textarea1.InnerText= Newtonsoft.Json.JsonConvert.SerializeObject(user);
        }
    }
}