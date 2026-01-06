using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using CarWorkshopAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly CarWorkshopDbContext _context;
    private readonly IMapper _mapper;
    public VehiclesController(CarWorkshopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPut]
    public async Task<IActionResult> AddVehicle(VehicleInfoDto vehicleInfoDto)
    {
        var vehicle = _mapper.Map<Vehicle>(vehicleInfoDto);
        _context.Vehicles.Add(vehicle);
        
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<VehicleInfoDto>>> GetVehicle()
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        
        var vehicleInfoDtos = _mapper.Map<List<VehicleInfoDto>>(vehicles);

        return Ok(vehicleInfoDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleInfoDto>> GetVehicleById(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null) return NotFound();
        
        var vehicleInfoDto = _mapper.Map<VehicleInfoDto>(vehicle);

        return Ok(vehicleInfoDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        Vehicle vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null) return NotFound();
        
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}