using CarWorkshopAPI.Dtos;
using MediatR;
using Microsoft.Identity.Client;

namespace CarWorkshopAPI.Queries.GetVehicles;

public record GetVehiclesQuery : IRequest<List<VehicleInfoDto>>{
    public string? Brand { get; init; }
    public string? Model { get; init; }
    public string? Year { get; init; }

    public string? SortBy { get; init; }
    public string? SortDir { get; init; }
}