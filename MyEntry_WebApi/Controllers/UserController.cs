using CT.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyEntry_WebApi.Controllers
{
    public class UserController : ApiController
    {

        private string strCodeFile = "UserController";

        #region USER LOGIN SECTION
        //[HttpPost]
        //public HttpResponseMessage Login(Prism_Models.Company.LoginModel pLoginModal)
        //{
        //    try
        //    {
        //        DataTable DT = new DataTable();
        //        SQLDBPro oDB = new SQLDBPro();
        //        SQLParam[] argParams ={
        //                                  new SQLParam("@UserPwd"            ,pLoginModal.Password)
        //                                 ,new SQLParam("@UserName"           ,pLoginModal.UserName)
        //                                 ,new SQLParam("@RemoteHostIP"      ,pLoginModal.RemoteHostIP)
        //                                 ,new SQLParam("@RemoteHostName"    ,pLoginModal.RemoteHostName)
        //                                 ,new SQLParam("@DivisionID"        ,pLoginModal.DivisionID)
        //                                };
        //        oDB.ExecuteSP("uspUM_UserLogin", argParams);
        //        if (oDB.SPStatus == CT.DataLink.CTSQLPro.enumSPStatus.Final)
        //        {
        //            pLoginModal.UserID = int.Parse(oDB.SPResult[0]);
        //            pLoginModal.UserName = Convert.ToString(oDB.SPResult[1]);
        //            pLoginModal.CompanyID = int.Parse(oDB.SPResult[2]);
        //            pLoginModal.UserTypeID = int.Parse(oDB.SPResult[3]);
        //            pLoginModal.UserTypeName = Convert.ToString(oDB.SPResult[6]);
        //            pLoginModal.MultiProductJobs = Convert.ToBoolean(oDB.SPResult[7]);
        //            return Request.CreateResponse(HttpStatusCode.OK, pLoginModal);
        //        }
        //        else
        //        {
        //            string ErrMsg = oDB.SPResult[0];
        //            return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CTException.WriteDBLog(strCodeFile, "Login", ex.Message);
        //        return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
        //    }
        //}



        [HttpGet]
        public APIResponse GetUserTypeList()
        {
            APIResponse objdta = new APIResponse();
            try
            {
                
               SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1)

                };
                DataSet DS = oDB.ExecuteSP_GetDataSet("GetList", argParams);
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    dt = DS.Tables[0];
                }
                oDB = null;
                objdta.Message = "Suceess";
                objdta.data = dt;
                //return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetUserList", ex.Message);
                //return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
            return objdta;
        }

        public class APIResponse {

            public int status { get; set; }
            public string Message { get; set; }

            public int Result { get; set; }

            public DataTable data { get; set; }

          
        }
        #endregion
    }
}
