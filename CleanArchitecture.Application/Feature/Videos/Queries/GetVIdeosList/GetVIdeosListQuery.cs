﻿using MediatR;

namespace CleanArchitecture.Application.Feature.Videos.Queries.GetVIdeosList
{
    public class GetVideosListQuery:IRequest<List<VideosVm>>
    {
        public string _Username { get; set; } =String.Empty;

        public GetVideosListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));    
        }
    }
}
