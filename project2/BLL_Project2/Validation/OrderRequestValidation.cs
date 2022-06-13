using BLL_Project2.DTO.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Validation
{
    public class OrderRequestValidation : AbstractValidator<OrderRequestDTO>
    {
        public OrderRequestValidation()
        {

            RuleFor(req => req.customerId).NotEmpty()
                .WithMessage(req => $"{nameof(req.customerId)} can't be empty");

            RuleFor(req => req.DateOrder).NotEmpty()
                .WithMessage(req => $"{nameof(req.DateOrder)} can't be empty");



        }
    }
}
