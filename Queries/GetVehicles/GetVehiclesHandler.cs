using AutoMapper;
using CarWorkshopAPI.Data;
using CarWorkshopAPI.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshopAPI.Queries.GetVehicles;

public class GetVehiclesHandler(CarWorkshopDbContext _context, IMapper _mapper) : IRequestHandler<GetVehiclesQuery, List<VehicleInfoDto>>
{
    public async Task<List<VehicleInfoDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Vehicles.AsQueryable();

        if (!string.IsNullOrEmpty(request.Brand))
            query = query.Where(v => v.Brand == request.Brand);
        if (!string.IsNullOrEmpty(request.Model))
            query = query.Where(v => v.Model == request.Model);

        if (!string.IsNullOrEmpty(request.SortBy))
        {
            var isDesc = request.SortDir?.ToLower() == "desc";

            query = request.SortBy.ToLower() switch
            {
                "brand" => isDesc 
                    ? query.OrderByDescending(v => v.Brand)
                    : query.OrderBy(v => v.Brand),

                "model" => isDesc
                    ? query.OrderByDescending(v => v.Model)
                    : query.OrderBy(v => v.Model),
                "year" => isDesc
                    ? query.OrderByDescending(v => v.Year)
                    : query.OrderBy(v => v.Year),
                
                _ => query
            };
        }
        
        var vehicles = await query.ToListAsync();
        return _mapper.Map<List<VehicleInfoDto>>(vehicles);
    }
}