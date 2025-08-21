using Common.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.Sellers.Create;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommand : IBaseCommand
    {
        public string Link { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }

        public CreateBannerCommand(string link, IFormFile imageFile, BannerPosition position)
        {
            Link = link;
            ImageFile = imageFile;
            Position = position;
        }
    }
}
