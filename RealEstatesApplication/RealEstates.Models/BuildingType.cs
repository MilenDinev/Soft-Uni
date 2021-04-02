namespace RealEstates.Models
{
    using System.Collections.Generic;

    public class BuildingType
    {
        public BuildingType()
        {
            this.Properties = new HashSet<Property>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
