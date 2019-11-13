namespace ApiTaqueria.Models
{
    public class JWT
    {
        public string Site { get; set; }
        public string SigningKey { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
