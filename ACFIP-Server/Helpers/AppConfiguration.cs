namespace ACFIP_Server.Helpers
{
    public class AppConfiguration
    {
        public string DbConnectionString { get; set; }
        public string JwtSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
