using Application.Category.Queries.GetCategoryList;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderToCatogory.Queries.GetOrderToCategoryByOrderIdList
{
    public record OrderToCategoryDTO:IMapFrom<OrderToCategorys>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderToCategorys, OrderToCategoryDTO>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name));
        }
    }
}
