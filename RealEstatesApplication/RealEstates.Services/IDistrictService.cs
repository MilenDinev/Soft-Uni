namespace RealEstates.Services
{
    using RealEstates.Services.Models;
    using System.Collections.Generic;
    public interface IDistrictService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
    }
   
}
