using System;
namespace BrowserTravel.Library.Entities.Dto.Auth
{ 
    public class RegisterResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
