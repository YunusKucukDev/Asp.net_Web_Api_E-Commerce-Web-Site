namespace Udemy.IdentityServer.Settings
{
    public class ClientSettings
    {
        public Client UdemyVisitorClient { get; set; }
        public Client UdemyManagerClient { get; set; }
        public Client UdemyAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
