
namespace Common.Domain.ValueObjects
{
    public class SeoData:ValueObject
    {
        public string MetaTitle { get;private set; }
        public string MetaDescription { get; private set; }
        public string MateKeyWords { get; private set; }
        public string IndexPage { get; set; }
        public string Canonical { get;private set; }
        public string Schema { get; private set; }

        public SeoData(string metaTitle, string metaDescription, string mateKeyWords, string indexPage, string canonical, string schema)
        {
            MetaTitle = metaTitle;
            MetaDescription = metaDescription;
            MateKeyWords = mateKeyWords;
            IndexPage = indexPage;
            Canonical = canonical;
            Schema = schema;
        }
        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }
        private SeoData() { }
    }
}
