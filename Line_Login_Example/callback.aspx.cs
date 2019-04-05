using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using isRock.LineLoginV21;

namespace Line_Login_Example
{
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得返回的code
            var code = Request.QueryString["code"];
            if (code == null)
            {
                Response.Write("沒有正確回應code");
                Response.End();
            }
            //顯示，測試用
            Response.Write("<br/> code : " + code);
            //從Code取回toke
            var token = Utility.GetTokenFromCode(code,
                "請更正為你自己的 client_id",  //TODO:請更正為你自己的 client_id
                "請更正為你自己的 client_secret", //TODO:請更正為你自己的 client_secret
                "http://localhost:17615/callback.aspx");  //TODO:請檢查此網址必須與你的LINE Login後台Call back URL相同
            //顯示，測試用(正式環境我們不會曝露token)
            Response.Write("<br/> token : " + token.access_token);
            //利用access_token取得用戶資料
            var user = Utility.GetUserProfile(token.access_token);
            //利用id_token取得Claim資料
            var JwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token.id_token);
            var email = "";
            //如果有email
            if (JwtSecurityToken.Claims.ToList().Find(c => c.Type == "email") != null)
                email = JwtSecurityToken.Claims.First(c => c.Type == "email").Value;

            //顯示，測試用
            Response.Write("<br/> user : " + Newtonsoft.Json.JsonConvert.SerializeObject(user));
            Response.Write("<br/> emal : " + email);
            //Response.End();

            //導入首頁，帶入token
            //(注意這是範例，token不該用明碼傳遞，也不該出現在用戶端，你應該自行記錄在資料庫或ServerSite session中)
            Response.Redirect($"default.aspx?token={HttpUtility.UrlEncode(token.access_token)}&email={email}");
        }
    }
}