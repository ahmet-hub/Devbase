using AutoMapper;
using DevbaseChallenge.API.Dtos;
using DevbaseChallenge.Core.Entities;
using DevbaseChallenge.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevbaseChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetAsync(id);

                return Ok(_mapper.Map<CategoryDto>(category));
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }

        [HttpGet]

        public async Task<IActionResult> GetAll(string? sort ,string? searchString)
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                if (!string.IsNullOrEmpty(searchString))
                {
                    var filterCategory = await _categoryService.GetAllAsync(p => p.Name.Contains(searchString));
                    if (sort== "adı")
                    {
                        filterCategory = filterCategory.OrderBy(c => c.Name);
                        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(filterCategory));

                    }
                    return Ok(_mapper.Map<IEnumerable<CategoryDto>>(filterCategory));
                }
                if (sort == "adı")
                {
                    categories = categories.OrderBy(c => c.Name);
                    return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));

                }

                return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));



            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            try
            {
                var addedCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
                return Created(string.Empty, _mapper.Map<CategoryDto>(addedCategory));
            }
            catch (Exception)
            {

                return BadRequest("Hatali Categori Bilgileri.");
            }

            
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            try
            {
                var updatedCategory = _categoryService.Update(_mapper.Map<Category>(categoryDto));

                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Hatali Categori Bilgileri.");
            }
           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var category = _categoryService.GetAsync(id).Result;
                _categoryService.Remove(category);
                return NoContent();
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }



    }
}
