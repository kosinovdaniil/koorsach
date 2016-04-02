using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Epam.Wunderlist.WebApp
{
    public class HttpResponseBuilder
    {
        private IIdentity _user;

        private HttpRequestMessage _request;

        public HttpResponseBuilder(IIdentity user, HttpRequestMessage request)
        {
            _user = user;
            _request = request;
        }

        private Func<bool> _condition = () => true;

        private Func<object> _action;


        private static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        private HttpResponseMessage Execute()
        {
            if (_action == null)
            {
                throw new ArgumentNullException("_action");
            }
            HttpResponseMessage response;
            if (_user.IsAuthenticated)
            {
                if (_condition())
                {
                    response = _request.CreateResponse(HttpStatusCode.OK, "");
                    response.Content = new StringContent(Serialize(_action()), Encoding.Unicode);
                }
                else
                {
                    response = _request.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
                }
            }
            else
            {
                response = _request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }
            return response;
        }

        public HttpResponseBuilder WithMethod(Func<object> action)
        {
            _action = action;
            return this;
        }

        public HttpResponseBuilder WithMethod(Action action)
        {
            _action = () =>
            {
                action();
                return null;
            };
            return this;
        }

        public HttpResponseBuilder WithCondition(Func<bool> condition)
        {
            _condition = condition;
            return this;
        }

        public static implicit operator HttpResponseMessage(HttpResponseBuilder self)
        {
            return self.Execute();
        }

    }
}