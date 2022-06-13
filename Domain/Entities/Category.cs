using Domain.Common;

namespace Domain.Entities
{
    public class Categorys: BaseEntity
    {
        public string Name { get; set; }
        public IList<OrderToCategorys> Orders { get; set; }
    }
}
