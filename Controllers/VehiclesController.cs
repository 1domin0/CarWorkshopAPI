using CarWorkshopAPI.Commands.AddVehicle;
using CarWorkshopAPI.Commands.DeleteVehicle;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Queries.GetVehicle;
using CarWorkshopAPI.Queries.GetVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace CarWorkshopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IMediator _mediator) : ControllerBase
{

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