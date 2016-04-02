using System.Net.Http;
using System.Web.Http;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.WebApp.Controllers
{
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        #region Get
        [Route("users")]
        public HttpResponseMessage Get()
        {
            return CreateResponseBuilder().WithMethod(() => _userService.GetAll());
        }

        [Route("users/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            return CreateResponseBuilder().WithMethod(() => _userService.Get(id));
        }

        [Route("users/")]
        public HttpResponseMessage Get(string email)
        {
            return CreateResponseBuilder().WithMethod(() => _userService.Get(email));
        }

        #endregion

        #region Put

        [Route("users/")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(User user)
        {
            return CreateResponseBuilder().WithCondition(() => CurrentUserId == user.Id)
                .WithMethod(() => _userService.Update(user));
        }

        #endregion

        #region Private methods

        private int CurrentUserId
        {
            get
            {
                return ApiControllerExtensions.GetCurrentUserId(this);
            }
        }

        private HttpResponseBuilder CreateResponseBuilder()
        {
            return ApiControllerExtensions.CreateResponseBuilder(this);
        }

        #endregion
    }
}
