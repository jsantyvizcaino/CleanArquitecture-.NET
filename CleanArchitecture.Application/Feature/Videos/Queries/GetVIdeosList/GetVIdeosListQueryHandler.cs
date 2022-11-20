using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Feature.Videos.Queries.GetVIdeosList
{
    public class GetVIdeosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository _videoRepository;
        public readonly IMapper _mapper;

        public GetVIdeosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByUsername(request._Username);

            return _mapper.Map<List<VideosVm>>(videoList);
        }
    }
}
