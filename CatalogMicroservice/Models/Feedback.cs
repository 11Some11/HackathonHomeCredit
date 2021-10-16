using System;

#nullable disable

namespace CatalogMicroservice
{
    public partial class Feedback
    {
        public string Text { get; set; }
        public string Rating { get; set; }
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
