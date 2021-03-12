namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DataTransferObjects;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
        }
    }
}
