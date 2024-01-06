using BizLand.Business.DTOs.SliderDto;
using BizLand.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BizLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 201)]

        public async Task<IActionResult> GetAll()
        {
            var slider = await _sliderService.GetAllAsync();
            return Ok(slider);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            return Ok(slider);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto dto)
        {
            await _sliderService.Create(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Update([FromForm] SliderUpdateDto dto)
        {
            await _sliderService.Update(dto);
            return Ok();
        }


        [HttpPatch("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 204)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _sliderService.SoftDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]

        [ProducesResponseType(typeof(int), 204)]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.Delete(id);
            return NoContent();
        }

    }
}