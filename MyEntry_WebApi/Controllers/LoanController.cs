using CT.Exceptions;
using ELMS_Modal.Loan;
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
    public class LoanController : ApiController
    {
        #region "VARIABLES"
        private string strCodeFile = "CustomerController";
        #endregion

        #region Loan  Details
        [HttpPost]
        public async Task<HttpResponseMessage> AddLoan(LoanDetails pLoanDetails)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                         new SQLParam("@Mode"                , 1)
                                        ,new SQLParam("@LoanID"              ,pLoanDetails.LoanID)
                                        ,new SQLParam("@CustomerID"          ,pLoanDetails.CustomerID)
                                        ,new SQLParam("@LoanPurposeID"       ,pLoanDetails.LoanPurposeID)
                                        ,new SQLParam("@BranchID"            ,pLoanDetails.BranchID)
                                        ,new SQLParam("@LoanAccountNo"       ,pLoanDetails.LoanAccountNo)
                                        ,new SQLParam("@LoanAmount"          ,pLoanDetails.LoanAmount)
                                        ,new SQLParam("@LoanStatus"          ,pLoanDetails.LoanStatus)
                                        ,new SQLParam("@LoanTerm"            ,pLoanDetails.LoanTerm)
                                        ,new SQLParam("@StartDate"            ,pLoanDetails.StartDate)
                                        ,new SQLParam("@Active"              ,pLoanDetails.Active)
                                        ,new SQLParam("@EmiAmount"              ,pLoanDetails.EmiAmount)

                                        ,new SQLParam("@strPaymentSchList"              ,pLoanDetails.strPaymentSchList)
                                                                 ,new SQLParam("@RecoveryType"              ,pLoanDetails.RecoveryType)
                                       };

                await Task.Run(() => oDB.ExecuteSP("uspLN_LoanDetails", argParams));
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pLoanDetails.LoanID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pLoanDetails.LoanID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddLoan", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage EditLoan(LoanDetails pLoanDetails)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                         new SQLParam("@Mode"                , 2)
                                        ,new SQLParam("@LoanID"              ,pLoanDetails.LoanID)
                                        ,new SQLParam("@LoanPurposeID"       ,pLoanDetails.LoanPurposeID)
                                        ,new SQLParam("@BranchID"            ,pLoanDetails.BranchID)
                                        ,new SQLParam("@LoanAccountNo"       ,pLoanDetails.LoanAccountNo)
                                        ,new SQLParam("@LoanAmount"          ,pLoanDetails.LoanAmount)
                                        ,new SQLParam("@LoanStatus"          ,pLoanDetails.LoanStatus)
                                        ,new SQLParam("@LoanTerm"            ,pLoanDetails.LoanTerm)
                                        ,new SQLParam("@Active"              ,pLoanDetails.Active)
                                       };

                oDB.ExecuteSP("uspLN_LoanDetails", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pLoanDetails.LoanID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pLoanDetails.LoanID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddLoan", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public async Task<HttpResponseMessage> GetLoanDetailsList(LoanDetails pCustomerModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1)

                };
                DataSet DS = await Task.Run(() => oDB.ExecuteSP_GetDataSet("uspLN_LoanDetails_GET", argParams));
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
                CTException.WriteDBLog(strCodeFile, "[GetLoanDetailsList]", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public async Task<HttpResponseMessage> GetLoanDetailsById(LoanDetails pCustomerModel)
        {
            try

            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                    {
                                     new SQLParam("@ViewMode", 2),
                                     new SQLParam("@LoanID", pCustomerModel.LoanID)

                };
                DataSet DS = await Task.Run(() => oDB.ExecuteSP_GetDataSet("uspLN_LoanDetails_GET", argParams));
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
                CTException.WriteDBLog(strCodeFile, "GetLoanDetailsById", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public async Task<HttpResponseMessage> GetLoanPaymentSchedule(LoanDetails pCustomerModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1),
                                     new SQLParam("@LoanID", pCustomerModel.LoanID)
                };
                DataSet DS = oDB.ExecuteSP_GetDataSet("[uspLN_LoanPaymentSchedule_GET]", argParams);
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    dt = await Task.Run(() => DS.Tables[0]);
                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "[GetLoanDetailsList]", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage DeleteLoan(int id)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@Mode"                     ,3)
                                           ,new SQLParam("@LoanID"         ,id)

                                        };
                oDB.ExecuteSP("[uspLN_LoanDetails]", argParams);
                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "DeleteLoan", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        #endregion

        #region "GetDasboard"
        [HttpPost]

        public async Task<HttpResponseMessage> LoanDashboard(LoanDashboardModal objModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                {
                     new SQLParam("@ViewMode", 1),
                    new SQLParam("@FromDate", objModel.FromDate),
                     new SQLParam("@ToDate", objModel.ToDate)
                };
                DataSet DS = await Task.Run(() => oDB.ExecuteSP_GetDataSet("uspLMS_Dashboard", argParams));
                DataTable dt = new DataTable();
                if (DS != null)
                {

                    //dt = DS.Tables[0];
                    DS.Tables[0].TableName = "JobListDB";
                    DS.Tables[1].TableName = "CoustomerListDB";
                    DS.Tables[2].TableName = "CustomerPiechartDataList";
                    DS.Tables[3].TableName = "DashboardHeaderCount";
                    DS.Tables[4].TableName = "MonthWiseCollectionList";
                    DS.Tables[5].TableName = "AccountModelList";

                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, DS);
            }


            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "OrchidDashboard", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        #endregion




    }
}
