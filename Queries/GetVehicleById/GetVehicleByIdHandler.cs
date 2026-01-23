using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
namespace CarWorkshopAPI.Queries.GetVehicle;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, VehicleInfoDto>
{
    private readonly CarWorkshopDbContext _context;
    private readonly IMapper _mapper;

    public GetVehicleByIdHandler(CarWorkshopDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VehicleInfoDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles.FindAsync(request.Id);
        
        if (vehicle == null) return null;
            
        var vehicleInfoDto = _mapper.Map<VehicleInfoDto>(vehicle);
        return vehicleInfoDto;
    }
}