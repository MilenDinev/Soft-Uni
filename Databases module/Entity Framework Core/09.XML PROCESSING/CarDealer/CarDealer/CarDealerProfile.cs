namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DataTransferObjects.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //this.CreateMap<SupplierImportModel, Supplier>();
            //this.CreateMap<PartImportModel, Part>();
            this.CreateMap<CustomerImportModel, Customer>();
           //this.CreateMap<SaleImportModel, Sale>();
        }
    }
}
