namespace Udemy.Catalog.settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string DailySpecialOfferCollectionName { get; set; }
        public string GeneralSpecialOfferCollectionName { get; set; }
        public string OfferDiscountCollectionName { get; set; }
        public string BrandCollectionName { get ; set ; }
        public string AboutCollectionName { get ; set ; }
        public string ContactCollectionName { get ; set ; }
    }
}
