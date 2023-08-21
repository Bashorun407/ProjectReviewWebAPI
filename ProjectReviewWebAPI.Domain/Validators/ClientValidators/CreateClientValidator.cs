using FluentValidation;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.ClientValidators
{
    public class CreateClientValidator : AbstractValidator<ClientRequestDto>
    {
        public CreateClientValidator()
        {
            
        }
    }
}
