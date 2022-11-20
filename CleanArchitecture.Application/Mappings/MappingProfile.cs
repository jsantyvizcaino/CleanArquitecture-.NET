using AutoMapper;
using CleanArchitecture.Application.Feature.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Feature.Videos.Queries.GetVIdeosList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand, Streamer>();
        }
    }
}
