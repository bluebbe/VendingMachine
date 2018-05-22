using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http.Formatting;

namespace VendingMachineAPI.Models
{
    public class MessageResult : IHttpActionResult 
    {
        public string Message { get; set; }
        HttpRequestMessage _request;

        public MessageResult(string msg, HttpRequestMessage request)
        {
            _request = request;
            Message = msg;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(Message,System.Text.Encoding.UTF8,"application/json"),
                RequestMessage = _request,
                StatusCode = (System.Net.HttpStatusCode)422,

            };

            return Task.FromResult(response);
        }
    }
}