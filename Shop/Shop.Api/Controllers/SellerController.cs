using Common.AspNetCore;
using Common.AspNetCore.ClaimUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.SellerAgg;
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
        [PermissionChecker(Permission.Seller_Panel)]
        public async Task<ApiResult<SellerFilterResult>> GetSellerByfilter([FromQuery] SellerFilterParams @params)
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
        [Authorize]
        [HttpGet("current")]
        public async Task<ApiResult<SellerDto>> GetByUserId()
        {
            var result = await _sellerFacade.GetByUserId(User.GetUserId());
            return QueryResult(result);
        }
        [HttpPost]
        [PermissionChecker(Permission.Seller_Panel)]
        public async Task<ApiResult> Createseller(CreateSellerCommand command)
        {
            var result = await _sellerFacade.Create(command);
            return CommandResult(result);
        }
        [HttpPut]
        [PermissionChecker(Permission.Seller_Panel)]
        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacade.Edit(command);
            return CommandResult(result);
        }
        [PermissionChecker(Permission.Seller_Panel)]
        [HttpPost("SellerInvantory")]
        public async Task<ApiResult> AddSellerInventory(AddSellerInventoryCommand command)
        {
            var result = await _sellerInventoryFacade.Add(command);
            return CommandResult(result);
        }
        [PermissionChecker(Permission.Seller_Panel)]
        [HttpPut("SellerInvantory")]
        public async Task<ApiResult> EditSellerInventory(EditSellerInaventoryCommand command)
        {
            var result = await _sellerInventoryFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpGet("Inventory/{InventoriId}")]
        public async Task<ApiResult<SellerInventoryDto>> GetInventoryById(long InventoryId)
        {
            var result = await _sellerInventoryFacade.GetById(InventoryId);

            if(result == null)
            return QueryResult(new SellerInventoryDto());

            return QueryResult(result);
        }
        [HttpGet("Inventory")]
        public async Task<ApiResult<List<SellerInventoryDto>>> GetAllInventory()
        {
            var seller = await _sellerFacade.GetSellerById(User.GetUserId());
            if (seller == null)
                return QueryResult(new List<SellerInventoryDto>());

            var result = await _sellerInventoryFacade.GetAll(seller.Id);
            return QueryResult(result);
        }
        
    }
}
