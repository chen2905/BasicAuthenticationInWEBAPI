﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace webAppConsumeWebAPI.MessageHandler
    {
    public class MessageHandler2 : DelegatingHandler
        {
        protected override Task<HttpResponseMessage> SendAsync(
           HttpRequestMessage request, CancellationToken cancellationToken)
            {
            // Create the response.
            var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                Content = new StringContent("Hello! from MessageHandler2")
                };
            // Note: TaskCompletionSource creates a task that does not contain a delegate.
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
            }
        }
    }