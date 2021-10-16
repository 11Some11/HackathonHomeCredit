using System;

#nullable disable

namespace CatalogMicroservice
{
    public partial class Item
    {
        public Guid Id { get; set; }
        public float? Price { get; set; }
        public string PhotoUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? ProducerId { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal? Count { get; set; }
        public string CategoryName { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
