using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using Business_Layer;
using Business_ObjectLayer;

namespace AirportAuthoritiesUI
{
    public class Global : System.Web.HttpApplication
    {
        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
          
        }

        protected void Application_Error(object sender, EventArgs e)
        {
         
           // string pp2 = Server.GetLastError().StackTrace;
           // Response.Redirect("/error404.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            obj.Exitlogout = Convert.ToInt32(Application["logoutid"]);
            int i = bal.exitbrowser(obj);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            obj.Exitlogout = Convert.ToInt32(Application["logoutid"]);
            int i = bal.exitbrowser(obj);            
        }
    }
}