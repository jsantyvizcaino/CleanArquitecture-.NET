using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper,
            IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation($"Streamer {newStreamer.Id} se creo exitosamente");
            await SendEmail(newStreamer);
            return newStreamer.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "jorge_santiagovizcaino@hotmail.com",
                Body = "prueba de email",
                Subject = "mensaje de alerta"
            };


            try
            {
                await _emailService.SendEmail(email);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar email: {ex}");
            }

        }
    }
}
