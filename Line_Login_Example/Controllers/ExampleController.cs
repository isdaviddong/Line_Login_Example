using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using isRock.Framework;
using isRock.Framework.WebAPI;

namespace Line_Login_Example.Controllers
{
    public class ExampleController : ApiController
    {
        [Route("api/Example/{MethodName}")]
        [HttpPost]
        public IHttpActionResult ExecuteMethod(string MethodName)
        {
            try
            {
                //AssemblyLauncher
                AssemblyLauncher assemblyLauncher = new AssemblyLauncher();
                //執行指定的Method
                var ret = assemblyLauncher.ExecuteCommand<TestClassA>(
                    new TestClassA(),
                    MethodName,
                    Request.Content.ReadAsStringAsync().Result);
                //回傳OK
                return Ok(ret);
            }
            catch (Exception ex)
            {
                //其他處理
                throw ex;
            }
        }
    }

	#region "這是樣板，實際BusinessLogic不該寫在Controller這裡，請移到獨立的Class"
    //回傳參數(也可以視為ViewModel)
	public class TestMethodResut
    {
        public int value1 { get; set; }
        public string value2 { get; set; }
    }
	//傳入參數
    public class TestMethodParameter
    {
        public int ValueA { get; set; }
        public string ValueB { get; set; }
    }
	//必須繼承 BusinessLogicBase
    public class TestClassA : BusinessLogicBase
    {
	    //請注意，務必只能有一個傳入參數
        public ExecuteCommandDefaultResult TestMethodA(TestMethodParameter para)
        {
            return new ExecuteCommandDefaultResult
            {
                Data = new TestMethodResut() { value1 = para.ValueA, value2 = para.ValueB },
                isSuccess = true,
                Message = ""
            };
        }
    }
	#endregion
}
