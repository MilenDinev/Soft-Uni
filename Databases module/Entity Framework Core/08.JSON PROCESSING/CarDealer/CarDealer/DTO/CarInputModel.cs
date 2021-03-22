namespace CarDealer.DTO
{
    using System.Collections.Generic;

    public class CarInputModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }
        public ICollection<int> PartsId { get; set; }


    }
}
