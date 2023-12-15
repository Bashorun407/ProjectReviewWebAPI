namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record UserUpdateRequestDto    
    {
        public string? PhoneNumber { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? DateOfBirth { get; init; }

        public DateTime ModifiedAt { get; init; } = DateTime.Now;
    }
}
