namespace lab_3.Dtos
{
    public class RegisterAdminDto
    {
        public string? UserName { get; set; }
        public string Password { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }

    }
}
