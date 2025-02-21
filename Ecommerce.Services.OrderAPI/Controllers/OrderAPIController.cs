using AutoMapper;
using Ecommerce.Services.OrderAPI.Data;
using Ecommerce.Services.OrderAPI.Models;
using Ecommerce.Services.OrderAPI.Models.Dto;
using Ecommerce.Services.OrderAPI.Service.IService;
using Ecommerce.Services.OrderAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        protected Response _response;
        private IMapper _mapper;
        private readonly AppDbContext _db;
        private IProductService _productService;
        private readonly IConfiguration _configuration;
        public OrderAPIController(AppDbContext db,
            IProductService productService, IMapper mapper, IConfiguration configuration
            )
        {
            _db = db;
            this._response = new Response();
            _productService = productService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet("GetOrders")]
        public Response? Get(string? userId = "")
        {
            try
            {
                IEnumerable<OrderHeader> objList;
                if (User.IsInRole(SD.RoleAdmin))
                {
                    objList = _db.OrderHeaders.Include(u => u.OrderDetails).OrderByDescending(u => u.OrderHeaderId).ToList();
                }
                else
                {
                    objList = _db.OrderHeaders.Include(u => u.OrderDetails).Where(u => u.UserId == userId).OrderByDescending(u => u.OrderHeaderId).ToList();
                }
                _response.Result = _mapper.Map<IEnumerable<OrderHeaderDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [Authorize]
        [HttpGet("GetOrder/{id:int}")]
        public Response? Get(int id)
        {
            try
            {
                OrderHeader orderHeader = _db.OrderHeaders.Include(u => u.OrderDetails).First(u => u.OrderHeaderId == id);
                _response.Result = _mapper.Map<OrderHeaderDto>(orderHeader);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<Response> CreateOrder([FromBody] CartDto cartDto)
        {
            try
            {
                OrderHeaderDto orderHeaderDto = _mapper.Map<OrderHeaderDto>(cartDto.CartHeader);
                orderHeaderDto.OrderTime = DateTime.Now;
                orderHeaderDto.Status = SD.Status_Pending;
                orderHeaderDto.OrderDetails = _mapper.Map<IEnumerable<OrderDetailsDto>>(cartDto.CartDetails);
                orderHeaderDto.OrderTotal = Math.Round(orderHeaderDto.OrderTotal, 2);
                OrderHeader orderCreated = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderHeaderDto)).Entity;
                await _db.SaveChangesAsync();

                orderHeaderDto.OrderHeaderId = orderCreated.OrderHeaderId;
                _response.Result = orderHeaderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [Authorize]
        [HttpPost("UpdateOrderStatus/{orderId:int}")]
        public async Task<Response> UpdateOrderStatus(int orderId, [FromBody] string newStatus)
        {
            try
            {
                OrderHeader orderHeader = _db.OrderHeaders.First(u => u.OrderHeaderId == orderId);
                 orderHeader.Status = newStatus;
                 _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}
