namespace Shop.API.Singletones
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://shoptelegrambot.azurewebsites.net/{0}";
        public static string WebHookUrl => string.Format(Url, @"api/message/Update");
        public static string Name { get; set; } = "TestTelegramShop";
        public static string Token { get; set; } = "1158660778:AAEi0BoYtLIRBbfrNh6LmDbv7Lko3SIjppg";
    }
}
