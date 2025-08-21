using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommand:IBaseCommand
    {
        public long BannerId { get; set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile{ get; private set; }
        public BannerPosition Position { get; private set; }

        public EditBannerCommand(string link, IFormFile? iMageFile, BannerPosition position)
        {
            Link = link;
            ImageFile = iMageFile;
            Position = position;
        }
    }
}
