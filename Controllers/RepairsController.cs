using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRepairApi.Data;
using SmartRepairApi.Dtos.Common;
using SmartRepairApi.Dtos.Repair;
using SmartRepairApi.Extensions;
using SmartRepairApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartRepairApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepairsController : ControllerBase
    {
        private readonly AppDbContext _context; // injection of AppDbContext
        private readonly IMapper _mapper; // injection of IMapper

        public RepairsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Repairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetRepairs(
            [FromQuery] RepairQueryParameters param)
        {
            // Build query with filtering, sorting, and pagination
            var query = _context.Repairs
                .Include(r => r.Client) // Include related Client
                .AsQueryable();

            query = query.ApplyFiltering(param); // Apply filtering
            query = query.ApplySorting(param.Sort); // Apply sorting

            // Apply pagination and get paged result
            var paged = await query.ToPagedResultAsync(param.Page, param.PageSize);

            // Map to PagedResult<RepairDto>
            var dto = new PagedResult<RepairDto>
            {
                Items = _mapper.Map<IEnumerable<RepairDto>>(paged.Items), // Map entities to DTOs
                Page = paged.Page, // Copy pagination info
                PageSize = paged.PageSize,
                TotalItems = paged.TotalItems,
                TotalPages = paged.TotalPages
            };

            // Return the paged DTO result
            return Ok(dto);
        }

        // GET: api/Repairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairDto>> GetRepair(int id)
        {

            // Fetch repair with related client
            var repair = await _context.Repairs
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (repair == null)
                return NotFound();

            return _mapper.Map<RepairDto>(repair); // Map entity to DTO
        }

        // POST: api/Repairs  
        [HttpPost]
        public async Task<ActionResult<RepairDto>> PostRepair(
            [FromBody] RepairCreateDto repairDto,
            [FromServices] IValidator<RepairCreateDto> validator)
        {
            // 1. Async validation
            var validationResult = await validator.ValidateAsync(repairDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // 2. Mapping DTO → ENTITY
            var repair = _mapper.Map<Repair>(repairDto);

            // 3. Save to DB
            await _context.Repairs.AddAsync(repair);
            await _context.SaveChangesAsync();

            // 4. Return DTO
            var result = _mapper.Map<RepairDto>(repair);
            return CreatedAtAction(nameof(GetRepair), new { id = repair.Id }, result);
        }

        // PUT: api/Repairs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepair(
            int id, 
            [FromBody] RepairUpdateDto repairDto,
            [FromServices] IValidator<RepairUpdateDto> validator)
        {
            // Validate input
            var validationResult = await validator.ValidateAsync(repairDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Find existing repair
            var repair = await _context.Repairs.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }

            // Apply updates via AutoMapper
            _mapper.Map(repairDto, repair);

            await _context.SaveChangesAsync();

            return NoContent(); // Standard response for successful PUT without body
        }

        // DELETE: api/Repairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            // Find existing repair
            var repair = await _context.Repairs.FindAsync(id);

            if (repair == null)
                return NotFound();

            // Remove from DB
            _context.Repairs.Remove(repair);
            await _context.SaveChangesAsync();

            // 204 No Content
            return NoContent(); // Standard response for successful DELETE without body
        }
    }
}
