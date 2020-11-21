using AutoMapper;
using DevbaseChallenge.API.Dtos;

using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevbaseChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? sort, string? searchString)
        {
            try
            {
                var products = await _productService.GetAllAsync();
                if (!string.IsNullOrEmpty(searchString))
                {
                    var filterProduct = await _productService.GetAllAsync(p => p.Name.Contains(searchString));

                    if (sort == "adı")
                    {
                        filterProduct = filterProduct.OrderBy(p => p.Name);
                        return Ok(_mapper.Map<IEnumerable<ProductDto>>(filterProduct));
                    }

                    if (sort == "artanfiyat")
                    {
                        filterProduct = filterProduct.OrderBy(p => p.Price);
                        return Ok(_mapper.Map<IEnumerable<ProductDto>>(filterProduct));
                    }

                    if (sort == "azalanfiyat")
                    {
                        filterProduct = filterProduct.OrderByDescending(p => p.Price);
                        return Ok(_mapper.Map<IEnumerable<ProductDto>>(filterProduct));
                    }

                    if (sort == "stok")
                    {
                        filterProduct = filterProduct.OrderByDescending(p => p.Stock);
                        return Ok(_mapper.Map<IEnumerable<ProductDto>>(filterProduct));
                    }
                    return Ok(_mapper.Map<IEnumerable<ProductDto>>(filterProduct));
                }

                if (sort == "adı")
                {
                    products = products.OrderBy(p => p.Name);
                    return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
                }
                if (sort == "artanfiyat")
                {
                    products = products.OrderBy(p => p.Price);
                    return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
                }
                if (sort == "azalanfiyat")
                {
                    products = products.OrderByDescending(p => p.Price);
                    return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
                }
                if (sort == "stok")
                {
                    products = products.OrderByDescending(p => p.Stock);
                    return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
                }

                return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productService.GetAsync(id);

                return Ok(_mapper.Map<ProductDto>(product));
            }
            catch (Exception )
            {

                return NotFound();
            }
          
        }          
        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
           

            try
            {
                var addedProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
                return Created(string.Empty, _mapper.Map<ProductDto>(addedProduct));
            }
            catch (Exception)
            {

                return BadRequest("Hatali Product Bilgileri.");
            }

              
            
           
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            try
            {
                _productService.Update(_mapper.Map<Product>(productDto));
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Hatali Product Bilgileri.");
            }
          
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _productService.GetAsync(id).Result;
                _productService.Remove(product);
                return NoContent();
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }
    }
}
