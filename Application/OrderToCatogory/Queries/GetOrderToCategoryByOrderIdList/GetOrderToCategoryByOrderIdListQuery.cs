using MediatR;

namespace Application.OrderToCatogory.Queries.GetOrderToCategoryByOrderIdList
{
    public class GetOrderToCategoryByOrderIdListQuery:IRequest<IEnumerable<OrderToCategoryDTO>>
    {
        public int CategoryId { get; set; }
    }
}
