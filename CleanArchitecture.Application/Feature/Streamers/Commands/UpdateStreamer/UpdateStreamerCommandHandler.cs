using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository,
                                            IMapper mapper,
                                            IEmailService emailService,
                                            ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToTupdate = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerToTupdate == null)
            {
                _logger.LogError($"No se encntro el streamer Id: {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
                 
            };

            _mapper.Map(request,streamerToTupdate,typeof(UpdateStreamerCommand),typeof(Streamer));
            await _streamerRepository.UpdateAsync(streamerToTupdate);
            _logger.LogInformation($"Se actualizo el streamer {request.Id}");
            return Unit.Value;
        }
    }
}
