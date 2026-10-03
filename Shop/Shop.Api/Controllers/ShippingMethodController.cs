using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ShippingMethod.Create;
using Shop.Application.ShippingMethod.Edit;
using Shop.Presentation.Facade.ShippingMethodAgg;
using Shop.Query.ShippingMethodAgg;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class ShippingMethodController : ApiController
    {
      
        private readonly IShippingMethodFacade _shippingMethod;
        public ShippingMethodController(IShippingMethodFacade shippingMethod)
        {
            _shippingMethod = shippingMethod;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<ShippingMethodDto>>> GetAllShipping()
        {
            var result =await _shippingMethod.GetAll();
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<ShippingMethodDto>> GetAllShippingById(long Id)
        {
            var result = await _shippingMethod.GetById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult>CreateShippingMethod(CreateShippingMethodCommand command)
        {
            var result = await _shippingMethod.Create(command);
            return CommandResult(result);
        }
        [HttpPut()]
        public async Task<ApiResult> EditShippingMethod(EditShippingMethodCommand command)
        {
            var result = await _shippingMethod.Edit(command);
            return CommandResult(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ApiResult> DeleteShippingMethod(long Id)
        {
            var result = await _shippingMethod.Delete(Id);
            return CommandResult(result);
        }

    }
}
