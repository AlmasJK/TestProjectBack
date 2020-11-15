namespace TestProject.Shared.Data
{
    public class AppSettings
    {
        public AuthOption AuthOptions { get; set; }
    }


    public class AuthOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; } = 0;
        public int LifetimeRefresh { get; set; } = 0;
    }
}
