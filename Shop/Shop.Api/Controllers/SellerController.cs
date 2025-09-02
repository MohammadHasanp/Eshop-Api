using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Presentation.Facade.SellerAgg;
using Shop.Presentation.Facade.SellerAgg.Inventory;
using Shop.Query.SellerAgg.DTOs;

namespace Shop.Api.Controllers
{
    public class SellerController : ApiController
    {
        private readonly ISellerFacade _sellerFacade;
        private readonly ISellerInventoryFacade _sellerInventoryFacade;
        public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
        {
            _sellerFacade = sellerFacade;
            _sellerInventoryFacade = sellerInventoryFacade;
        }
        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSellerByfilter([FromQuery]SellerFilterParams @params)
        {
            var result = await _sellerFacade.GetSellerByFilter(@params);
            return QueryResult(result);
        }
        [HttpGet("{Id}")]
        public async Task<ApiResult<SellerDto>> GetSellerById(long Id)
        {
            var result = await _sellerFacade.GetSellerById(Id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> Createseller(CreateSellerCommand command)
        {
            var result = await _sellerFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPost("SellerInvantory")]
        public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
        {
            var result = await _sellerInventoryFacade.Add(command);
            return CommandResult(result);
        }
        [HttpPut("SellerInvantory")]
        public async Task<ApiResult> EditSellerInventory(EditSellerInaventoryCommand command)
        {
            var result = await _sellerInventoryFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
