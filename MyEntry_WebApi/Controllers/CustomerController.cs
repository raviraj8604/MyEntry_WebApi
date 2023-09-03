using CT.Exceptions;
using ELMS_Modal.Account;
using ELMS_Modal.CustomerManagement;
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
    public class CustomerController : ApiController
    {
        #region "VARIABLES"
        private string strCodeFile = "CustomerController";
        #endregion

        #region Customer Details
        [HttpPost]
        public HttpResponseMessage AddCustomer(CustomerModel pCustomerModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={       new SQLParam("@Mode"                , 1)
                                             ,new SQLParam("@CustomerName"        ,pCustomerModel.CustomerName)
                                             ,new SQLParam("@CustomerCode"       ,pCustomerModel.CustomerCode)
                                             ,new SQLParam("@CompanyID"          ,pCustomerModel.CompanyID)
                                             ,new SQLParam("@Designation"        ,pCustomerModel.Designation)
                                             ,new SQLParam("@ContactPerson"      ,pCustomerModel.ContactPerson)
                                             ,new SQLParam("@GSTNo"              ,pCustomerModel.GSTNo)
                                             ,new SQLParam("@Phone1"             ,pCustomerModel.Phone1)
                                             ,new SQLParam("@Phone2"             ,pCustomerModel.Phone2)
                                             ,new SQLParam("@Mobile"             ,pCustomerModel.Mobile)
                                             ,new SQLParam("@Fax"                ,pCustomerModel.Fax)
                                             ,new SQLParam("@Email1"             ,pCustomerModel.Email1)
                                             ,new SQLParam("@Email2"             ,pCustomerModel.Email2)
                                             ,new SQLParam("@Website"            ,pCustomerModel.Website)
                                             ,new SQLParam("@CountryID"          ,pCustomerModel.CountryID)
                                             ,new SQLParam("@StateID"            ,pCustomerModel.StateID)
                                             ,new SQLParam("@City"               ,pCustomerModel.City)
                                             ,new SQLParam("@PinCode"            ,pCustomerModel.PinCode)
                                             ,new SQLParam("@Address1"           ,pCustomerModel.Address1)
                                             ,new SQLParam("@Address2"           ,pCustomerModel.Address2)
                                             ,new SQLParam("@Address3"           ,pCustomerModel.Address3)
                                             ,new SQLParam("@CreatedBy"          ,pCustomerModel.CreatedBy)
                                             ,new SQLParam("@strDivisionList"    ,pCustomerModel.CustmerDivisonList)
                                             ,new SQLParam("@Active"             ,pCustomerModel.Active)
                                             ,new SQLParam("@WefDatePrice"       ,pCustomerModel.WefDatePrice)
                                             ,new SQLParam("@ShipmentModeID"     ,pCustomerModel.ShipmentModeID)
                                             ,new SQLParam("@JobPaymentVariation",pCustomerModel.JobPaymentVariation)
                                             ,new SQLParam("@InvoiceName"        ,pCustomerModel.InvoiceName)
                                             ,new SQLParam("@ContactNo"          ,pCustomerModel.ContactNo)
                                             ,new SQLParam("@MarketingPersonID"  ,pCustomerModel.MarketingPersonID)
                                             ,new SQLParam("@FatherName"         ,pCustomerModel.FatherName)
                                             ,new SQLParam("@Gender"             ,pCustomerModel.Gender)
                                             ,new SQLParam("@ShipmentDetails"    ,pCustomerModel.ShipmentDetails)
                                            
                                       };

                oDB.ExecuteSP("uspCust_Customers", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pCustomerModel.CustomerID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pCustomerModel.CustomerID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomer", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage EditCustomer(CustomerModel pCustomerModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={       new SQLParam("@Mode"                , 2)
                                              ,new SQLParam("@CustomerID"           , pCustomerModel.CustomerID)
                                             ,new SQLParam("@CustomerName"           , pCustomerModel.CustomerName)
                                             ,new SQLParam("@CustomerCode"        , pCustomerModel.CustomerCode)
                                             ,new SQLParam("@ContactPerson"      ,pCustomerModel.ContactPerson)
                                             ,new SQLParam("@CompanyID"        , pCustomerModel.CompanyID)
                                             ,new SQLParam("@Designation"            , pCustomerModel.Designation)
                                             ,new SQLParam("@GSTNo"            , pCustomerModel.GSTNo)
                                             ,new SQLParam("@Phone1"            , pCustomerModel.Phone1)
                                             ,new SQLParam("@Phone2"            , pCustomerModel.Phone2)
                                             ,new SQLParam("@Mobile"            , pCustomerModel.Mobile)
                                             ,new SQLParam("@Fax"            , pCustomerModel.Fax)
                                             ,new SQLParam("@Email1"            , pCustomerModel.Email1)
                                             ,new SQLParam("@Email2"            , pCustomerModel.Email2)
                                             ,new SQLParam("@Website"            , pCustomerModel.Website)
                                             ,new SQLParam("@CountryID"            , pCustomerModel.CountryID)
                                             ,new SQLParam("@StateID"            , pCustomerModel.StateID)
                                             ,new SQLParam("@City"               , pCustomerModel.City)
                                             ,new SQLParam("@PinCode"            ,pCustomerModel.PinCode)
                                             ,new SQLParam("@Address1"            ,pCustomerModel.Address1)
                                             ,new SQLParam("@Address2"            ,pCustomerModel.Address2)
                                             ,new SQLParam("@Address3"            ,pCustomerModel.Address3)
                                             ,new SQLParam("@CreatedBy"            ,pCustomerModel.CreatedBy)
                                             ,new SQLParam("@strDivisionList"      ,pCustomerModel.CustmerDivisonList)
                                             ,new SQLParam("@Active"      ,pCustomerModel.Active)
                                             ,new SQLParam("@WefDatePrice"   ,pCustomerModel.WefDatePrice)
                                             ,new SQLParam("@ShipmentModeID"   ,pCustomerModel.ShipmentModeID)
                                             ,new SQLParam("@JobPaymentVariation"   ,pCustomerModel.JobPaymentVariation)
                                             ,new SQLParam("@InvoiceName"       ,pCustomerModel.InvoiceName)
                                             ,new SQLParam("@ContactNo"        ,pCustomerModel.ContactNo)
                                             ,new SQLParam("@MarketingPersonID"          ,pCustomerModel.MarketingPersonID)
                                              ,new SQLParam("@FatherName"         ,pCustomerModel.FatherName)
                                             ,new SQLParam("@Gender"             ,pCustomerModel.Gender)
                                       };

                oDB.ExecuteSP("uspCust_Customers", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pCustomerModel.CustomerID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pCustomerModel.CustomerID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomer", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage GetCustomerList(CustomerModel pCustomerModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1)

                };
                DataSet DS = oDB.ExecuteSP_GetDataSet("uspCUST_Customers_Get", argParams);
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
                CTException.WriteDBLog(strCodeFile, "GetCustomerList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCustomerById(string Id)
        {
            try

            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 2),
                                     new SQLParam("@CustomerID", Id)

                };
                DataSet DS = oDB.ExecuteSP_GetDataSet("uspCUST_Customers_Get", argParams);
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    dt = DS.Tables[0];
                    DS.Tables[0].TableName = "CustomerDetails";
                    DS.Tables[1].TableName = "CustomerCoverPrice";
                    DS.Tables[2].TableName = "CustomerPaperPrice";
                    DS.Tables[3].TableName = "CustomerAccessoriesPrice";
                    DS.Tables[4].TableName = "CustomerItemPrice";

                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, DS);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetCustomerList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
        #endregion

        #region CustomerAccount

        [HttpPost]
        public async Task<HttpResponseMessage> GetCustomerTransactionList(ELMS_Modal.Common.PostCustomerDetails Model)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1),
                                     new SQLParam("@CustomerName", Model.CustomerName),
                                     new SQLParam("@FromDate", Model.FromDate),
                                     new SQLParam("@ToDate", Model.ToDate),
                                      new SQLParam("@CustomerID", Model.CustomerID),
                };
                DataSet DS = await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspCUST_PaymentTrans_Get", argParams));
                DataTable dt = new DataTable();
                if (DS != null)
                {
                    DS.Tables[0].TableName = "CustomerDetails";
                    DS.Tables[1].TableName = "AccountModel";

                }
                oDB = null;
                return Request.CreateResponse(HttpStatusCode.OK, DS);
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "GetPaymentList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public async Task< HttpResponseMessage> GetPaymentList(ELMS_Modal.Common.PostCustomerDetails Model)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams =
                    {
                                     new SQLParam("@ViewMode", 1),
                                     new SQLParam("@FromDate", Model.FromDate),
                                     new SQLParam("@ToDate", Model.ToDate),
                                     new SQLParam("@CustomerID", Model.CustomerID),
                                     new SQLParam("@LoanID", Model.LoanID)
                };
                DataSet DS = await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspCUST_PaymentReceived_Get", argParams));
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
                CTException.WriteDBLog(strCodeFile, "GetPaymentList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage DeleteReceviedPayment(int id)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                            new SQLParam("@Mode"                     ,3)
                                           ,new SQLParam("@PaymentReceiveID"         ,id)

                                        };
                oDB.ExecuteSP("uspCUST_PaymentReceived", argParams);
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
                CTException.WriteDBLog(strCodeFile, "DeleteReceviedPayment", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddCustomerAccount(AccountModel pAccountModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={       new SQLParam("@Mode"                , 1)
                                             ,new SQLParam("@CustomerID"           , pAccountModel.CustomerID)
                                              ,new SQLParam("@LoanID"           , pAccountModel.LoanID)
                                             ,new SQLParam("@PaymentMode"        , pAccountModel.PaymentMode)
                                             ,new SQLParam("@TransAmount"        , pAccountModel.TransAmount)
                                             ,new SQLParam("@TransDate"            , pAccountModel.TransDate)
                                             ,new SQLParam("@TransNo"            , pAccountModel.TransNo)
                                             ,new SQLParam("@TransBank"            , pAccountModel.TransBank)
                                             ,new SQLParam("@Remarks"            , pAccountModel.Remarks)
                                             ,new SQLParam("@CreatedBy"            ,pAccountModel.CreatedBy)
                                            , new SQLParam("@ModifyBy"            , pAccountModel.ModifyBy)

                                       };

                oDB.ExecuteSP("uspCUST_PaymentReceived", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pAccountModel.PaymentReceiveID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pAccountModel.PaymentReceiveID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomerAccount", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage EditCustomerAccount(AccountModel pAccountModel)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={       new SQLParam("@Mode"                , 2)
                                             ,new SQLParam("@PaymentReceiveID"    ,pAccountModel.PaymentReceiveID)
                                             ,new SQLParam("@CustomerID"          ,pAccountModel.CustomerID)
                                             ,new SQLParam("@PaymentMode"         ,pAccountModel.PaymentMode)
                                             ,new SQLParam("@TransAmount"         ,pAccountModel.TransAmount)
                                             ,new SQLParam("@TransDate"           ,pAccountModel.TransDate)
                                             ,new SQLParam("@TransNo"             ,pAccountModel.TransNo)
                                             ,new SQLParam("@TransBank"           ,pAccountModel.TransBank)
                                             ,new SQLParam("@Remarks"             ,pAccountModel.Remarks)
                                             ,new SQLParam("@CreatedBy"           ,pAccountModel.CreatedBy)
                                            , new SQLParam("@ModifyBy"            ,pAccountModel.ModifyBy)

                                       };

                oDB.ExecuteSP("uspCUST_PaymentReceived", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pAccountModel.PaymentReceiveID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pAccountModel.PaymentReceiveID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomerAccount", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateCustomerPrice(UpdateCustoemerPrice pUpdateCustoemerPrice)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                              new SQLParam("@Mode"                    ,pUpdateCustoemerPrice.Mode)
                                             ,new SQLParam("@CustomerID"              ,pUpdateCustoemerPrice.CustomerID)
                                             ,new SQLParam("@WefDate"                 ,pUpdateCustoemerPrice.WefDate)
                                             ,new SQLParam("@strItemPrice"            ,pUpdateCustoemerPrice.strItemPrice)
                                             ,new SQLParam("@strCoverPrice"           ,pUpdateCustoemerPrice.strCoverPrice)
                                             ,new SQLParam("@strPaperPrice"           ,pUpdateCustoemerPrice.strPaperPrice)
                                             ,new SQLParam("@strAccessoryPrice"       ,pUpdateCustoemerPrice.strAccessoryPrice)
                                             ,new SQLParam("@CreatedBy"               ,pUpdateCustoemerPrice.CreatedBy)
                                             ,new SQLParam("@ModifyBy"                ,pUpdateCustoemerPrice.ModifyBy)


                                        };
                oDB.ExecuteSP("uspCust_Customers", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUpdateCustoemerPrice.CustomerID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUpdateCustoemerPrice.CustomerID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomer", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }



        [HttpGet]
        public async Task< HttpResponseMessage> GetCustomerDuePayment(int id)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams = {
                                     new SQLParam("@ViewMode", 1),
                                      new SQLParam("@CustomerID", id),
                };
                DataSet DS = await Task.Run(()=> oDB.ExecuteSP_GetDataSet("uspCUST_DuePayment_Get", argParams));
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
                CTException.WriteDBLog(strCodeFile, "GetPaymentList", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }



        [HttpPost]
        public HttpResponseMessage UpdateCustomerPriceNew(UpdateCustoemerPrice pUpdateCustoemerPrice)
        {
            try
            {
                SQLDBPro oDB = new SQLDBPro();
                SQLParam[] argParams ={
                                              new SQLParam("@Mode"                    ,pUpdateCustoemerPrice.Mode)
                                             ,new SQLParam("@CustomerID"              ,pUpdateCustoemerPrice.CustomerID)
                                             ,new SQLParam("@WefDate"                 ,pUpdateCustoemerPrice.WefDate)
                                             ,new SQLParam("@strItemPrice"            ,pUpdateCustoemerPrice.strItemPrice)
                                             ,new SQLParam("@strCoverPrice"           ,pUpdateCustoemerPrice.strCoverPrice)
                                             ,new SQLParam("@strPaperPrice"           ,pUpdateCustoemerPrice.strPaperPrice)
                                             ,new SQLParam("@strAccessoryPrice"       ,pUpdateCustoemerPrice.strAccessoryPrice)
                                             ,new SQLParam("@CreatedBy"               ,pUpdateCustoemerPrice.CreatedBy)
                                             ,new SQLParam("@ModifyBy"                ,pUpdateCustoemerPrice.ModifyBy)


                                        };
                oDB.ExecuteSP("uspCUST_CustomersNew", argParams);

                if (oDB.SPStatus == SQLDBPro.enumSPStatus.Final)
                {
                    pUpdateCustoemerPrice.CustomerID = int.Parse(oDB.SPResult[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, pUpdateCustoemerPrice.CustomerID);
                }
                else
                {
                    string ErrMsg = oDB.SPResult[0];
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ErrMsg);
                }
            }
            catch (Exception ex)
            {
                CTException.WriteDBLog(strCodeFile, "AddCustomer", ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        #endregion
    }
}
