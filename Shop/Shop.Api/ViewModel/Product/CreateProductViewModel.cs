using Newtonsoft.Json;
using Shop.Api.ViewModel.Category;

namespace Shop.Api.ViewModel.Product
{
    public class CreateProductViewModel
    {
        public string Title { get;  set; }
        public IFormFile ImageFile { get;  set; }
        public string Description { get;  set; }
        public long CategoryId { get;  set; }
        public long SubCategoryId { get;  set; }
        public long SecondarySubCategory { get;  set; }
        public string Slug { get;  set; }
        public SeoDataViewModel SeoData { get;  set; }
        public string Specifications { get; set; }


        public Dictionary<string,string> GetSpecification()
        {
            return JsonConvert.DeserializeObject<Dictionary<string,string>>(Specifications);
        }
    }
    public class EditProductViewModel
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public long SecondarySubCategory { get; set; }
        public string Slug { get; set; }
        public SeoDataViewModel SeoData { get; set; }
        public string Specifications { get; set; }
        public Dictionary<string, string> GetSpecification()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(Specifications);
        }
    }
    public class AddProductImageViewModel
    {
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int Sequence { get; set; }
    }
    public class RemoveProductImageViewModel
    {
        public long productId { get;  set; }
        public long ImageId { get; set; }
    }

}
