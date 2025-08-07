namespace CleaningServiceAPI.Common
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
    public class CorsOptions
    {
        public string[] AllowedOrigins { get; set; } = [];
    }
}