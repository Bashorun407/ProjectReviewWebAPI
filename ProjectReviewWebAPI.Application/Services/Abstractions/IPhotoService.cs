using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IPhotoService
    {
        void AddPhotoForUser(int userId, PhotoRequestDto photoRequestDto);
    }
}
