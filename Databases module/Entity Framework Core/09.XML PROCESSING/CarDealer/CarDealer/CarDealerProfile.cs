namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DataTransferObjects.Export;
    using CarDealer.DataTransferObjects.Import;
    using CarDealer.Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CustomerImportModel, Customer>();
            this.CreateMap<SaleImportModel, Sale>();
            this.CreateMap<Car, CarExportModel>();
            this.CreateMap<Car, CarMakeExportModel>();
            this.CreateMap<Customer, CustomerExportModel>()
                  .ForMember(x => x.BoughtCars,
                  source => source.MapFrom(x => x.Sales.Count))
                  .ForMember(x => x.SpentMoney,
                  source => source.MapFrom(x => x.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))));


            
        }
    }
}
