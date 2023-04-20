namespace lab_3.Dtos
{
    public class RegisterUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Email { get; set; }
        public decimal Salary { get; set; } 

    }
}
