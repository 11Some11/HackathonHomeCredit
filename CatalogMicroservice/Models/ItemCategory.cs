using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CatalogMicroservice
{
    public partial class ItemCategory
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}
