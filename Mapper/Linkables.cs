
namespace CcatApi.Mapper
{
    internal class Linkables
    {
        // Can not Use the Format Display Function with RNG Type since it would through a error since theres noting
        //internal static string CatLink = "https://api.thecatapi.com/v1/images/search"; // For RNG

        // internal static string CatLink = "https://api.thecatapi.com/v1/images/search?mime_types=png"; // For Pngs
        // internal static string CatLink = "https://api.thecatapi.com/v1/images/search?mime_types=jpg"; // For Jpg
        internal static string CatLink = "https://api.thecatapi.com/v1/images/search?mime_types=gif"; // For Gifs

        // For Displaying the Format type
        internal static string SerType = CatLink.Split('=')[1];

        // The Discord Webhook that will be embeding the Cats
        internal static string DiscordWebh = " WEBHOOK HERE";

        // Why not just put this here p-p
        internal static int SleepTime = 15000;
    }
}
