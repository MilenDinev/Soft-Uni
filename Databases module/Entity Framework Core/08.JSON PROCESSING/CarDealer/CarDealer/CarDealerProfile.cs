namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO;
    using CarDealer.Models;


    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputModel, Supplier>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<CarInputModel, Car>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();
        }
    }
}
