﻿using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Application.Services;
using RestaurantOrder.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderService.GetAll();
        }

        [HttpGet("{input}")]
        public async Task<string> Get(string input)
        {
            return await _orderService.Order(input);
        }
        
        [HttpPost]
        public async Task<Order> Post([FromBody]Order order)
        {
            order.Output = await _orderService.Order(order.Input);
            return order;
        }
    }
}
