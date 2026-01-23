using AutoMapper;
using CarWorkshopAPI.Commands.AddVehicle;
using CarWorkshopAPI.Commands.DeleteVehicle;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Models;
using CarWorkshopAPI.Queries.GetVehicle;
using CarWorkshopAPI.Queries.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace CarWorkshopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly CarWorkshopDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public VehiclesController(CarWorkshopDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    // [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> AddVehicle(VehicleInfoDto vehicleInfoDto)
    {
        var vehicleId = await _mediator.Send(new AddVehicleCommand(vehicleInfoDto));
        return CreatedAtAction(nameof(GetVehicleById), new { id = vehicleId }, null);
    }
    // [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<VehicleInfoDto>>> GetVehicles()
    {
        return Ok(await _mediator.Send(new GetVehiclesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleInfoDto>> GetVehicleById(int id)
    {
        var vehicle = await _mediator.Send(new GetVehicleByIdQuery(id));
        
        if (vehicle == null) return NotFound();
        return Ok(vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        await _mediator.Send(new DeleteVehicleCommand(id));
        return NoContent();
    }
}