using MediatR;

namespace WebService.Application.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}
