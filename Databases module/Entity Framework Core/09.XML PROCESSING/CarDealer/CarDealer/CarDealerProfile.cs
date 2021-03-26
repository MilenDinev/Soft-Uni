namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DataTransferObjects.Export;
    using CarDealer.DataTransferObjects.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
           this.CreateMap<CustomerImportModel, Customer>();
           this.CreateMap<SaleImportModel, Sale>();
           this.CreateMap<Car, CarExportModel>();
           this.CreateMap<Car, CarMakeExportModel>();
        }
    }
}
