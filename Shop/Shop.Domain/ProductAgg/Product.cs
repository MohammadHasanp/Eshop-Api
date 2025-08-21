using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilitis;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        //For EfCore
        private Product() { }
        //Title Product
        public string Title { get; private set; }
        //Image Product
        public string ImageName { get; private set; }
        //Description Product
        public string Description { get; private set; }
        //Catogore Product
        public long CategoryId { get; private set; }
        //SubCateogory
        public long SubCategoryId { get; private set; }
        //SecondarySubCategory Product
        public long SecondarySubCategory { get; private set; }
        //Slug Product
        public string Slug { get; private set; }
        //For Seo
        public SeoData SeoData { get; private set; }
        //Relation With ProductImage
        public List<ProductImage> Images { get; set; }
        //Relation with Product Specification
        public List<ProductSpecification> Specifications { get; private set; }
        //Set Product
        public Product(string title,string imageName, string description, long categoryId, long subCategoryId
            , long secondarySubCategory, string slug, SeoData seoData,IProductService productService)
        {
            NullOrEmptyDomainDataException.CheckString((imageName,nameof(imageName)));
            Guard(title, description, slug, productService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategory = secondarySubCategory;
            Slug = slug.ToSlug();
            SeoData = seoData;
            //Specifications = new List<ProductSpecification>();
            //Images = new List<ProductImage>();
        }
        //Edit Product
        public void Edit(string title, string description, long categoryId, long subCategoryId
            , long secondarySubCategory, string slug, SeoData seoData,IProductService productService)
        {
            Guard(title,description,slug,productService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategory = secondarySubCategory;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        //AddAsync Image
        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }
        //Set Specification
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(e => e.ProductId = Id);
            Specifications = specifications;
        }
        //Remove Image
        public string RemoveImage(long imagesId)
        {
            var oldImage = Images.FirstOrDefault(i => i.Id == imagesId);
            if (oldImage == null)
                throw new NullOrEmptyDomainDataException("Not Found Image");
            Images.Remove(oldImage);
            return oldImage.ImageName;
        }
        //Ser Image Product
        public void SetImageProduct(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString((imageName, nameof(imageName)));
            ImageName = imageName;
        }
        //Validation
        public void Guard(string title, string description, string slug, IProductService service)
        {
            NullOrEmptyDomainDataException.CheckString((title, nameof(title))
                , (description, nameof(description)), (slug.ToSlug(), nameof(slug)));
            if (Slug != slug)
                if (service.IsExistSlug(slug.ToSlug()))
                    throw new SlugIsDuplicateException("Slug Invalid");
        }
    }
}
