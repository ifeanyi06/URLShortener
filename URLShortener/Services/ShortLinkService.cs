using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Application.Utility;

namespace API.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ShortLinkService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreateShortLink(CreateShortURLRequest request)
        {
            var link = new ShortLink();
            link.Url = request.Url;
            link.ShortUrl = "";
            var shortenedUrl = await _unitOfWork.ShortLinkRepository().AddAsync(link);
            _unitOfWork.Commit();

            shortenedUrl.ShortUrl = CreatShortURL(shortenedUrl.Id);
            _unitOfWork.Commit(); 
            return shortenedUrl.ShortUrl;
        }

        public async Task<string> GetRedirectLink(string shortenedUrl)
        {
            var resp = await _unitOfWork.ShortLinkRepository().GetAllAsync();
            string url = resp.Where(x => x.ShortUrl == shortenedUrl).FirstOrDefault().Url;
            return  url;
        }

        private string CreatShortURL(long Id)
        {
            return _configuration["DefaultApplicationURL"] + Base62Converter.Convert(Id);
        }
    }
}
