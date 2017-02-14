if (!jQuery) { throw new Error("isRock framework requires jQuery.") }
 
//call ASP.NET PageMethod
function CallPageMethod(methodName, para, onSuccess, onFail) {
    //PageMethod必須接收array，即便沒有參數
    if (para == null) para = {};
    //如果沒有onSuccess，就用內建的
    if (onSuccess == undefined) {
        onSuccess = _CallPageMethod_Success;
    }
    //如果沒有onFail ，就用內建的
    if (onFail == undefined) {
        onFail = _CallPageMethod_Fail;
    }
    //get URL
    var loc = window.location.href;
    loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "default.aspx" : loc
    if (loc.indexOf('#') != -1) { loc = loc.substr(0, loc.indexOf('#')); }
    if (loc.indexOf('?') != -1) { loc = loc.substr(0, loc.indexOf('?')); }
    //ajax call
    $.ajax({
        type: "POST",
        url: loc + "/" + methodName,
        data: JSON.stringify(para),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //on success
        success: function (response) {
            onSuccess(response.d)
        },
        //on fail
        failure: function (response) {
            onFail(response);
        }
    }).fail(function (response) {
        if (response.status == 299) { //抓取前端的自訂義錯誤，組responseJSON
            var ex = { 'responseJSON': { 'Message': response.responseText } };
            onFail(ex);
        }
        else {
            onFail(response);
        }
    });
}

//預設成功Method
function _CallPageMethod_Success(result) {
    console.log('_CallPageMethod_Success Success return : ' + result, result);
    alert('ExecuteCommand Success.');
}

//預設失敗Method
function _CallPageMethod_Fail(ex) {
    console.log('_CallPageMethod_Fail error : ' + ex.statusText, ex);
    alert("error : " + ex.statusText);
}

//call WebAPI Method
function ExecuteAPI(catalog, method, para, success, fail) {
    $.ajax({
        url: "/api/" + catalog + "/" + method,
        type: "post",
        contentType: 'application/json',
        data: JSON.stringify(para),
        success: function (apiResult) {
            if (!success) {
                _ExecuteAPIonSuccess(apiResult);
            }
            else {
                success(apiResult);
            }
        },
        error: function (ex) {
            if (!fail) {
                _ExecuteAPIonError(ex);
            }
            else {
                fail(ex);
            }
        }
    })
}

//預設成功Method
function _ExecuteAPIonSuccess(apiResult) {
    if (apiResult.isSuccess) {
        alert("成功");
    }
    else {
        alert("失敗 : " + apiResult.Message);
    }
}

//預設失敗Method
function _ExecuteAPIonError(ex) {
    alert("失敗，請技術員查看ex物件 : " + ex);
}