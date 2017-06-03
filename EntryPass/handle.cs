using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business_Layer;
using Business_ObjectLayer;


namespace EntryPass
{
      

    public class handle
    {

        Business_LayerClass bal = new Business_LayerClass();
        Business_ObjectLayerClass obj = new Business_ObjectLayerClass();

        //public int error_handle(string error,int userid)
        //{
        //    try
        //    {
        //        obj.Error = error;
        //        obj.Id = userid;
        //        int i = bal.insert_error(obj);
        //            return i;
        //    }
        //    catch (Exception)
        //    {
              
        //        //throw;
        //    }
        //}
    }
}