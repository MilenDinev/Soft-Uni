namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportModel, User>();
            this.CreateMap<ProductImportModel, Product>();
        }
    }
}
