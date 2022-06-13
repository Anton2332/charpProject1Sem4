using BLL_Project2.DTO.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Project2.Validation
{
    public class UserSignInRequestValidation : AbstractValidator<UserSignInRequest>
    {
        public UserSignInRequestValidation()
        {
            RuleFor(request => request.UserName)
                .NotEmpty()
                .WithMessage("UserName can't be empty.");

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("Password can't be empty.");
        }
    }
}
