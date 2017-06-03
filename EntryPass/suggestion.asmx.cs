using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Business_Layer;
using System.Web.Script.Services;

namespace EntryPass
{
    /// <summary>
    /// Summary description for suggestion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class suggestion : System.Web.Services.WebService
    {
        Business_LayerClass bal = new Business_LayerClass();
        List<string> customers = new List<string>();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] AutoCompleteAjaxRequest(string prefixText, int count)
        {
            customers = bal.search(prefixText);
            return customers.ToArray();
        }
    }
}
