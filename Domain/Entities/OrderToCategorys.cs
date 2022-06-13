using Domain.Common;

namespace Domain.Entities
{
    public class OrderToCategorys : BaseEntity
    {
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public Categorys Category { get; set; }
    }
}
