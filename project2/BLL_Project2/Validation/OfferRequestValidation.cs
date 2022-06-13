using BLL_Project2.DTO.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Validation
{
    public class OfferRequestValidation:AbstractValidator<OfferRequestDTO>
    {
        public OfferRequestValidation()
        {
            RuleFor(request => request.PerformerId)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.PerformerId)} can't be empty.");

            RuleFor(request => request.DescriptionPerformer)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.DescriptionPerformer)} can't by empty.")
                .MaximumLength(450)
                .WithMessage(req => $"{nameof(req.DescriptionPerformer)} should by less than 450 characters");

        }
    }
}
