using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RESTfulAPI.Dto;
using RESTfulAPI.DTO;
using RESTfulAPI.Filter;
using RESTfulAPI.Services;
using System;
using System.Threading.Tasks;

namespace RESTfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlackSmithsController : ControllerBase
    {
        private readonly IBlackSmithService _blackSmithService;
        private readonly IMapper _mapper;

        public BlackSmithsController(IBlackSmithService blackSmithService, IMapper mapper)
        {
            _blackSmithService = blackSmithService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _blackSmithService.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> FilterFromQuery([FromQuery] BlackSmithFilter filter)
        {
            var blackSmiths = await _blackSmithService.FindAllAsync(x =>
            (filter.Guild == null || x.Guild == filter.Guild)
            &&
            (filter.Name == null || x.Name == filter.Name)
            &&
            (filter.Race == null || x.Race == filter.Race)
            );

            return Ok(blackSmiths);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UpsertBlackSmith blackSmith)
        {
            var blackSmithDto = _mapper.Map<BlackSmithDto>(blackSmith);

            blackSmithDto = await _blackSmithService.CreateAsync(blackSmithDto);

            return Created($"/blacksmiths/{blackSmithDto.Id}", blackSmithDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Upsert([FromRoute] Guid id, [FromBody] UpsertBlackSmith blackSmith)
        {
            var blackSmithDto = _mapper.Map<BlackSmithDto>(blackSmith);
            blackSmithDto.Id = id;

            blackSmithDto = await _blackSmithService.UpdateAsync(blackSmithDto);

            return Ok(blackSmithDto);
        }

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch([FromRoute] Guid id, [FromBody] JsonPatchDocument<BlackSmithDto> patch)
        {
            var blackSmith = await _blackSmithService.GetAsync(id);

            patch.ApplyTo(blackSmith, ModelState);

            if (!TryValidateModel(blackSmith))
            {
                return BadRequest(ModelState);
            }

            blackSmith = await _blackSmithService.UpdateAsync(blackSmith);

            return Ok(blackSmith);
        }

        //Ez csak arra példa, ha a BlackSmith lenne a top-level resource
        [HttpGet("{id:guid}/swords")]
        public async Task<IActionResult> GetSwordsByBlackSmith([FromRoute] Guid id)
        {
            var blackSmith = await _blackSmithService.GetAsync(id);

            return Ok(blackSmith.Swords);
        }
    }
}
