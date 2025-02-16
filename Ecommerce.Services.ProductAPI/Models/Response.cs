﻿namespace Ecommerce.Services.ProductAPI.Models
{
    public class Response
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}