using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Behaviours
{
    public class UnhandleExceptionBehaivour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandleExceptionBehaivour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try 
            {
                return await next();
            }
            catch(Exception e) 
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(e,$"en la AplicationRequest{requestName}: {request}");
                throw;
            }
        }
    }
}
