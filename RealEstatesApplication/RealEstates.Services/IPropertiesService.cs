﻿namespace RealEstates.Services
{
    using RealEstates.Services.Models;
    using System.Collections.Generic;

    public interface IPropertiesService
    {
        void Add(string district, int price, 
            int floor, int maxFloor, int size, int yardSize,
            int year, string propertyType, string buildingType);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);

        decimal AveragePricePerSquareMeter();
    }
}
