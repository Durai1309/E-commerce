﻿using Ecommerce.Web.Models;
using Ecommerce.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Ecommerce.Web.Controllers
{
        public class CartController : Controller
        {
            private readonly ICartService _cartService;
            private readonly IOrderService _orderService;
            public CartController(ICartService cartService, IOrderService orderService)
            {
                _cartService = cartService;
                _orderService = orderService;
            }

            [Authorize]
            public async Task<IActionResult> CartIndex()
            {
                return View(await LoadCartDtoBasedOnLoggedInUser());
            }

            [Authorize]
            public async Task<IActionResult> Checkout()
            {
                return View(await LoadCartDtoBasedOnLoggedInUser());
            }
        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> Checkout(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader.Phone = cartDto.CartHeader.Phone;
            cart.CartHeader.Email = cartDto.CartHeader.Email;
            cart.CartHeader.Name = cartDto.CartHeader.Name;

            var response = await _orderService.CreateOrder(cart);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Confirmation"); 
            }
            return View();
        }


        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
            {
                var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
                Response? response = await _cartService.RemoveFromCartAsync(cartDetailsId);
                if (response != null & response.IsSuccess)
                {
                    TempData["success"] = "Cart updated successfully";
                    return RedirectToAction(nameof(CartIndex));
                }
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
            {

                Response? response = await _cartService.ApplyCouponAsync(cartDto);
                if (response != null & response.IsSuccess)
                {
                    TempData["success"] = "Cart updated successfully";
                    return RedirectToAction(nameof(CartIndex));
                }
                return View();
            }


            [HttpPost]
            public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
            {
                cartDto.CartHeader.CouponCode = "";
                Response? response = await _cartService.ApplyCouponAsync(cartDto);
                if (response != null & response.IsSuccess)
                {
                    TempData["success"] = "Cart updated successfully";
                    return RedirectToAction(nameof(CartIndex));
                }
                return View();
            }


            private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
            {
                var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
                Response? response = await _cartService.GetCartByUserIdAsnyc(userId);
                if (response != null & response.IsSuccess)
                {
                    CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
                    return cartDto;
                }
                return new CartDto();
            }
        }
    }