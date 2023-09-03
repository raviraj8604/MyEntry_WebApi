using CT.Exceptions;
using ELMS_Modal.Company;
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
    public class CompanyController : ApiController
    {
        string strCodeFile = "CompanyController";

        #region "Company Details"
        public async Task< HttpResponseMessage> GetCompanyDeails()
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] ArgPrms ={
                                        new SQLParam("@ViewMode" , 1)

                                    };

                DataSet DS = await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspSETUP_CompanyDetails_Get", ArgPrms));
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
                CTException.WriteDBLog(strCodeFile, "GetList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddCompany(CompanyDetailsModel pCompanyDetailsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                              new SQLParam("@Mode"                , 2)
                                             ,new SQLParam("@CompanyName"           , pCompanyDetailsModel.CompanyName)
                                             ,new SQLParam("@CompanyCode"        , pCompanyDetailsModel.CompanyCode)
                                             ,new SQLParam("@CompanyID"        , pCompanyDetailsModel.CompanyID)
                                             ,new SQLParam("@Designation"            , pCompanyDetailsModel.Designation)
                                             ,new SQLParam("@AuthorisedPerson"            , pCompanyDetailsModel.AuthorisedPerson)
                                             ,new SQLParam("@CinNumber"            , pCompanyDetailsModel.CINNo)
                                             ,new SQLParam("@GSTNo"            , pCompanyDetailsModel.GSTNo)
                                             ,new SQLParam("@Phone1"            , pCompanyDetailsModel.Phone1)
                                             ,new SQLParam("@Mobile"            , pCompanyDetailsModel.Mobile)
                                             ,new SQLParam("@Fax"            , pCompanyDetailsModel.Fax)
                                             ,new SQLParam("@Email1"            , pCompanyDetailsModel.Email1)
                                             ,new SQLParam("@Website"            , pCompanyDetailsModel.Website)
                                             ,new SQLParam("@CountryID"            , pCompanyDetailsModel.CountryID)
                                             ,new SQLParam("@StateID"            , pCompanyDetailsModel.StateID)
                                             ,new SQLParam("@City"            , pCompanyDetailsModel.City)
                                             ,new SQLParam("@PinCode"            , pCompanyDetailsModel.PinCode)
                                             ,new SQLParam("@Address1"            , pCompanyDetailsModel.Address1)
                                             ,new SQLParam("@Address2"            , pCompanyDetailsModel.Address2)
                                             ,new SQLParam("@Address3"            , pCompanyDetailsModel.Address3)
                                             ,new SQLParam("@LogoPath"            , pCompanyDetailsModel.LogoPath)

                                        };

                await Task.Run(() => oDB.ExecuteSP("uspSETUP_CompanyDetails", argParams));
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pCompanyDetailsModel.CompanyID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pCompanyDetailsModel.CompanyID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCompany", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public async Task< HttpResponseMessage> GetCommonFilters(Prism_Models.Company.CommonModel model)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                    {
                                     new SQLParam("@ViewMode", model.Mode)
                };
                DataSet DS =await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspSETUP_Common_Get", argParams));
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
                CTException.WriteDBLog(strCodeFile, "GetCompanyDivisonList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        #endregion

        #region "Branch Details"

        [HttpPost]
        public HttpResponseMessage AddCompanyBranch(CompanyBranchModel pCompanyDetailsModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                              new SQLParam("@Mode"                , 1)
                                             ,new SQLParam("@BranchName"           , pCompanyDetailsModel.BranchName)
                                             ,new SQLParam("@BranchCode"         , pCompanyDetailsModel.BranchCode)
                                             ,new SQLParam("@CompanyID"           , pCompanyDetailsModel.CompanyID)
                                             ,new SQLParam("@Designation"            , pCompanyDetailsModel.Designation)
                                             ,new SQLParam("@AuthorisedPerson"            , pCompanyDetailsModel.AuthorisedPerson)
                                             ,new SQLParam("@CinNumber"            , pCompanyDetailsModel.CINNo)
                                             ,new SQLParam("@GSTNo"            , pCompanyDetailsModel.GSTNo)
                                             ,new SQLParam("@Phone1"            , pCompanyDetailsModel.Phone1)
                                             ,new SQLParam("@Mobile"            , pCompanyDetailsModel.Mobile)
                                             ,new SQLParam("@Fax"            , pCompanyDetailsModel.Fax)
                                             ,new SQLParam("@Email1"            , pCompanyDetailsModel.Email1)
                                             ,new SQLParam("@Website"            , pCompanyDetailsModel.Website)
                                             ,new SQLParam("@CountryID"            , pCompanyDetailsModel.CountryID)
                                             ,new SQLParam("@StateID"            , pCompanyDetailsModel.StateID)
                                             ,new SQLParam("@City"            , pCompanyDetailsModel.City)
                                             ,new SQLParam("@PinCode"            , pCompanyDetailsModel.PinCode)
                                             ,new SQLParam("@Address1"            , pCompanyDetailsModel.Address1)
                                             ,new SQLParam("@Address2"            , pCompanyDetailsModel.Address2)
                                             ,new SQLParam("@Address3"            , pCompanyDetailsModel.Address3)
                                             ,new SQLParam("@LogoPath"            , pCompanyDetailsModel.LogoPath)

                                        };
                oDB.ExecuteSP("uspSETUP_CompanyBranches", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pCompanyDetailsModel.CompanyID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pCompanyDetailsModel.CompanyID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCompanyBranch", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetBranchList(int? id)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] ArgPrms ={
                                        new SQLParam("@ViewMode" , 2)
                                    };

                DataSet DS = await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspSETUP_CompanyBranches_Get", ArgPrms));
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
                CTException.WriteDBLog(strCodeFile, "GetBranchList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        #endregion
    }
}
