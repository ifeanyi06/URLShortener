using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Wrappers;

namespace API.Services
{
    public interface IShortLinkService
    {
        Task<string> CreateShortLink(CreateShortURLRequest request);
        Task<string> GetRedirectLink(string url);
    }
}
