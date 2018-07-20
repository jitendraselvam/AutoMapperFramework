using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoMapperPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputationalMappingController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ComputationalMappingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a ComputationalViewModel Object mapped from ShoppingBag Object with total Price computed
        /// </summary>
        /// <response code="200">Computed the price of the items in list</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingBagDto), 200)]
        public ActionResult<ShoppingBagDto> Get()
        {
            var shoppingBagWithoutTotalCost = _mapper.Map<ShoppingBagDto>(SampleShoppingBag);
            shoppingBagWithoutTotalCost.TotalCost = SampleShoppingBag.Items.Sum(items => items.Price);
            return shoppingBagWithoutTotalCost;
        }

        private static ShoppingBag SampleShoppingBag => new ShoppingBag
        {
            Owner = "John Doe",
            ShopName = "Krogers",
            Items = new [] {
                new Item("Apples",2),
                new Item("Chocolates",5),
                new Item("Chicken",3),
            }.ToList()
        };
    }
}