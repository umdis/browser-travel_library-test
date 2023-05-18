using System;
namespace BrowserTravel.Library.Entities.Dto.Auth
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public string Token { get; set; }
    }
}
