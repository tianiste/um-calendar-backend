using UmCalendar.DTOs;
using UmCalendar.Models;
using UmCalendar.Services;
namespace UmCalendar.DTOs
{
    public class LoginDto
    {
        public required string Email {get; set;}
        public required string Password {get; set;}
    }    
}