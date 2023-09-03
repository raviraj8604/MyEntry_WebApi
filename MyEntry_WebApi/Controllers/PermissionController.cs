using CT.Exceptions;
using ELMS_Modal.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyEntry_WebApi.Controllers
{
    public class PermissionController : ApiController
    {
        #region Code file
        string strCodeFile = "PermissionController";
        #endregion

        [HttpGet]
        public HttpResponseMessage GetPermissionModule(int id)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                    {
                    new SQLParam("@ViewMode", 1),
                    new SQLParam("@UserTypeID", id),

                    };
                DataSet DS = oDB.ExecuteSP_GetDataSet("uspUM_Modules_Get", argParams);
             
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    DS.Tables[0].TableName = "UserModule";
                    DS.Tables[1].TableName = "SubModule";

                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, DS);

            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetPermissionModule", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetPermissionByUserType(UserModule modal)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                    {
                    new SQLParam("@ViewMode", 2),
                    new SQLParam("@UserTypeID", modal.UserTypeID),
                    new SQLParam("@ModuleType", modal.ModuleType),

                    };
                DataSet DS = oDB.ExecuteSP_GetDataSet("uspUM_Modules_Get", argParams);

                DataTable dt = new DataTable();
                if (DS != null)
                {
                    DS.Tables[0].TableName = "ModuleType";
                    DS.Tables[1].TableName = "SubModule";

                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, DS);

            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetPermissionModule", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

    }
}
