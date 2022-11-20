﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Feature.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand : IRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Url { get; set; } =  string.Empty;
    }
}
