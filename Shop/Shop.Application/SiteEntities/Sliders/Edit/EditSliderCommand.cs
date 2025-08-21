using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand : IBaseCommand
    {
        public long SliderId { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }

        public EditSliderCommand(string title, string link, IFormFile? imageFile)
        {
            Title = title;
            Link = link;
            ImageFile = imageFile;
        }
    }

}
