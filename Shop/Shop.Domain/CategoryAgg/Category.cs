using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilitis;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get;private set; }
        public SeoData SeoData{ get;private set; }
        public long? ParentId { get;private set; }
        public List<Category> Childs { get; set; }

        private Category() 
        {
            Childs = new List<Category>();

        }

        public Category(string title, string slug, SeoData seoData,ICategoryDomainServices categoryDomain)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, categoryDomain);
            Title = title;
            Slug = slug;
            SeoData = seoData;
            Childs = new List<Category>();
        }
        public void Edit(string title,string slug,SeoData seoData,ICategoryDomainServices categoryDomain)
        {
            slug = slug?.ToSlug();
            Guard(title,slug,categoryDomain);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
        public void AddChild(string title,string slug,SeoData seoData,ICategoryDomainServices categoryDomain)
        {
            Childs.Add(new Category(title, slug, seoData, categoryDomain)
            {
                ParentId = Id
            });
        }
        public void Guard(string title,string slug,ICategoryDomainServices categoryDomain)
        {
            NullOrEmptyDomainDataException.CheckString((title,nameof(title)),(slug,nameof(slug)));
            if (Slug != slug)
                if (categoryDomain.IsExistSlug(slug))
                    throw new SlugIsDuplicateException("Slug InValid");
        }
    }
}
