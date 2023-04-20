namespace lab_3.Dtos
{
    public class TokenDto
    {
        public TokenDto(string token,DateTime expDate)
        {
            Token = token;
            ExpDate = expDate;
        }

        public string? Token { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
