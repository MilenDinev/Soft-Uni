namespace RealEstates.Services
{
    using RealEstates.Data;
    using RealEstates.Services.Models;
    using System.Collections.Generic;


    public class DistrictsService : IDistrictService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            return new List<DistrictInfoDto>();
        }
    }
}
