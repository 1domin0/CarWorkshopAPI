using FluentValidation;
using MediatR;

namespace CarWorkshopAPI.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> _validators)
                : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine("Test");
        var context = new ValidationContext<TRequest>(request);
        
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0) throw new ValidationException(failures);

        return await next(cancellationToken);
    }
}