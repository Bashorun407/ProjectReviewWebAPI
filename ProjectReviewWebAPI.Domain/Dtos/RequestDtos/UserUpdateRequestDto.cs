namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record UserUpdateRequestDto/*(string? phoneNumber, string? username, string? email,
        string? password, string? dateOfBirth);*/
    {
        public string? PhoneNumber { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? DateOfBirth { get; init; }

        public DateTime ModifiedAt { get; init; } = DateTime.Now;
    }
}
