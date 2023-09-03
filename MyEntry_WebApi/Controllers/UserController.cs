using CT.Exceptions;
using ELMS_Modal.User;
using MyEntry_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyEntry_WebApi.Controllers
{
    public class UserController : ApiController
    {

        private string strCodeFile = "UserController";

        #region USER LOGIN SECTION
        [HttpPost]
        public async Task<HttpResponseMessage> Login(UserModel pLoginModal)
        {
            try
            {
                DataTable DT = new DataTable();
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                          new SQLParam("@UserPwd"            ,pLoginModal.Password)
                                         ,new SQLParam("@UserName"           ,pLoginModal.UserName)
                                         ,new SQLParam("@RemoteHostIP"      ,pLoginModal.RemoteHostIP)
                                         ,new SQLParam("@RemoteHostName"    ,pLoginModal.RemoteHostName)
                                         ,new SQLParam("@DivisionID"        ,pLoginModal.DivisionID)
                                        };
                await Task.Run(() => oDB.ExecuteSP("uspUM_UserLogin", argParams));
                if (oDB.SPStatus == CT.DataLink.CTSQLPro.enumSPStatus.Final)
                {
                    pLoginModal.UserID = int.Parse(oDB.SPResult[0]);
                    pLoginModal.UserName = Convert.ToString(oDB.SPResult[1]);
                    pLoginModal.CompanyID = int.Parse(oDB.SPResult[2]);
                    pLoginModal.UserTypeID = int.Parse(oDB.SPResult[3]);
                    pLoginModal.UserTypeName = Convert.ToString(oDB.SPResult[6]);
                    pLoginModal.CompanyLogo = Convert.ToString(oDB.SPResult[7]);
                    return Request.CreateResponse(HttpStatusCode.OK, pLoginModal);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "Login", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }



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

        #region User Type Oprations
        [HttpPost]
        public async Task<HttpResponseMessage> AddUserType(UserTypeModel pUserTypeModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@ViewMode"                ,1)
                                           ,new SQLParam("@UserTypeName"            ,pUserTypeModel.UserTypeName)
                                           ,new SQLParam("@UserTypeCode"            ,pUserTypeModel.UserTypeCode)
                                           ,new SQLParam("@Active"                  ,pUserTypeModel.Active)
                                           ,new SQLParam("@StrUserPermission"       ,pUserTypeModel.StrUserPermission)
                                           ,new SQLParam("@CreatedBy"               ,pUserTypeModel.CreatedBy)


                                        };

                await Task.Run(() => oDB.ExecuteSP("uspUM_UserTypes", argParams));
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUserTypeModel.UserTypeID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUserTypeModel.UserTypeID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "Login", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }


        [HttpPost]
        public HttpResponseMessage EditUserType(UserTypeModel pUserTypeModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@ViewMode"               ,2)
                                           ,new SQLParam("@UserTypeName"          ,pUserTypeModel.UserTypeName)
                                           ,new SQLParam("@UserTypeCode"          ,pUserTypeModel.UserTypeCode)
                                           ,new SQLParam("@Active"                ,pUserTypeModel.Active)
                                           ,new SQLParam("@UserTypeID"            ,pUserTypeModel.UserTypeID)
                                           ,new SQLParam("@StrUserPermission"     ,pUserTypeModel.StrUserPermission)
                                           ,new SQLParam("@ModifyBy"              ,pUserTypeModel.ModifyBy)
                                        };

                oDB.ExecuteSP("uspUM_UserTypes", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUserTypeModel.UserTypeID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUserTypeModel.UserTypeID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "EditUserType", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }


        [HttpPost]
        public HttpResponseMessage ActiveInactiveUserType(UserTypeModel pOrchidUserTypeModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@ViewMode"                , 3)
                                           ,new SQLParam("@UserTypeID"               , pOrchidUserTypeModel.UserTypeID)
                                           ,new SQLParam("@CreatedBy"       ,pOrchidUserTypeModel.CreatedBy)
                                           ,new SQLParam("@ModifyBy"       ,pOrchidUserTypeModel.ModifyBy)
                                           ,new SQLParam("@Active"       ,pOrchidUserTypeModel.Active)
                                        };
                oDB.ExecuteSP("uspUM_UserTypes", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pOrchidUserTypeModel.UserTypeID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pOrchidUserTypeModel.UserTypeID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "ActiveInactiveUserType", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }



        [HttpPost]
        public async Task< HttpResponseMessage> GetUserTypeList(UserTypeModel pUserTypeModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1)

                };
                DataSet DS =  await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspUM_UserTypes_Get", argParams));
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    dt = DS.Tables[0];
                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetUserList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        #endregion

        #region User Details
        [HttpPost]
        public async Task<HttpResponseMessage>   AddUserDetails(UserDetialsModel pUserDetialsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@Mode"                 ,1)
                                           ,new SQLParam("@UserName"             ,pUserDetialsModel.UserName)
                                           ,new SQLParam("@UserPwd"              ,pUserDetialsModel.UserPwd)
                                           ,new SQLParam("@FullName"             ,pUserDetialsModel.FullName)
                                           ,new SQLParam("@UserTypeID"           ,pUserDetialsModel.UserTypeID)
                                           ,new SQLParam("@CompanyID"            ,pUserDetialsModel.CompanyID)
                                           ,new SQLParam("@Active"               ,pUserDetialsModel.Active)
                                           ,new SQLParam("@Email"                ,pUserDetialsModel.Email)
                                           ,new SQLParam("@ContactNo"            ,pUserDetialsModel.ContactNo)
                                           ,new SQLParam("@IsOwner"              ,pUserDetialsModel.IsOwner)
                                           ,new SQLParam("@strDivisionList"      ,pUserDetialsModel.strDivisionList)

                                        };

                await Task.Run(() => oDB.ExecuteSP("uspUM_UserDetails", argParams));
                  if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUserDetialsModel.UserID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUserDetialsModel.UserID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddUserDetails", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        public       HttpResponseMessage EditUserDetails(UserDetialsModel pUserDetialsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@Mode"                ,2)
                                           ,new SQLParam("@UserName"            ,pUserDetialsModel.UserName)
                                           ,new SQLParam("@UserPwd"             ,pUserDetialsModel.UserPwd)
                                           ,new SQLParam("@FullName"            ,pUserDetialsModel.FullName)
                                           ,new SQLParam("@UserTypeID"          ,pUserDetialsModel.UserTypeID)
                                           ,new SQLParam("@CompanyID"           ,pUserDetialsModel.CompanyID)
                                           ,new SQLParam("@Active"              ,pUserDetialsModel.Active)
                                           ,new SQLParam("@Email"               ,pUserDetialsModel.Email)
                                           ,new SQLParam("@ContactNo"           ,pUserDetialsModel.ContactNo)
                                           ,new SQLParam("@UserID"              ,pUserDetialsModel.UserID)
                                           ,new SQLParam("@IsOwner"             ,pUserDetialsModel.IsOwner)
                                           ,new SQLParam("@strDivisionList"      ,pUserDetialsModel.strDivisionList)

                                        };

                oDB.ExecuteSP("uspUM_UserDetails", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUserDetialsModel.UserID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUserDetialsModel.UserID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "EditUserDetails", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage ActiveInactiveUserDetail(UserDetialsModel pUserDetialsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                          new SQLParam("@Mode"                ,4)
                                           ,new SQLParam("@UserID"           ,pUserDetialsModel.UserID)
                                           ,new SQLParam("@CreatedBy"        ,pUserDetialsModel.CreatedBy)
                                           ,new SQLParam("@ModifyBy"         ,pUserDetialsModel.ModifyBy)
                                           ,new SQLParam("@Active"           ,pUserDetialsModel.Active)
                                        };

                oDB.ExecuteSP("uspUM_UserDetails", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUserDetialsModel.UserID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUserDetialsModel);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "ActiveInactiveUserDetail", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public async Task <HttpResponseMessage> GetUserDetailsList(UserDetialsModel pUserDetialsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1)

                };
                DataSet DS =await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspUM_UserDetails_Get", argParams));
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    dt = DS.Tables[0];
                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetUserList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        #endregion


    }
}
