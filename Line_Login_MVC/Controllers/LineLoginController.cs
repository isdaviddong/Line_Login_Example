using isRock.LineLoginV21;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Line_Login_MVC.Controllers
{
    public class LineLoginController : Controller
    {
        // GET: LineLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Callback()
        {
            //取得返回的code
            var code = Request.QueryString["code"];
            if (code == null)
            {
                ViewBag.access_token = "沒有正確的code...";
                return View("index");
            }

            //從Code取回toke
            var token = Utility.GetTokenFromCode(code,
                "___這邊要換成你的client_id___",  //TODO:請更正為你自己的 client_id
                "___請更正為你自己的 client_secret___", //TODO:請更正為你自己的 client_secret
                "http://localhost:52643/LineLogin/Callback");  //TODO:請檢查此網址必須與你的LINE Login後台Call back URL相同

            //利用access_token取得用戶資料
            var user = Utility.GetUserProfile(token.access_token);
            //利用id_token取得Claim資料
            var JwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token.id_token);
            var email = "";
            //如果有email
            if (JwtSecurityToken.Claims.ToList().Find(c => c.Type == "email") != null)
                email = JwtSecurityToken.Claims.First(c => c.Type == "email").Value;

            //ViewBag
            ViewBag.email = email;
            ViewBag.access_token = token.access_token;
            ViewBag.displayName = user.displayName;
            return View("index");
        }

        [HttpPost]
        public ActionResult GetUserProfile(string Token, string email)
        {
            //透過token取得用戶資料
            var user = Utility.GetUserProfile(Token);
            ViewBag.UserProfileJSON = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            //ViewBag
            ViewBag.email = email;
            ViewBag.access_token = Token;
            return View("index");
        }
    }
}