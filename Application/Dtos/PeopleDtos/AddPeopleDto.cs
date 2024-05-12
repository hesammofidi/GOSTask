namespace Application.Dtos.PeopleDtos
{
    public class AddPeopleDto : IPeopleDto
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}
