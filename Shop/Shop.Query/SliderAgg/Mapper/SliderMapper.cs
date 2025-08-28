using Shop.Domain.SiteEntities;
using Shop.Query.SliderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shop.Query.SliderAgg.Mapper
{
    public static class SliderMapper
    {
        public static SliderDto Map(this Slider slider)
        {
            return new SliderDto()
            {
                CreationDate = slider.CreationDate,
                Id = slider.Id,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title,
            };
        }

        public static List<SliderDto> MapList(this List<Slider> slider)
        {
            var model = new List<SliderDto>();

            slider.ForEach(s =>
            {
                model.Add(new SliderDto()
                {
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    ImageName = s.ImageName,
                    Link = s.Link,
                    Title = s.Title,
                } );
            });
            return model;
        }
    }
}
