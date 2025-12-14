using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRepairApi.Data;
using SmartRepairApi.Dtos.Client;
using SmartRepairApi.Dtos.Common;
using SmartRepairApi.Extensions;
using SmartRepairApi.Models;

namespace SmartRepairApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClientsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients(
            [FromQuery] ClientQueryParameters param)
        {
            // Start with the full clients query
            var query = _context.Clients.AsQueryable();

            query = query.ApplyFiltering(param); // Filtering extension method
            query = query.ApplySorting(param.Sort); // Sorting extension method

            // Paging
            var paged = await query.ToPagedResultAsync(param.Page, param.PageSize);

            // Map to DTO
            var dto = new PagedResult<ClientDto>
            {
                Items = _mapper.Map<IEnumerable<ClientDto>>(paged.Items),
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalItems = paged.TotalItems,
                TotalPages = paged.TotalPages
            };

            return Ok(dto); // Return 200 with paged DTO
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            return _mapper.Map<ClientDto>(client);
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<ClientDto>> PostClient(
            [FromBody] ClientCreateDto clientDto,
            [FromServices] IValidator<ClientCreateDto> validator)
        {
            var validationResult = await validator.ValidateAsync(clientDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var client = _mapper.Map<Client>(clientDto);

            await _context.Clients.AddAsync(client); // Changed to use AddAsync to fix S6966
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ClientDto>(client);

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, result);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(
            int id, 
            [FromBody] ClientUpdateDto clientDto,
            [FromServices] IValidator<ClientUpdateDto> validator)
        {
            // Validate input
            var validationResult = await validator.ValidateAsync(clientDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Find existing client
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            // Apply updates
            _mapper.Map(clientDto, client);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
