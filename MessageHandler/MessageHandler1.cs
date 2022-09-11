using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace webAppConsumeWebAPI.MessageHandler
    {
    public class MessageHandler1 : DelegatingHandler
        {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
            {
            Debug.WriteLine("Process request from MessageHandler1");
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Process response from MessageHandler1");
            return response;
            }
        }
    }