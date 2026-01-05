using AutoMapper;
using Udemy.Catalog.DTOs.AboutDto;
using Udemy.Catalog.DTOs.BrandDto;
using Udemy.Catalog.DTOs.CategoryDtos;
using Udemy.Catalog.DTOs.ContactDtos;
using Udemy.Catalog.DTOs.DailySpecialOfferDtos;
using Udemy.Catalog.DTOs.FeatureSliderDtos;
using Udemy.Catalog.DTOs.GeneralSpecialOfferDtos;
using Udemy.Catalog.DTOs.OfferDiscountDtos;
using Udemy.Catalog.DTOs.ProductDetailDtos;
using Udemy.Catalog.DTOs.ProductDtos;
using Udemy.Catalog.DTOs.ProductImagesDtos;
using Udemy.Catalog.Entities;

namespace Udemy.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, UpdateProductsImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductsImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductsImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductsImageDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<GeneralSpecialOffer, ResultGeneralSpecialOfferDto>().ReverseMap();
            CreateMap<GeneralSpecialOffer, CreateGeneralSpecialOfferDto>().ReverseMap();
            CreateMap<GeneralSpecialOffer, UpdateGeneralSpecialOfferDto>().ReverseMap();
            CreateMap<GeneralSpecialOffer, GetByIdGeneralSpecialOfferDto>().ReverseMap();

            CreateMap<DailySpecialOffer, ResultDailySpecialOfferDto>().ReverseMap();
            CreateMap<DailySpecialOffer, CreateDailySpecialOfferDto>().ReverseMap();
            CreateMap<DailySpecialOffer, UpdateDailySpecialOfferDto>().ReverseMap();
            CreateMap<DailySpecialOffer, GetByIdDailySpecialOfferDto>().ReverseMap();


            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();




        }
    }
}
