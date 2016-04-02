
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.WebApp;

namespace Epam.Wunderorder.WebApp.Controllers
{
    [RoutePrefix("webapp/api")]
    public class ItemApiController : ApiController
    {

        private readonly IOrderService _orderService;
        private readonly ICrudService<Item> _itemService;

        public ItemApiController(IOrderService orderService, ICrudService<Item> itemService)
        {
            _orderService = orderService;
            _itemService = itemService;
        }

        #region Get

        [Route("users/{id:int}/orders")]
        public HttpResponseMessage GetOrders(int id)
        {
            return CreateResponseBuilder().WithMethod(() => _orderService.GetByUser(id))
                .WithCondition(() => CurrentUserId == id);
        }

        [Route("orders/{id:int}")]
        public HttpResponseMessage GetOrder(int id)
        {
            var order = _orderService.Get(id);
            return CreateResponseBuilder().WithMethod(() => order)
               .WithCondition(() => order.User.Id == CurrentUserId || UserIsAdmin);
        }

        [Route("items")]
        public HttpResponseMessage GetItems()
        {
            return CreateResponseBuilder().WithMethod(() => _itemService.GetAll());
        }

        [Route("category/")]
        public HttpResponseMessage GetItemsByCategory(string category)
        {
            return CreateResponseBuilder().WithMethod(() => _itemService.GetByPredicate(x => x.Category == category));
        }

        [Route("items/{id:int}")]
        public HttpResponseMessage GetItem(int id)
        {
            var item = _itemService.Get(id);
            return CreateResponseBuilder().WithMethod(() => item);
        }

        #endregion

        #region Post
        [Authorize]
        [Route("orders/")]
        public HttpResponseMessage PostOrder(Order order)
        {
            return CreateResponseBuilder().WithMethod(() => _orderService.Create(order));
        }
        #endregion

        #region Put
        [Authorize]
        [Route("items/")]
        [HttpPut]
        public HttpResponseMessage UpdateItem(Item item)
        {
            return CreateResponseBuilder()
                .WithMethod(() => _itemService.Update(item));
        }

        [Route("orders/")]
        [HttpPut]
        public HttpResponseMessage UpdateOrder(Order order)
        {
            return CreateResponseBuilder().WithCondition(() => UserIsAdmin)
                .WithMethod(() => _orderService.Update(order));
        }

        #endregion

        #region Delete

        [Route("orders/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var order = _orderService.Get(id);
            return CreateResponseBuilder().WithCondition(() => UserIsAdmin || order.User.Id == CurrentUserId)
                .WithMethod(() => _orderService.Delete(order));
        }

        [Route("items/{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteItem(int id)
        {
            var item = _itemService.Get(id);
            return CreateResponseBuilder().WithCondition(() => UserIsAdmin)
                .WithMethod(() => _itemService.Delete(item));
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

        private bool UserIsAdmin
        {
            get
            {
                return ApiControllerExtensions.UserIsAdmin(this);
            }
        }

        private HttpResponseBuilder CreateResponseBuilder()
        {
            return ApiControllerExtensions.CreateResponseBuilder(this);
        }

        #endregion

    }
}
