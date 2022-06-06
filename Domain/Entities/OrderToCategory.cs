using Domain.Common;

namespace Domain.Entities
{
    public class OrderToCategory : BaseEntity
    {
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
