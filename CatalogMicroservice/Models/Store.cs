using System;

#nullable disable

namespace CatalogMicroservice
{
    public partial class Store
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public Guid Id { get; set; }
        public Guid StoreCategoryId { get; set; }
    }
}
