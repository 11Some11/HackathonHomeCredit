using System;

#nullable disable

namespace CatalogMicroservice
{
    public partial class Producer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] YearFounded { get; set; }
        public Guid Id { get; set; }
        public string PhotoUrl { get; set; }
    }
}
