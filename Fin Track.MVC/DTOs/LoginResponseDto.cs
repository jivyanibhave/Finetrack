namespace Fin_Track.MVC.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
