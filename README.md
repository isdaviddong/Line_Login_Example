# Line_Login_Example
<img src='http://arock.blob.core.windows.net/blogdata201702/14-215656-e2740e6c-82bb-489b-9792-a271086e7e4e.png' />
<div class="panel-body">
背景知識:
  請先參考底下這篇文章，建立您的LINE Login服務channel，取得Client_id, Client_secret
  https://studyhost.blogspot.com/2017/12/clinebot17-line-login-v21.html
  接著即可下載clone此範例使用
  
說明: 
<ol>
<li>使用此範例Source code時，請先更換程式碼中《你的Client_id》<br/> (位於default.aspx) </li>
<li>並且調整你申請好的LineLogin設定的callback url <br/> (測試階段應為http://localhost:17615/Callback.aspx) </li>
<li>同時Callback.aspx.cs中的client_id與client_secret必須改為你申請LINE Login後取得的正確資料</li>
<li>相關說明請參考 : http://studyhost.blogspot.tw/2016/12/linebot7-line-loginoauth-sso.html </li>
</ol>
使用: 
<ol>
<li>請點選《使用Line登入》，將會取得該登入用戶的access_token</li>
<li>接著按下《取得用戶資訊》，可透過access_token取得用戶資訊，即表示你取得正確的Token，完成SSO。</li>
</ol>

整合說明: 
<ol>
<li>要透過LINE Login實現SSO，你應該已經有一個具有用戶管理的Web應用系統，也有自己會員管理機制與用戶登入帳號</li>
<li>你可以在自己系統的網頁上，安置一個類似本網頁上的『使用LINE登入』功能，當用戶按下此按鈕，會引導用戶去LINE的SSO頁面完成登入，並取回Code以便於換得Token(本例中在Callback頁面中實現)</li>
<li>回到你的系統頁面之後，你同時擁有該用戶在你自己的系統中的身分(David? Eric? Tom?...)，和該用戶的LINE Token(以及他的user Id, 這可以從Token取得)</li>
<li>這時，你可以把該用戶的User Id存入你自己的用戶資料表(例如 Eric的User Id為U2541xa2411dae3f1d124r12rdf1)，即可輕鬆完成未來的SSO行為。</li>
<li>(意即，未來你的用戶可以直接透過LINE登入，不一定只能使用在你系統中的帳密，類似Google的登入一樣)</li>
</ol>
</div>
