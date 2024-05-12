﻿namespace Application.Dtos.PeopleDtos
{
    public class PeopleDto : IPeopleDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}
