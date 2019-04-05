<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Line_Login_Example._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/toastr.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/toastr.min.js"></script>
    <script src="Scripts/vue.min.js"></script>
    <script src="Scripts/isRockFx.js"></script>
    <script>
        //建立OAuth 身分驗證頁面並導入
        function Auth() {
            var URL = 'https://access.line.me/oauth2/v2.1/authorize?';
            URL += 'response_type=code';
            URL += '&client_id=這邊要換成你的client_id';   //TODO:這邊要換成你的client_id
            URL += '&redirect_uri=http://localhost:17615/callback.aspx';   //TODO:要將此redirect url 填回你的 LineLogin後台設定
            URL += '&scope=openid%20profile';
            URL += '&state=abcde';
            window.location.href = URL;
        }

        //建立OAuth 身分驗證頁面並導入
        function AuthWithEmail() {
            var URL = 'https://access.line.me/oauth2/v2.1/authorize?';
            URL += 'response_type=code';
            URL += '&client_id=這邊要換成你的client_id';   //TODO:這邊要換成你的client_id
            URL += '&redirect_uri=http://localhost:17615/callback.aspx';   //TODO:要將此redirect url 填回你的 LineLogin後台設定
            URL += '&scope=openid%20profile%20email';
            URL += '&state=abcde';
            window.location.href = URL;
        }

        //Button1 click
        function Button1_click() {
            Auth();
        }
        //Button2 click
        function Button2_click() {
            AuthWithEmail();
        }

        //hook event
        $(document).ready(function () {
            $('#Button1').click(Button1_click);
            $('#Button2').click(Button2_click);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row" style="margin: 12px">
                <div class="col-lg-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            範例 :  LINE Login  Example
                        </div>
                        <div class="panel-body">
                            使用說明: 
                        <ol>
                            <li>使用此範例Source code，請先更換程式碼中《你的Client_id》<br />
                                (位於default.aspx) </li>
                            <li>並且調整你申請好的 LINE Login 設定的callback url
                                <br />
                                (測試階段應為http://localhost:17615/Callback.aspx) </li>
                            <li>同時Callback.aspx.cs中的client_id與client_secret必須改為你申請 LINE Login 後取得的正確資料</li>
                            <li>相關說明請參考 : http://studyhost.blogspot.tw/2016/12/linebot7-line-loginoauth-sso.html </li>
                        </ol>
                            使用步驟: 
                        <ol>
                            <li>請點選《使用Line登入》，將會取得該登入用戶的access_token</li>
                            <li>接著按下《取得用戶資訊》，可透過access_token取得用戶資訊</li>
                        </ol>
                            安全性說明: 
                        <ol>
                            <li>token會由放在queryString是為了便於您測試和debug, 正式環境不該如此。</li>
                            <li>會有嚴重的安全性顧慮</li>
                        </ol>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            測試 LINE Login
                        </div>
                        <div class="panel-body">
                            <button class="btn btn-primary pull-left" style="margin-right: 5px" id="Button1" type="button">使用LINE Login登入</button>
                            <div class="pull-left">
                                <button class="btn btn-primary" id="Button2" type="button">使用LINE Login登入(取得email資訊)</button><br />
                                <label>(透過上面LINE Login按鈕將取得您的email，僅供本範例示範需要使用)</label><br />
                                <label>(申請的LINE Login Channel必須支援OpenID Connect/email) </label>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <label>取回的token:</label>
                                <input runat="server" id="txb_token" class="form-control" /><br />
                                    <label>取回的email: (申請的LINE Login Channel必須支援OpenID Connect/email)</label>
                                <input runat="server" id="txb_email" class="form-control" /><br />

                                <asp:Button CssClass="btn btn-primary" OnClick="ButtonGetUserProfile_Click" ID="ButtonGetUserProfile" runat="server" Text="取得用戶資訊" />
                                <br />
                                <textarea runat="server" rows="5" class="form-control" id="textarea1"> </textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
