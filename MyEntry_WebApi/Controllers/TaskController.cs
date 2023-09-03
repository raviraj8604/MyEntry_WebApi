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
    public class TaskController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync()
        {
            try
            {
                // Simulate fetching data asynchronously
                DataTable dataTable = await GetDataAsync();

                return Request.CreateResponse(HttpStatusCode.OK, dataTable);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private async Task<DataTable> GetDataAsync()
        {
            // Simulate asynchronous data retrieval
           // Simulating a delay

            // Create and populate DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));

            // Add some sample data
            dataTable.Rows.Add(1, "John");
            dataTable.Rows.Add(2, "Jane");

            return await Task.Run(()=> dataTable);
        }
    }
}
