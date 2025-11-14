using UmCalendar.DTOs;
using UmCalendar.Models;
using UmCalendar.Services;
namespace UmCalendar.DTOs
{
    public class RegisterDto
    {
        public required string Email {get; set;}
        public required string Name {get; set;}
        public required string Password {get; set;}
    }
}